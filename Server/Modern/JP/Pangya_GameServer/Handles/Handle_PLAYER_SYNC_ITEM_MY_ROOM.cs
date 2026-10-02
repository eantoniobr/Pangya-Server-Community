using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Models;
using PangyaAPI.Network.Repository;
using PangyaAPI.Network.Session;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;


namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_SYNC_ITEM_MY_ROOM : IPacketHandler<Player>
    {
        /// <summary>
        /// Flags de atualização do My Room (Quarto). 
        /// Define qual categoria de equipamento o servidor deve processar e sincronizar.
        /// </summary>
        private enum SYNC_ITEM_FLAGS : byte
        {
            /// <summary>
            /// Atualiza todas as roupas e acessórios (anéis, luvas, camisas, etc.) do personagem
            /// </summary> 
            SYNC_CHAR_ALL_PARTS = 0,

            // Atualiza o Caddie equipado na sessão do jogador
            SYNC_CADDIE = 1,

            // Atualiza os itens de uso rápido (Potions, Phoenix, etc.) nos slots de jogo
            SYNC_USE_ITEMS = 2,

            // Sincroniza a Taqueira (ClubSet) e a Bola (Comet/Ball) escolhidas
            SYNC_CLUB_AND_BALL = 3,

            // Atualiza as Skins de interface ou efeitos aplicados
            SYNC_SKINS = 4,

            // Altera o Personagem Principal (Character) ativo na conta
            SYNC_CHAR_MAIN = 5,

            // Atualiza o Mascote equipado (se houver)
            SYNC_MASCOT = 8,

            // Altera a imagem de Cut-In (animação que aparece no Power Shot)
            SYNC_CHAR_CUTIN = 9,

            // Atualiza o Poster/Fundo de tela do perfil do jogador
            SYNC_POSTER = 10
        }

        public async Task Handle(Player _session, Packet _packet)
        {
            SYNC_ITEM_FLAGS type = SYNC_ITEM_FLAGS.SYNC_CHAR_ALL_PARTS;
            int error = 4;

            try
            {
                type = (SYNC_ITEM_FLAGS)_packet.ReadByte(); 

                _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_SYNC_ITEM_MY_ROOM][Warning] PLAYER[UID: {_session.UserInfo.uid}, REQ: {type}]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                switch (type)
                {
                    case SYNC_ITEM_FLAGS.SYNC_CHAR_ALL_PARTS:
                        // AQUI: Onde o anel e as roupas são processados
                        error = HandleUpdateCharacterParts(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_CADDIE:
                        error = HandleUpdateCaddie(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_USE_ITEMS:
                        error = HandleUpdateUseItems(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_CLUB_AND_BALL:
                        // AQUI: Onde o ClubSet e a Comet são sincronizados
                        error = HandleUpdateClubAndBall(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_SKINS:
                        error = HandleUpdateSkins(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_CHAR_MAIN:
                        // Troca o personagem principal da conta
                        error = HandleUpdateCharacter(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_MASCOT:
                        error = HandleUpdateMascot(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_CHAR_CUTIN:
                        error = HandleUpdateCutin(_session, _packet);
                        break;

                    case SYNC_ITEM_FLAGS.SYNC_POSTER:
                        error = HandleUpdatePoster(_session, _packet);
                        break;

                    default:
                        _smp.message_pool.getInstance().push(new message(
                            $"[MyRoom] Tipo de update não implementado: {type} ({type})",
                            type_msg.CL_ONLY_CONSOLE));
                        error = 1;
                        break;
                }
                _session.Send(Handle_PACKET_RESPONSE.pacote06B(_session.Inventory, (byte)type, error));

                _session.GetChannel()?.UpdatePlayerInfo(_session);
            }
            catch (exception e)
            {
                _session.Send(Handle_PACKET_RESPONSE.pacote06B(_session.Inventory, (byte)type, 1));

                _smp.message_pool.getInstance().push(
                    new message(
                        "[Handle_PLAYER_CHANGE_PLAYER_ITEM_MY_ROOM][ErrorSystem] " +
                        e.getFullMessageError(),
                        type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
            await Task.CompletedTask;
        }


        private int HandleUpdateCharacterParts(Player session, Packet packet)
        {
            int error = 4;

            CharacterInfo ci = new CharacterInfo().ToRead(packet);
            var pCe = session.Inventory.FindCharacterById(ci.id);

            if (ci.id == 0 || pCe == null)
                return (ci.id == 0) ? 1 : 2;

            session.Inventory.SyncCharacter(ci.id, ci); //sempre antes

            session.CheckCharacterEquipedPart(ci);
            session.CheckCharacterEquipedAuxPart(ci);

            NormalManagerDB.getInstance().add(0, new CmdUpdateCharacterAllPartEquiped(session.Inventory.uid, ci));

            return error;
        }

        private int HandleUpdateCharacter(Player session, Packet packet)
        {
            int error = 4;
            int charId = packet.ReadInt32();

            var pCe = session.Inventory.FindCharacterById(charId);

            if (charId == 0 || pCe == null)
                return (charId == 0) ? 1 : 2;
            //é diferente do outro
            session.Inventory.SyncCharacter(charId);

            NormalManagerDB.getInstance().add(0, new CmdUpdateCharacterEquiped(session.Inventory.uid, charId));

            return error;
        }

        private int HandleUpdateCaddie(Player session, Packet packet)
        {
            int error = 4;
            int itemId = packet.ReadInt32();

            if (itemId != 0)
            {
                var caddie = session.Inventory.FindCaddieById(itemId);

                if (caddie == null)
                    return 2;

                session.Inventory.UserEquippedItem.CaddieEquiped = caddie;
                session.Inventory.UserEquipment.caddie_id = itemId;

                if (session.CheckCaddieEquiped(session.Inventory.UserEquipment))
                    itemId = session.Inventory.UserEquipment.caddie_id;
            }
            else
            {
                session.Inventory.UserEquipment.caddie_id = 0;
            }

            NormalManagerDB.getInstance().add(0, new CmdUpdateCaddieEquiped(session.Inventory.uid, itemId));

            return error;
        }

        private int HandleUpdateClubAndBall(Player session, Packet packet)
        {
            int error = 4;

            // BALL
            int ballTypeId = packet.ReadInt32();
            var ball = session.Inventory.FindWarehouseItemByTypeid((uint)ballTypeId);

            if (ball != null)
            {
                session.Inventory.UserEquippedItem.Ball_WI = ball;
                session.Inventory.UserEquipment.ball_typeid = (uint)ballTypeId;

                if (session.CheckBallEquiped(session.Inventory.UserEquipment))
                    ballTypeId = (int)session.Inventory.UserEquipment.ball_typeid;
            }
            else
            {
                session.Inventory.UserEquipment.ball_typeid = 0;
            }

            NormalManagerDB.getInstance().add(0, new CmdUpdateBallEquiped(session.Inventory.uid, (uint)ballTypeId));

            // CLUBSET
            int clubId = packet.ReadInt32();
            var club = session.Inventory.FindWarehouseItemById(clubId);

            if (club == null)
                return 2;

            session.Inventory.UserEquippedItem.Club_WI = club;
            session.Inventory.UserEquipment.clubset_id = clubId;

            if (session.CheckClubSetEquiped(session.Inventory.UserEquipment))
                clubId = session.Inventory.UserEquipment.clubset_id;

            NormalManagerDB.getInstance().add(
                 0,
                 new CmdUpdateClubsetEquiped(session.Inventory.uid, clubId));

            return error;
        }

        private int HandleUpdateUseItems(Player session, Packet packet)
        {
            int error = 4;

            UserEquip ue = new()
            {
                item_slot = packet.ReadUInt32(session.Inventory.UserEquipment.item_slot.Length)
            };

            if (session.Inventory.CheckItemEquiped(ue.item_slot)) //verificacao....
                session.Inventory.UserEquipment.item_slot = ue.item_slot;

            NormalManagerDB.getInstance().add(25, new CmdUpdateItemSlot(session.Inventory.uid, ue.item_slot));

            return error;
        }

        private int HandleUpdateSkins(Player session, Packet packet)
        {
            int error = 4;

            for (int i = 0; i < session.Inventory.UserEquipment.skin_typeid.Length; i++)
            {
                int id = packet.ReadInt32();

                if (id == 0)
                {
                    session.Inventory.UserEquipment.skin_id[i] = 0;
                    session.Inventory.UserEquipment.skin_typeid[i] = 0;
                    continue;
                }

                var skin = session.Inventory.FindWarehouseItemByTypeid((uint)id);

                if (skin == null)
                    return 2;

                session.Inventory.UserEquipment.skin_id[i] = (uint)skin.id;
                session.Inventory.UserEquipment.skin_typeid[i] = skin._typeid;
            }

            NormalManagerDB.getInstance().add(0, new CmdUpdateSkinEquiped(session.Inventory.uid, session.Inventory.UserEquipment));

            return error;
        }

        private int HandleUpdateMascot(Player session, Packet packet)
        {
            int error = 4;
            int id = packet.ReadInt32();

            if (id != 0)
            {
                var mascot = session.Inventory.FindMascotById(id);
                if (mascot == null)
                    return 2;

                session.Inventory.UserEquippedItem.MascotEquiped = mascot;
                session.Inventory.UserEquipment.mascot_id = id;
            }
            else
            {
                session.Inventory.UserEquipment.mascot_id = 0;
            }

            NormalManagerDB.getInstance().add(0, new CmdUpdateMascotEquiped(session.Inventory.uid, id));

            return error;
        }

        private int HandleUpdateCutin(Player session, Packet packet)
        {
            int error = 4;

            int charId = packet.ReadInt32();
            var ci = session.Inventory.FindCharacterById(charId);

            if (charId == 0)
                return 1; // Invalid Item Id

            if (ci == null)
                return 2; // Not Found

            if (session.Inventory.UserEquippedItem.CharacterEquiped == null)
                return 4; // No character equipped

            if (session.Inventory.UserEquippedItem.CharacterEquiped.id != ci.id)
                return 5; // Not the equipped character

            int[] cutins = packet.ReadInt32(session.Inventory.UserEquippedItem.CharacterEquiped.cut_in.Length);

            for (int i = 0; i < cutins.Length; i++)
            {
                int cutinId = cutins[i];

                if (cutinId == 0)
                {
                    ci.cut_in[i] = 0;
                    continue;
                }

                var pWi = session.Inventory.FindWarehouseItemById(cutinId);

                if (pWi == null ||
                    sIff.getInstance().getItemGroupIdentify(pWi._typeid) != IFF_GROUP.SKIN)
                    return 3; // Item Type Wrong

                ci.cut_in[i] = (uint)cutinId;
            }

            session.Inventory.SyncCharacter(ci.id, ci); //sempre antes

            // Validação final
            session.CheckCharacterEquipedCutin(ci);

            // Update DB
            NormalManagerDB.getInstance().add(0, new CmdUpdateCharacterCutinEquiped(session.Inventory.uid, ci));

            return error;
        }

        private int HandleUpdatePoster(Player session, Packet packet)
        {
            int error = 4;

            for (int i = 0; i < session.Inventory.UserEquipment.poster.Length; i++)
            {
                int posterTypeId = packet.ReadInt32();

                if (posterTypeId == 0)
                {
                    session.Inventory.UserEquipment.poster[i] = 0;
                    continue;
                }

                var pMri = session.Inventory.FindMyRoomItemByTypeid((uint)posterTypeId);

                if (pMri == null ||
                    sIff.getInstance().getItemGroupIdentify(pMri._typeid) != IFF_GROUP.FURNITURE)
                    return 2;

                session.Inventory.UserEquipment.poster[i] = (uint)posterTypeId;
            }

            if (session.CheckPosterEquiped(session.Inventory.UserEquipment) || error == 4)
            {
                NormalManagerDB.getInstance().add(0, new CmdUpdatePosterEquiped(session.Inventory.uid, session.Inventory.UserEquipment));
            }

            return error;
        }
    }
}
