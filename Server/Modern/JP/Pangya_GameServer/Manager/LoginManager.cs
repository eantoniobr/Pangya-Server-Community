using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.DataBase;
using PangyaAPI.Network;
using PangyaAPI.Network.Repository;
using PangyaAPI.Network.Session;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;
using snmdb;
namespace Pangya_GameServer.Manager
{
    public class LoginManager
    {
        public static void SendReply(Player _session, int msg_id)
        {
            var p = new Packet(0x44);
            p.WriteByte(eLoginAck.ACK_UPDATE_LOGIN_UNIT);
            p.WriteInt32(msg_id);
            _session.Send(p);
        }


        public static void SendCompleteData(Player _session)
        {
            //// Check All Character All Item Equiped is on Warehouse Item of Player
            foreach (var el in _session.Inventory.Characters)
            {
                // Check Parts of Character e Check Aux Part of Character
                _session.CheckCharacterAllItemEquiped(el.Value);
            }

            // Check All Item Equiped
            _session.CheckAllItemEquiped(_session.Inventory.UserEquipment);

            // Envia todos pacotes aqui, alguns envia antes, por que agora estou usando o jeito o pangya original   

            _session.Send(Login(_session));

            _session.Send(Handle_PACKET_RESPONSE.pacote070(_session.Inventory.Characters)); // characters

            _session.Send(Handle_PACKET_RESPONSE.pacote071(_session.Inventory.Caddies)); //caddies   

            _session.Send(_session.Inventory.WarehouseItems.Build()); //inventory(warehouse)   

            _session.Send(Handle_PACKET_RESPONSE.pacote0E1(_session.Inventory.Mascots)); //mascots

            _session.Send(Handle_PACKET_RESPONSE.pacote072(_session.Inventory.UserEquipment)); // equip selected                     

            GameServer.getInstance().SendChannelList(_session);

            _session.Send(Handle_PACKET_RESPONSE.pacote102(_session.UserInfo, _session.Inventory.CouponGacha));        // Pacote novo do JP, passa os coupons do Gacha JP

            // Treasure Hunter Info
            _session.Send(Handle_PACKET_RESPONSE.pacote131());

            _session.UserInfo.Achievements.sendCounterItemToPlayer(_session);

            _session.UserInfo.Achievements.sendAchievementToPlayer(_session);

            //call messenger server
            _session.Send(Handle_PACKET_RESPONSE.pacote0F1());

            _session.Send(Handle_PACKET_RESPONSE.pacote135());

            _session.Send(Handle_PACKET_RESPONSE.pacote144());        // Pacote novo do JP

            _session.Send(Handle_PACKET_RESPONSE.pacote138(_session.Inventory.Cards));

            _session.Send(Handle_PACKET_RESPONSE.pacote136());

            _session.Send(Handle_PACKET_RESPONSE.pacote137(_session.Inventory.CardEquipment));
            //call messenger server
            _session.Send(Handle_PACKET_RESPONSE.pacote13F());
            _session.Send(Handle_PACKET_RESPONSE.pacote181(_session.Inventory.ItemBuffs));
            _session.Send(Handle_PACKET_RESPONSE.pacote096(_session.UserInfo.Cookie));
            _session.Send(Handle_PACKET_RESPONSE.pacote169(_session.Inventory.CurrentTrophy, 5/*season atual*/));
            _session.Send(Handle_PACKET_RESPONSE.pacote169(_session.Inventory.RemainingTrophy));
            _session.Send(Handle_PACKET_RESPONSE.pacote0B4(_session.Inventory.CurrentSpecialTrophies, 5/*season atual*/));
            _session.Send(Handle_PACKET_RESPONSE.pacote0B4(_session.Inventory.RemainingSpecialTrophies));
            _session.Send(Handle_PACKET_RESPONSE.pacote158(_session.UserInfo.uid, _session.UserInfo.Statistics, 0));
            //// Total de season, 5 atual season  
            _session.Send(Handle_PACKET_RESPONSE.pacote25D(_session.Inventory.CurrentGrandPrixTrophies, 5/*season atual*/));
            _session.Send(Handle_PACKET_RESPONSE.pacote25D(_session.Inventory.RemainingGrandPrixTrophies, 0));

            if (/*GameServer.getInstance().getInfo().rate.login_reward_event == 1 && */sLoginRewardSystem.getInstance().isLoad())
                sLoginRewardSystem.getInstance().CheckRewardLoginAndSend(_session);
        }

        static Packet Login(Player _session)
        {
            var p = new Packet(0x44);
            p.WriteByte(0);   // Option
            p.WriteString(GameServer.getInstance().getInfo().version_client); 
            //write struct member info _session      
            p.WriteBytes(_session.UserInfo.getLoginInfo());//new version
            p.WriteUInt32(_session.UserInfo.uid);
            // write struct _session(statistic)
            p.WriteBytes(_session.UserInfo.getUserInfo());//new version 
            // write struct Trofel Info
            p.WriteBytes(_session.Inventory.getInfoTrophy());
            //write struct User Equip
            p.WriteBytes(_session.Inventory.getUserEquip());//new version 
            //write struct session(statistic)
            p.WriteBytes(_session.UserInfo.GetMapStatistic());
            //Equiped Items
            #region EquipedItem
            p.WriteBytes(_session.Inventory.getUserEquipedItem());
            #endregion
            // Write Time, 16 Bytes
            p.WriteTime();

            // Config do Server(struct for server)
            p.WriteUInt16(0); //depois eu procuro o que é
            p.WriteBytes(_session.UserInfo.Member.PapelShop.ToArray());
            p.WriteUInt32(_session.UserInfo.Member.point_point_event); // point_point_event.
            p.WriteUInt64(_session.UserInfo.block_flag.m_flag.ullFlag); // Flag do server para bloquear sistemas 
            p.WriteInt32(_session.Inventory.ToTalClubSetCount + _session.Inventory.TotalPartsCount);
            p.WriteUInt32(GameServer.getInstance().getInfo().propriedade.ulProperty);
            return p;
        }
    }
}