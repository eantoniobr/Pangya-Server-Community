using Pangya_MessengerServer.Manager;
using Pangya_MessengerServer.Models;
using Pangya_MessengerServer.Repository;
using Pangya_MessengerServer.Server;
using Pangya_MessengerServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_MessengerServer.Handles
{
    public class Handle_PLAYER_UNBLOCK_FRIEND : IPacketHandler<Player>//<Packet_PLAYER_UNBLOCK_FRIEND, MPlayer>
    {
        public async Task Handle(Player _session, Packet _packet)
        { 
            var p = new Packet();

            try
            {
                uint uid = _packet.ReadUInt32();
                  
                if (uid == 0)
                    throw new exception("[MessengerService::requestUnBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou desbloquear Amigo[UID="
                            + (uid) + "], mas uid is invalid(zero). Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1, 0x5300201));

                var pFi = _session.UserInfo.m_friend_manager.findFriend(uid);

                if (pFi == null)
                    throw new exception("[MessengerService::requestUnBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou desbloquear Amigo[UID="
                            + (uid) + "], mas o player nao eh amigo dele. Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 2, 0x5300202));

                if (pFi.state.block != 1)
                    throw new exception("[MessengerService::requestUnBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou desbloquear Amigo[UID="
                            + (uid) + "], mas o amigo ja esta desbloqueado. Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 3, 0x5300203));

                // Usando a função que refatoramos no ServerBase para encontrar a sessão
                var s = MessengerServer.getInstance().FindSessionByUid(uid);

                FriendInfoEx pFi2 = null;

                if (s != null)
                {   // Player está online
                    if ((pFi2 = s.UserInfo.m_friend_manager.findFriend(_session.UserInfo.uid)) == null)
                        throw new exception("[MessengerService::requestUnBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou desbloquear Amigo[UID="
                                + (uid) + "], mas o amigo nao tem ele na lista de amigos. Hacker ou Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 4, 0x5200204));

                    // Amigo
                    pFi.state.block = 0;

                    // UPDATE ON DB
                    _session.UserInfo.m_friend_manager.requestUpdateFriendInfo(pFi);

                    // Log original
                    _smp.message_pool.getInstance().push(new message("[UnBlockFriend][Log] player[UID=" + (_session.UserInfo.uid) + "] desbloqueou o Amigo[UID="
                            + (s.UserInfo.uid) + ", NICKNAME=" + (s.UserInfo.nickname) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // Resposta para o unblock friend REQUEST (0x30 / 0x10D)
                    p.init_plain(0x30);
                    p.Write((ushort)0x10D); // Sub packet Id
                    p.Write((uint)0);       // OK
                    p.Write((uint)s.UserInfo.uid);
                    _session.Send(p);

                    // Resposta para o unblock friend REQUESTED - Envia que o player está online (0x115)
                    p.init_plain(0x30);
                    p.Write((ushort)0x115); // Sub packet Id
                    p.Write((uint)_session.UserInfo.uid);
                    p.Write((uint)_session.UserInfo.m_state);
                    p.Write((byte)1);       // OK
                    p.WriteBytes(_session.UserInfo.m_cpi.ToArray());
                    s.Send(p);
                }
                else
                {   // Player está offline
                    var cmd_pi = new CmdPlayerInfo(uid);
                    snmdb.NormalManagerDB.getInstance().add(0, cmd_pi, null, null);

                    if (cmd_pi.getException().getCodeError() != 0)
                        throw cmd_pi.getException();

                    var pi = cmd_pi.getInfo();

                    if (pi.uid == 0)
                        throw new exception("[MessengerService::requestUnBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou desbloquear Amigo[UID="
                                + (uid) + "], mas o player nao existe. Hacker ou Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 5, 0x5300205));

                    var fm = new FriendManager(pi);
                    fm.init(pi);

                    if (!fm.isInitialized())
                        throw new exception("[MessengerService::requestUnBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou desbloquear Amigo[UID="
                                + (uid) + "], mas nao conseguiu inicializar Friend Manager do amigo. Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 6, 0x5300206));

                    if ((pFi2 = fm.findFriend(_session.UserInfo.uid)) == null)
                        throw new exception("[MessengerService::requestUnBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou desbloquear Amigo[UID="
                                + (uid) + "], mas o amigo nao tem ele na lista de amigos. Hacker ou Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 4, 0x5300204));

                    pFi.state.block = 0;

                    // UPDATE ON DB
                     _session.UserInfo.m_friend_manager.requestUpdateFriendInfo(pFi);
                        
                    // Log
                    _smp.message_pool.getInstance().push(new message("[UnBlockFriend][Log] player[UID=" + (_session.UserInfo.uid) + "] desbloqueou o Amigo[UID="
                            + (pi.uid) + ", NICKNAME=" + (pi.nickname) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    p.init_plain(0x30);
                    p.Write((ushort)0x10D);
                    p.Write((uint)0); // OK
                    p.Write((uint)pi.uid);
                    _session.Send(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[MessengerService::requestUnblockFriend][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x30);
                p.Write((ushort)0x10D);

                uint error_code = (ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) == (uint)STDA_ERROR_TYPE.MESSAGE_SERVER)
                                  ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                                  : 0x5300200;

                p.Write((uint)error_code);
                _session.Send(p);
            }
        }
    }
}
