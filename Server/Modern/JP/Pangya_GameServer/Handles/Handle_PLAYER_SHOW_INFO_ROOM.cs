using Pangya_GameServer.Flags;
using Pangya_GameServer.Models;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_SHOW_INFO_ROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {

                short sala_numero = _packet.ReadInt16();

                // aqui tem que passar o pacote86 com resposta que a sala não existe
                var r = GameServer.getInstance().FindRoom(sala_numero) ?? throw new exception("[Handle_PLAYER_SHOW_INFO_ROOM][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + " ] pediu info da sala[NUMERO=" + (sala_numero) + "] nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        10, 0));
                
                var ri = r.GetInfo();

                Packet p = new(0x86);
                p.WriteUInt32(ri.num_player);
                p.WriteByte(ri.qntd_hole);
                p.WriteUInt32((ri.GetTipo() == ROOM_INFO_TYPE.STROKE || ri.GetTipo() == ROOM_INFO_TYPE.MATCH || ri.GetTipo() == ROOM_INFO_TYPE.PANG_BATTLE) ? ri.time_vs : ((ri.GetTipo() == ROOM_INFO_TYPE.GUILD_BATTLE) ? 0 : ri.time_30s));
                p.WriteByte((byte)ri.course);
                p.WriteByte((byte)ri.GetTipo());
                p.WriteByte(ri.modo);
                p.WriteUInt32(ri.trofel);

                List<Player> v_session = r.GetSessions();
                PlayerLobbyInfo pci = null;

                for (var i = 0; i < v_session.Count; ++i)
                {
                    var _channel = v_session[i].GetChannel();

                    pci = _channel?.GetPlayerInfo(v_session[i]) ?? throw new exception("[Handle_PLAYER_SHOW_INFO_ROOM][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + " ] nao tem o info do player na sala[NUMERO=" + (sala_numero) + "].", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                            11, 0)); 

                    p.WriteInt32(pci?.oid ?? -1);
                    p.WriteByte(pci?.level ?? 0);
                    p.WriteByte(GetGameHole(v_session[i])); // se estiver jogando, aqui fica o número do hole
                    p.WriteInt32(pci?.capability.ulCapability ?? 0);
                    p.WriteUInt32(pci?.title ?? 0);
                    p.WriteUInt32(pci?.ladder_point ?? 0);
                }

                _session.Send(p);
            }
            catch (exception e)
            {
                Packet p = new(0x86);
                p.WriteUInt16(0);
                _session.Send(p);
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_SHOW_INFO_ROOM][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }

        public byte GetGameHole(Player player)
        {
            var game = player.GetGameRoom();
            if (game != null)
            {
                return (byte)game.getNumHole(player);
            }
            return 255;
        }
    }
}