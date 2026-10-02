using Pangya_GameServer.Models;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Linq;
using System.Threading.Tasks;
using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_ENTER_MY_ROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet pkt)
        {
            try
            { 
                var pri = BuildPlayerRoomInfo(session);

                // Envio do Pacote 0x168 (Dados do Personagem/Estado)
                var p168 = new Packet(0x168);
                p168.WriteBytes(pri.ToArrayEx());
                session.Send(p168);

                // Envio do Pacote 0x12D (Itens do MyRoom - Posters/Móveis)
                var p12D = new Packet(0x12D);
                p12D.WriteUInt32(1); // Option: Load Items

                var items = session.Inventory.MyRoomItems;
                p12D.WriteUInt16((ushort)items.Count);

                foreach (var item in items)
                {
                    p12D.WriteBytes(item.ToArray());
                }

                session.Send(p12D);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[MyRoom::Enter] Player[UID: {session.UserInfo.uid}] Error: {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }

        private PlayerRoomInfoEx BuildPlayerRoomInfo(Player s)
        {
            var ui = s.UserInfo;
            var inv = s.Inventory;

            var pri = new PlayerRoomInfoEx
            {
                oid = s.ConnectionID,
                uid = ui.uid,
                nickname = ui.nickname,
                guild_name = ui.Guild.name,
                guild_uid = ui.Guild.uid,
                guild_mark_img = ui.Guild.mark_emblem,
                guild_mark_index = ui.Guild.index_mark_emblem,
                level = ui.Member.level,
                position = 0,
                capability = ui.UserCapabilities,
                title = inv.UserEquipment.m_title,
                avg_score = ui.Statistics.getMediaScore(),
                place = new PlayerPlace(0x0A), // My Room State
                state_action = { posture = ui.PostureRoom, animation = ui.LoungeState },
                location = new PlayerRoomInfo.stLocation { x = ui.CurrentLocation.x, z = ui.CurrentLocation.z, y = ui.CurrentLocation.r },
                shop = new PlayerRoomInfo.PersonShop(),
                flag_item_boost = inv.CheckHaveItemBoost(),
                convidado = 0
            };

            // Setup de Skin e Personagem
            if (inv.UserEquippedItem.CharacterEquiped != null)
            {
                pri.ci = inv.UserEquippedItem.CharacterEquiped;
                pri.char_typeid = inv.UserEquippedItem.CharacterEquiped._typeid;
                pri.skin = (uint[])inv.UserEquipment.skin_typeid.Clone();
                pri.skin[4] = 0; // Cut-in fix para exibição correta
            }

            // Mascot
            if (inv.UserEquippedItem.MascotEquiped != null)
                pri.mascot_typeid = inv.UserEquippedItem.MascotEquiped._typeid;

            // Flags de Estado
            pri.state_flag.master = 1;
            pri.state_flag.ready = 1;
            pri.state_flag.sexo = ui.Member.sexo;

            // Lógica de Ícones (Quit Rate / Angel)
            UpdatePlayerIcons(s, pri);

            return pri;
        }

        private void UpdatePlayerIcons(Player s, PlayerRoomInfo pri)
        {
            float quitRate = s.UserInfo.Statistics.getQuitRate();
            bool isBeginnerPlus = s.UserInfo.Member.level >= 6 && s.UserInfo.Statistics.jogado >= 50;

            if (isBeginnerPlus)
            {
                if (quitRate < GOOD_PLAYER_ICON) pri.state_flag.azinha = 1;
                else if (quitRate < QUITER_ICON_2) pri.state_flag.quiter_1 = 1;
                else pri.state_flag.quiter_2 = 1;
            }

            // Angel Icon
            if (s.Inventory.UserEquippedItem.CharacterEquiped != null && quitRate < GOOD_PLAYER_ICON)
            {
                pri.icon_angel = s.Inventory.UserEquippedItem.CharacterEquiped.AngelEquiped();
            }
        }
    }
}