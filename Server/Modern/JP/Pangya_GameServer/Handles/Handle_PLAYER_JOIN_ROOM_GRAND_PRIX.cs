using Pangya_GameServer.Flags;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Roms;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models.IFF;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_JOIN_ROOM_GRAND_PRIX : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            var p = new Packet();

            try
            {
                // Lê o TypeID do Grand Prix que o Player quer entrar/criar
                uint _typeid_gp = Packet.ReadUInt32();

                // 1. Validações de Permissão (Flags)
                var flag = Player.UserInfo.block_flag.m_flag;

                if (flag.all_game)
                {
                    throw new exception($"[GP_Handler] PLAYER[UID={Player.UserInfo.uid}] tentou entrar no GP, mas possui flag 'all_game' bloqueada.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 0x6700003, 0x6700003));
                }

                if (flag.grand_prix)
                {
                    throw new exception($"[GP_Handler] PLAYER[UID={Player.UserInfo.uid}] bloqueado para Grand Prix.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 0x6700004, 0x6700004));
                }

                // 2. Busca dados no IFF
                var gp = sIff.getInstance().findGrandPrixData(_typeid_gp);
                if (gp == null || !gp.Active)
                {
                    throw new exception($"[GP_Handler] GP[TYPEID={_typeid_gp}] inexistente ou inativo.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 0x6700001, 0x6700001));
                }

                // 3. Verificações de Requisitos (Level e Tickets)
                if (Player.UserInfo.Member.level < gp.MinLevel || (gp.MaxLevel > 0 && Player.UserInfo.Member.level > gp.MaxLevel))
                {
                    throw new exception("Level incompatível para este Grand Prix.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 0x6700006, 0x6700006));
                }

                if (gp.ticket.qntd > 0 && gp.ticket._typeid > 0)
                {
                    var pWi = Player.Inventory.FindWarehouseItemByTypeid(gp.ticket._typeid);
                    if (pWi == null || pWi.STDA_C_ITEM_QNTD < gp.ticket.qntd)
                    {
                        throw new exception("Tickets insuficientes.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 0x6700009, 0x6700009));
                    }
                }

                // 4. Lógica de Sala
                Room r = null;
                var channel = Player.GetChannel();

                // Regra: Rookie sempre cria instância nova, outros tentam achar sala existente
                bool isRookie = sIff.getInstance().isGrandPrixNormal(gp.ID) &&
                                sIff.getInstance().getGrandPrixAbaType(gp.ID) == GrandPrixData.GP_ABA.ROOKIE;

                r = GameServer.getInstance().FindRoomGrandPrix(gp.ID);

                if (isRookie || r == null)
                {
                    // CRIAÇÃO DE SALA NOVA
                    var ri = CreateGP_RoomInfo(gp);
                    channel.DeleteInviteTimeResquestByInvited(Player);

                    r = GameServer.getInstance().MakeRoomGrandPrix(channel, ri, Player, gp, 1);
                    if (r == null) throw new Exception("Falha ao criar instância de sala GP.");
                }
                else
                {
                    // ENTRADA EM SALA EXISTENTE
                    if (r.IsFull())
                    {
                        throw new exception("Sala Grand Prix cheia.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 3, 0x6700005));
                    }

                    channel.DeleteInviteTimeResquestByInvited(Player);
                    r.EnterToRoom(Player);
                }

                // 5. Finalização e Pacotes de Resposta
                channel.UpdatePlayerInfo(Player);
                r.SendHeadRoom();
                r.SendMakeRoom(Player);
                r.SendPlayerInfo(Player, 0);

                if (r.GetTipo() != ROOM_INFO_TYPE.PRACTICE)
                {
                    channel.SendUpdatePlayerInfo(Player, 3);
                }

                channel.SendUpdateRoomInfo(r.GetInfo(), 1);

                channel.AddRoom(r);

                await Task.CompletedTask;
            }
            catch (exception e)
            {
                // Loga o erro e envia o pacote 0x253 de erro pro cliente
                _smp.message_pool.getInstance().push(new message($"[Handle_GP][Error] {e.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x253);
                uint errCode = ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                    : 0x6700000;
                p.WriteUInt32(errCode);

               Player.Send(p);
            }
        }

        // Helper para montar o RoomInfo do Grand Prix
        private RoomInfo CreateGP_RoomInfo(GrandPrixData gp)
        {
            var ri = new RoomInfo
            {
                max_player = 30,
                tipo = (byte)ROOM_INFO_TYPE.GRAND_PRIX,
                qntd_hole = gp.course_info.Qntd_hole,
                course = (ROOM_INFO_COURSE)gp.course_info.Course,
                modo = (byte)gp.course_info.Modo,
                name = gp.Name
            };
            ri.grand_prix.active = 1;
            ri.grand_prix.dados_typeid = gp.ID;
            ri.grand_prix.rank_typeid = gp.TypeID_Link;
            ri.grand_prix.tempo = (uint)(gp.TimeHole * 1000);
            ri.typeid_artefatic = gp.rule;
            ri.special_flag_mod.natural = gp.flag.Natural_Mode;
            ri.special_flag_mod.short_game = gp.flag.Shot_Mode;
            return ri;
        }
    }
}