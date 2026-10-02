using System;
using System.Threading.Tasks;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Threading.Tasks;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_INVITE : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            Packet p = new Packet();
            var m_ci = _session.GetChannel();
            try
            {
                string nickname = _packet.ReadString();
                uint uid = _packet.ReadUInt32();

                var s = GameServer.getInstance().FindSessionByNickname(nickname);

                if (s == null || s.UserInfo.uid != uid)
                {
                    throw new exception("[Lobby.Room::RequestInvite][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou convidar o PLAYER [UID=" + (uid) + ", NICKNAME=" + nickname + "] para Sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas o player nao esta nesse canal. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        3000, 23));
                }

                if (s.UserInfo.Member.sala_numero != -1)
                {
                    throw new exception("[Lobby.Room::RequestInvite][Warning] PLAYER [UID=" + _session.UserInfo.uid + "] tentou convidar o PLAYER [UID=" + (uid) + ", NICKNAME=" + nickname + "] para Sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas o player ja esta em outra sala.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        3002, 23));
                }

                if (s.UserInfo.Place != 0)
                {
                    throw new exception("[Lobby.Room::RequestInvite][Warning] PLAYER [UID=" + _session.UserInfo.uid + "] tentou convidar o PLAYER [UID=" + (uid) + ", NICKNAME=" + nickname + "] para Sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas o player nao pode ser convidado no momento.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        3002, 23));
                }

                var r = _session.GetRoom();

                if (r == null)
                {
                    throw new exception("[Lobby.Room::RequestInvite][Error] PLAYER [UID=" + _session.UserInfo.uid + "] tentou convidar o PLAYER [UID=" + (uid) + ", NICKNAME=" + nickname + "] para Sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ele nao esta em nenhuma sala para poder convidar. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        3001, 23));
                }

                var ici = r.AddInvited(_session.UserInfo.uid, s);

                m_ci.AddInviteTimeRequest(ici);
                m_ci.Lobby.SendUpdateRoomInfo(r.GetInfo(), 3);

                // Resposta Invite Player
                p.init_plain(0x12F);
                p.WriteUInt16(0); // Ok
                p.WriteUInt32(GameServer.getInstance().getUID());
                p.WriteByte(m_ci.getId());
                p.WriteInt16(r.GetRoomId());
                p.WriteUInt32(_session.UserInfo.uid);
                p.WriteString(_session.UserInfo.nickname);
                p.WriteUInt32(s.UserInfo.uid);

                _session.Send(p);

                // Envia o Convite para o player
                p.init_plain(0x83);
                p.WriteUInt16(0); // OK
                p.WriteUInt32(GameServer.getInstance().getUID());
                p.WriteByte(m_ci.getId());
                p.WriteInt16(r.GetRoomId());
                p.WriteUInt32(_session.UserInfo.uid);
                p.WriteString(_session.UserInfo.nickname);
                p.WriteUInt32(s.UserInfo.uid);

                s.Send(p);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Lobby.Room::RequestInvite][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                // Resposta Error
                p.init_plain(0x12F);
                p.WriteUInt16((ExceptionError.STDA_SOURCE_ERROR_DECODE_TYPE(e.getCodeError()) == STDA_ERROR_TYPE.CHANNEL) ? (ushort)ExceptionError.STDA_SYSTEM_ERROR_DECODE(e.getCodeError()) : (ushort)23);
                _session.Send(p);
            }

        await Task.CompletedTask;
        }
    }
}