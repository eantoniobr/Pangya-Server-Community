using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System.Linq;

namespace Pangya_MessengerServer.Handles
{
    public class Handle_PLAYER_ASSING_NICK : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        { 
            var p = new Packet();

            try
            {
                uint uid = _packet.ReadUInt32();
                var apelido = _packet.ReadString();
                  
                if (uid == 0)
                    throw new exception("[MessengerService::requestAssingApelido][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou da um apelido para o Amigo[UID="
                            + (uid) + ", APELIDO=" + apelido + "], mas o uid is invalid(zero). Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1, 0x5200901));

                if (string.IsNullOrEmpty(apelido)) // Compatibilidade para apelido.empty()
                    throw new exception("[MessengerService::requestAssingApelido][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou da um apelido para o Amigo[UID="
                            + (uid) + ", APELIDO=" + apelido + "], mas o apelido is empty. Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 2, 0x5200902));

                if (apelido.Length >= 11) // Usando Length para o Count() de string
                    throw new exception("[MessengerService::requestAssingApelido][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou da um apelido para o Amigo[UID="
                            + (uid) + ", APELIDO=" + apelido + "], mas o comprimento do apelido[max=11, request=" + (apelido.Length) + "] eh invalido.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 3, 0x5200903));

                var pFi = _session.UserInfo.m_friend_manager.findFriend(uid);

                if (pFi == null)
                    throw new exception("[MessengerService::requestAssingApelido][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou da um apelido para o Amigo[UID="
                            + (uid) + ", APELIDO=" + apelido + "], mas ele nao tem esse player como amigo. Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 4, 0x5200903));

                // UPDATE ON SERVER 
                pFi.apelido = apelido;

                // UPDATE ON DB - Usando await para garantir a persistência no banco
                _session.UserInfo.m_friend_manager.requestUpdateFriendInfo(pFi);

                // Log original
                _smp.message_pool.getInstance().push(new message("[AssingApelido][Log] player[UID=" + (_session.UserInfo.uid) + "] colocou apelido[VALUE="
                        + apelido + "] no Amigo[UID=" + (pFi.uid) + ", NICKNAME=" + (pFi.nickname) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Resposta para assing apelido (Protocolo 0x30 / Sub 0x119)
                p.init_plain(0x30);
                p.Write((ushort)0x119); // Sub packet Id
                p.Write((uint)0);       // OK

                p.Write((uint)pFi.uid);
                p.WriteString(pFi.apelido); 
                _session.Send(p);

            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[MessengerService::requestAssingApelido][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x30);
                p.Write((ushort)0x119);

                uint error_code = (ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) == (uint)STDA_ERROR_TYPE.MESSAGE_SERVER)
                                  ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                                  : 0x5200900;

                p.Write((uint)error_code);

                _session.Send(p);
            }
        }
    }
}
