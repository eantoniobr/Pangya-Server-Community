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
    public class Handle_PLAYER_BLOCK_FRIEND : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        { 
            var p = new Packet();

            try
            {
                uint uid = _packet.ReadUInt32(); 
                if (uid == 0)
                    throw new exception("[MessengerService::requestBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou bloqueiar Amigo[UID="
                            + (uid) + "], mas o uid is invalid(zero). Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1, 0x5300101));

                var pFi = _session.UserInfo.m_friend_manager.findFriend(uid);

                if (pFi == null)
                    throw new exception("[MessengerService::requestBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou bloqueiar Amigo[UID="
                        + (uid) + "], mas o player nao eh amigo dele. Hacker ou Bug",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 2, 0x5300102));

                if (pFi.state.block == 1)
                    throw new exception("[MessengerService::requestBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou bloqueiar Amigo[UID="
                            + (uid) + "], mas o amigo ja esta bloqueado. Hacker ou Bug",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 3, 0x5300103));

                var s = MessengerServer.getInstance().FindSessionByUid(uid);

                FriendInfoEx pFi2 = null;

                if (s != null)
                {   // Player está online
                    if ((pFi2 = s.UserInfo.m_friend_manager.findFriend(_session.UserInfo.uid)) == null)
                        throw new exception("[MessengerService::requestBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou bloqueiar Amigo[UID="
                                + (uid) + "], mas o amigo nao tem ele na lista de amigos. Hacker ou Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 4, 0x5300104));

                    // Atualiza estado no servidor
                    pFi.state.block = 1;

                    // UPDATE ON DB
                    _session.UserInfo.m_friend_manager.requestUpdateFriendInfo(pFi);

                    // Log
                    _smp.message_pool.getInstance().push(new message("[BlockFriend][Log] player[UID=" + (_session.UserInfo.uid) + "] bloqueou o Amigo[UID="
                            + (s.UserInfo.uid) + ", NICKNAME=" + (s.UserInfo.nickname) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // Resposta para o block friend REQUEST (0x30 / 0x10C)
                    p.init_plain(0x30);
                    p.Write((ushort)0x10C); // Sub packet Id
                    p.Write((uint)0);       // OK
                    p.Write((uint)s.UserInfo.uid);
                    _session.Send(p);

                    // Resposta para o amigo bloqueado (Envia que o player deslogou/bloqueou 0x10F)
                    p.init_plain(0x30);
                    p.Write((ushort)0x10F); // Sub packet Id
                    p.Write((uint)_session.UserInfo.uid);
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
                        throw new exception("[MessengerService::requestBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou bloqueiar Amigo[UID="
                                + (uid) + "], mas player nao existe. Hacker ou Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 5, 0x5300105));

                    var fm = new FriendManager(pi);
                    fm.init(pi);

                    if (!fm.isInitialized())
                        throw new exception("[MessengerService::requestBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou bloqueiar Amigo[UID="
                                + (uid) + "], nao conseguiu inicializar Friend Manager do amigo. Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 6, 0x5300106));

                    if ((pFi2 = fm.findFriend(_session.UserInfo.uid)) == null)
                        throw new exception("[MessengerService::requestBlockFriend][Error] player[UID=" + (_session.UserInfo.uid) + "] tentou bloqueiar Amigo[UID="
                                + (uid) + "], mas o amigo nao tem ele na lista de amigos. Hacker ou Bug",
                                ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 4, 0x5300104));

                    pFi.state.block = 1;

                    // UPDATE ON DB
                    _session.UserInfo.m_friend_manager.requestUpdateFriendInfo(pFi);

                    // Log
                    _smp.message_pool.getInstance().push(new message("[BlockFriend][Log] player[UID=" + (_session.UserInfo.uid) + "] bloqueou o Amigo[UID="
                            + (pi.uid) + ", NICKNAME=" + (pi.nickname) + "]", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    p.init_plain(0x30);
                    p.Write((ushort)0x10C);
                    p.Write((uint)0); // OK
                    p.Write((uint)pi.uid);
                    _session.Send(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[MessengerService::requestBlockFriend][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x30);
                p.Write((ushort)0x10C);

                uint error_code = (ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) == (uint)STDA_ERROR_TYPE.MESSAGE_SERVER)
                                  ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError())
                                  : 0x5300100;

                p.Write((uint)error_code);
                _session.Send(p);
            }
        }
    }
}
