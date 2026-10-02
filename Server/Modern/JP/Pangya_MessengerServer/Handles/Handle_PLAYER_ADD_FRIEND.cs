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
    public class Handle_PLAYER_ADD_FRIEND : IPacketHandler<Player>
    {
        public const int FRIEND_LIST_LIMIT = 50;

        public async Task Handle(Player _session, Packet _packet)
        {
            var p = new Packet();

            try
            {
                uint uid = _packet.ReadUInt32();
                var nickname = _packet.ReadString();

                // Validações Iniciais
                if (uid == 0)
                    throw new exception($"[MessengerService::requestAddFriend][Error] player[UID={_session.UserInfo.uid}] tentou add Friend[UID={uid}], mas UID é inválido.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1, 0x5200601));

                if (string.IsNullOrEmpty(nickname))
                    throw new exception($"[MessengerService::requestAddFriend][Error] player[UID={_session.UserInfo.uid}] tentou add Friend[UID={uid}], mas Nickname está vazio.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 2, 0x5200602));

                var pFi = _session.UserInfo.m_friend_manager.findFriendInAllFriend(uid);

                if (pFi != null && pFi.flag._friend == 1)
                    throw new exception($"[MessengerService::requestAddFriend] Player[UID={_session.UserInfo.uid}] já é amigo de UID={uid}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 3, 2));

                if (_session.UserInfo.m_friend_manager.countFriend() >= FRIEND_LIST_LIMIT)
                    throw new exception($"[MessengerService::requestAddFriend] Lista cheia para UID={_session.UserInfo.uid}.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 4, 0x5200603));

                // Busca a sessão usando o Manager do ServerBase
                var s = MessengerServer.getInstance().FindSessionByUid(uid);

                FriendInfoEx fi = new FriendInfoEx();
                FriendInfoEx fi2 = new FriendInfoEx();

                if (s != null)
                {
                    // --- CASO: AMIGO ONLINE ---
                    if (!nickname.Equals(s.UserInfo.nickname, StringComparison.OrdinalIgnoreCase))
                        throw new exception("[MessengerService::requestAddFriend] Nickname não bate (Online).",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE, 7, 0x5200607));

                    if (s.UserInfo.m_friend_manager.countFriend() >= FRIEND_LIST_LIMIT)
                        throw new exception("[MessengerService::requestAddFriend] Lista do amigo está cheia.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 5, 3));

                    // Configura Info do Amigo (para quem adicionou)
                    fi.uid = s.UserInfo.uid;
                    fi.flag.ucFlag = (byte)((pFi == null) ? 1 : pFi.flag.ucFlag | 1);
                    fi.apelido = "Friend";
                    fi.nickname = s.UserInfo.nickname;
                    fi.state.online = 1;
                    fi.state.request_friend = 1;
                    fi.state.sex = s.UserInfo.sex;
                    fi.level = (byte)s.UserInfo.level;

                    // Configura Info de quem adicionou (para o amigo que recebeu)
                    fi2.uid = _session.UserInfo.uid;
                    fi2.flag.ucFlag = (byte)((pFi == null) ? 1 : pFi.flag.ucFlag | 1);
                    fi2.apelido = "Friend";
                    fi2.nickname = _session.UserInfo.nickname;
                    fi2.state.online = 1;
                    fi2.state.sex = _session.UserInfo.sex;
                    fi2.level = (byte)_session.UserInfo.level;

                    // Atualiza DB e Cache (Async) 
                    _session.UserInfo.m_friend_manager.requestAddFriend(fi);
                    s.UserInfo.m_friend_manager.requestAddFriend(fi2);

                    _smp.message_pool.getInstance().push(new message($"[AddFriend][Log] {_session.UserInfo.uid} adicionou {s.UserInfo.uid} (Online)", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // Resposta para quem enviou o convite (0x104)
                    p.init_plain(0x30);
                    p.Write((ushort)0x104);
                    p.Write((uint)0); // OK
                    p.WriteBytes(fi.ToArray());
                    p.WriteBytes(s.UserInfo.m_cpi.ToArray());
                    p.Write((byte)s.UserInfo.m_state);
                    p.Write((byte)fi.cUnknown_flag);
                    p.Write((byte)fi.level);
                    p.Write((byte)fi.state.ucState);
                    p.Write((byte)fi.flag.ucFlag);
                    _session.Send(p);

                    // Notifica o amigo que foi adicionado (0x106)
                    p.init_plain(0x30);
                    p.Write((ushort)0x106);
                    p.WriteBytes(fi2.ToArray());
                    p.WriteBytes(_session.UserInfo.m_cpi.ToArray());
                    p.Write((byte)_session.UserInfo.m_state);
                    p.Write((byte)fi2.cUnknown_flag);
                    p.Write((byte)fi2.level);
                    p.Write((byte)fi2.state.ucState);
                    p.Write((byte)fi2.flag.ucFlag);
                    s.Send(p);
                }
                else
                {
                    // --- CASO: AMIGO OFFLINE ---
                    var cmd_pi = new CmdPlayerInfo(uid);
                    snmdb.NormalManagerDB.getInstance().add(0, cmd_pi, null, null);

                    if (cmd_pi.getException().getCodeError() != 0) throw cmd_pi.getException();

                    var pi = cmd_pi.getInfo();
                    if (pi.uid == 0 || !nickname.Equals(pi.nickname, StringComparison.OrdinalIgnoreCase))
                        throw new exception("[MessengerService::requestAddFriend] Player não existe ou nick inválido (Offline).",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 6, 0x5200606));

                    var fm = new FriendManager(pi);
                    fm.init(pi);

                    if (fm.countFriend() >= FRIEND_LIST_LIMIT)
                        throw new exception("[MessengerService::requestAddFriend] Lista do amigo offline está cheia.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 5, 3));

                    fi.uid = pi.uid;
                    fi.flag.ucFlag = (byte)((pFi == null) ? 1 : pFi.flag.ucFlag | 1);
                    fi.nickname = pi.nickname;
                    fi.state.sex = pi.sex;
                    fi.level = (byte)pi.level;

                    fi2.uid = _session.UserInfo.uid;
                    fi2.flag.ucFlag = fi.flag.ucFlag;
                    fi2.nickname = _session.UserInfo.nickname;
                    fi2.state.sex = _session.UserInfo.sex;
                    fi2.level = (byte)_session.UserInfo.level;

                    _session.UserInfo.m_friend_manager.requestAddFriend(fi);
                    fm.requestAddFriend(fi2);

                    _smp.message_pool.getInstance().push(new message($"[AddFriend][Log] {_session.UserInfo.uid} adicionou {pi.uid} (Offline)", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // Resposta Offline (0x104) com campos zerados (-1) pois não há canal/sala
                    p.init_plain(0x30);
                    p.Write((ushort)0x104);
                    p.Write((uint)0);
                    p.WriteBytes(fi.ToArray());
                    p.Write((short)-1); // Sala
                    p.Write((int)-1);   // Tipo
                    p.Write((int)-1);   // Server GUID
                    p.Write((sbyte)-1); // Canal
                    p.WriteZero(64);    // Nome Canal
                    p.Write((byte)5);   // Status Offline
                    p.Write((byte)fi.cUnknown_flag);
                    p.Write((byte)fi.level);
                    p.Write((byte)fi.state.ucState);
                    p.Write((byte)fi.flag.ucFlag);
                    _session.Send(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[MessengerService::requestAddFriend][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x30);
                p.Write((ushort)0x104);
                uint err = (ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) == (uint)STDA_ERROR_TYPE.MESSAGE_SERVER)
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError()) : 0x5200600;
                p.Write((uint)err);
                _session.Send(p);
            }
        }
    }
}
