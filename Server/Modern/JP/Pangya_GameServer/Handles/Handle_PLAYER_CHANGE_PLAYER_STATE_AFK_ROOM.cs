using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Session;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHANGE_AFK_STATE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet packet)
        {
            var _channel = _session.GetChannel();
            try
            {
                byte state = packet.ReadByte();

                var room = _session.GetRoom();

                if (room == null)
                {
                    throw new exception(
                        $"[AFK][Error] Player[UID={_session.UserInfo.uid}] tentou mudar estado AFK mas não está em uma sala.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 10, 0));
                }

                var pri = room.GetPlayerInfo(_session);

                // PlayerLobbyInfo (Info que o canal enxerga no Lobby) 
                var pci = _channel?.GetPlayerInfo(_session);

                if (pri == null || pci == null)
                {
                    throw new exception(
                        $"[AFK][Error] Falha ao localizar Info de Sala ou Lobby para UID={_session.UserInfo.uid}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 11, 0));
                }

                //Atualização dos Flags
                pci.state_flag.away = pri.state_flag.away = state;

                _channel?.UpdatePlayerInfo(_session);
                room?.UpdatePlayerInfo(_session);

                using (var response = new Packet())
                {
                    response.init_plain(0x8E);
                    response.WriteInt32(_session.ConnectionID); // OID do jogador
                    response.WriteByte(state);          // Novo estado 
                    room?.SendBroadCast(response);
                }

                if (_channel != null)
                {
                    _channel.Lobby.SendUpdatePlayerInfo(_session, 3);
                }

            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_CHANGE_AFK_STATE][ErrorSystem] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }
    }
}