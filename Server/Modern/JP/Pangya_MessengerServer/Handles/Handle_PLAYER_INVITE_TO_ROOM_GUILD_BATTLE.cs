using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_MessengerServer.Handles
{
    public class Handle_PLAYER_INVITE_GUILD_BATTLE : IPacketHandler<Player>//<Packet_PLAYER_INVITE_TO_ROOM_GUILD_BATTLE, MPlayer>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                uint server_uid = _packet.ReadUInt32();
                byte channel_id = _packet.ReadByte();
                ushort room_numero = _packet.ReadUInt16();

                uint player_invite_uid = _packet.ReadUInt32();
                var player_invite_nickname = _packet.ReadString();

                uint player_invited_uid = _packet.ReadUInt32();

                // Validação de Integridade: O UID de quem convida deve ser o mesmo da sessão
                if (player_invite_uid != _session.UserInfo.uid)
                {
                    throw new exception($"[MessengerService::HandleInviteGB][Error] Player[UID={_session.UserInfo.uid}] não bate com UID={player_invite_uid} do request. Hacker ou Bug.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 3750, 0));
                }

                // Log detalhado para monitoramento da Guild Battle no Pangya Fun
                _smp.message_pool.getInstance().push(new message(
                    $"[MessengerService::HandleInviteGB][Log] Player[UID={_session.UserInfo.uid}, NICKNAME={player_invite_nickname}] " +
                    $"convidou o Player[UID={player_invited_uid}] no Server[UID={server_uid}, CHANNEL_ID={channel_id}, ROOM={room_numero}] para Guild Battle.",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));

                // TODO: Se for implementar a entrega do convite via Messenger em tempo real, 
                // você precisaria buscar a sessão do 'player_invited_uid' e enviar o pacote 0x21 (Invite).

                await Task.CompletedTask;
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[MessengerService::HandleInviteGB][ErrorSystem] " + e.getFullMessageError(),
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }
        }
    }
}
