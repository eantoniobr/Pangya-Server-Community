using System;
using System.Threading.Tasks;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_EXEC_CCG_DESTROY : HandleBase<Player, Packet_EXAMPLE>
    {
        public override async Task Handle()
        {
            var m_ci = Player.GetChannel();
            try
            {
                if (Player.UserInfo.UserCapabilities.game_master)
                {
                    short sala_numero = Packet.ReadInt16();

                    var r = GameServer.getInstance().FindRoom(sala_numero);

                    if (r == null)
                    {
                        throw new exception("[Lobby.Room::RequestExecCCGDestroy][Error] PLAYER [UID=" + Player.UserInfo.uid + "] tentou executar o comando destroy, para destruir a sala[NUMERO=" + (sala_numero) + "], mas a sala nao existe.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 16, 0x5700100));
                    }

                    if (m_ci.Sessions.Count == 0)
                    {
                        var ri = r.GetInfo();
                        GameServer.getInstance().DestroyRoom(r);
                    }
                    else
                    {
                        foreach (var el in m_ci.Sessions)
                        {
                            m_ci.Lobby.KickPlayerRoom(el, 0);
                        }
                    }

                    _smp.message_pool.getInstance().push(new message("[Lobby.Room::RequestExecCCGDestroy][Sucess] PLAYER [UID=" + Player.UserInfo.uid + "] destruiu a sala[NUMERO=" + (sala_numero) + "] no canal[NOME=" + (m_ci.getName()) + "].", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
                else
                {
                    throw new exception("[Lobby.Room::RequestExecCCGDestroy][Error] PLAYER [UID=" + Player.UserInfo.uid + "] nao tem a capacidade de um GM. hacker ou bug.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL, 17, 0x5700101));
                }
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Lobby.Room::RequestExecCCGDestroy][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));

                Packet p = new Packet((ushort)0x40);
                p.WriteByte(7);
                p.WriteString(Player.UserInfo.nickname);
                p.WriteString("Nao conseguiu executar o comando.");

                Player.Send(p);
            }
            await Task.CompletedTask;
        }
    }
}