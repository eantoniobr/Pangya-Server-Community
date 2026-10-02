using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CHAT : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            var m_ci = _session.GetChannel();
            try
            {
                string nickname = _packet.ReadPStr();
                string msg = _packet.ReadPStr();

                if (string.IsNullOrEmpty(nickname))
                    throw new exception(" PLAYER[UID=" + (_session.UserInfo.uid) + "] tentou enviar msg[MESSAGE="
                            + nickname + "], vazio. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

                if (!Tools.Sanitize(nickname))
                    throw new exception(" PLAYER[UID=" + (_session.UserInfo.uid) + "] tentou enviar msg[MESSAGE="
                            + nickname + "], tentativa de inject. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

                if (string.IsNullOrEmpty(msg))
                    throw new exception(" PLAYER[UID=" + (_session.UserInfo.uid) + "] tentou enviar msg[MESSAGE="
                            + msg + "], vazio. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 1, 1/*UNKNOWN ERROR*/));

                if (m_ci != null)
                {
                    var gmList = GameServer.getInstance().FindAllGM();

                    if (gmList.Any())
                    {
                        string msg_gm = "\\5" + _session.UserInfo.nickname + ": '" + msg + "'";
                        string from = "\\1[Channel=" + m_ci.getName() + ", \\1ROOM=" + _session.UserInfo.Member.sala_numero + "]";

                        int index = from.IndexOf(' ');
                        if (index != -1)
                            from = from.Substring(0, index) + " \\1" + from.Substring(index + 1);

                        foreach (Player el in gmList)
                        {
                            if (((el.m_gi.channel > 0 && el.UserInfo.Channel == m_ci.getId()) || el.m_gi.whisper.IsTrue() || el.m_gi.isOpenPlayerWhisper(_session.UserInfo.uid))
                                && (el.UserInfo.Channel != _session.UserInfo.Channel || el.UserInfo.Member.sala_numero != _session.UserInfo.Member.sala_numero))
                            {
                                el.Send(Handle_PACKET_RESPONSE.pacote040(from, msg_gm, 0));
                            }
                        }
                    }

                    // 5. Executa comandos e envia a mensagem para sala ou lobby
                    var comando = new Queue<string>(msg.Split(' '));

                    if (_session.UserInfo.Member.sala_numero != -1)
                    {
                        var r = _session.GetRoom();

                        r?.SendBroadCast(Handle_PACKET_RESPONSE.pacote040(_session.UserInfo.nickname, msg, ((_session.UserInfo.UserCapabilities.game_master) ? eChatMsg.CHAT_GM : 0)));
                    }
                    else
                    {
                        var flag = _session.UserInfo.UserCapabilities.game_master ? eChatMsg.CHAT_GM : 0;
                        m_ci.SendBroadcast(Handle_PACKET_RESPONSE.pacote040(_session.UserInfo.nickname, msg, flag));
                    }
                    if (_session.UserInfo.UserCapabilities.game_master)
                        m_ci.CommandByChat(_session, comando);
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_CHAT][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}
