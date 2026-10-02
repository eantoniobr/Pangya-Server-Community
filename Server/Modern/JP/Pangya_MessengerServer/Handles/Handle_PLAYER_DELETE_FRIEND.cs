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
    public class Handle_PLAYER_DELETE_FRIEND : IPacketHandler<Player>//<Packet_PLAYER_DELETE_FRIEND, MPlayer>
    {

        public async Task Handle(Player _session, Packet _packet)
        {
            // REQUEST_BEGIN("DeleteFriend");
            var p = new Packet();

            try
            {
                uint uid = _packet.ReadUInt32();
                var nickname = _packet.ReadString();

                // Validações de integridade
                if (uid == 0)
                    throw new exception($"Player[UID={_session.UserInfo.uid}] tentou deletar UID={uid}, mas UID é inválido.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 1, 0x5200701));

                if (string.IsNullOrEmpty(nickname))
                    throw new exception($"Player[UID={_session.UserInfo.uid}] tentou deletar UID={uid}, mas Nickname está vazio.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 2, 0x5200702));

                // Busca o amigo na lista local do player
                var pFi = _session.UserInfo.m_friend_manager.findFriend(uid);

                if (pFi == null)
                    throw new exception($"Player[UID={_session.UserInfo.uid}] tentou deletar UID={uid}, mas não são amigos.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 3, 0x5200703));

                // Tenta encontrar a sessão ativa do alvo
                var s = MessengerServer.getInstance().FindSessionByUid(uid);

                FriendInfoEx pFi2 = null;

                if (s != null)
                {
                    // --- CASO: AMIGO ONLINE ---
                    if (!nickname.Equals(s.UserInfo.nickname, StringComparison.OrdinalIgnoreCase))
                        throw new exception($"Nickname não bate para o amigo online UID={uid}.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE, 6, 0x5200705));

                    if ((pFi2 = s.UserInfo.m_friend_manager.findFriend(_session.UserInfo.uid)) == null)
                        throw new exception($"Inconsistência: Player não está na lista do amigo UID={uid}.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE, 4, 0x5200704));

                    // Remove de ambos os managers e sincroniza com o DB (Async)
                  
                        _session.UserInfo.m_friend_manager.requestDeleteFriend(pFi);
                        s.UserInfo.m_friend_manager.requestDeleteFriend(pFi2); 

                    _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_DELETE_FRIEND][Log] {_session.UserInfo.uid} removeu {s.UserInfo.uid} (Online)", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // Resposta para quem deletou
                    p.init_plain(0x30);
                    p.Write((ushort)0x10B);
                    p.Write((uint)0); // OK
                    p.Write((uint)s.UserInfo.uid);
                    _session.Send(p);

                    // Resposta para quem FOI deletado (remove da lista dele em tempo real)
                    p.init_plain(0x30);
                    p.Write((ushort)0x10B);
                    p.Write((uint)0); // OK
                    p.Write((uint)_session.UserInfo.uid);
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
                        throw new exception("Player offline inválido ou nick não bate.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 5, 0x5200705));

                    var fm = new FriendManager(pi);
                    fm.init(pi);

                    if (!fm.isInitialized())
                        throw new exception("Erro ao carregar FriendManager offline.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE_SERVER, 7, 0x5200707));

                    if ((pFi2 = fm.findFriend(_session.UserInfo.uid)) == null)
                        throw new exception("Player não consta na lista offline do amigo.",
                            ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MESSAGE, 8, 0x5200708));

                    _session.UserInfo.m_friend_manager.requestDeleteFriend(pFi);
                    fm.requestDeleteFriend(pFi2);

                    _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_DELETE_FRIEND][Log] {_session.UserInfo.uid} removeu {pi.uid} (Offline)", type_msg.CL_FILE_LOG_AND_CONSOLE));

                    // Resposta para o solicitante
                    p.init_plain(0x30);
                    p.Write((ushort)0x10B);
                    p.Write((uint)0);
                    p.Write((uint)pi.uid);
                    _session.Send(p);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_DELETE_FRIEND][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                p.init_plain(0x30);
                p.Write((ushort)0x10B);
                uint err = (ExceptionError.STDA_SOURCE_ERROR_DECODE(e.getCodeError()) == (uint)STDA_ERROR_TYPE.MESSAGE_SERVER)
                    ? ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError()) : 0x5200700;
                p.Write((uint)err);
                _session.Send(p);
            }
        }
    }
}
