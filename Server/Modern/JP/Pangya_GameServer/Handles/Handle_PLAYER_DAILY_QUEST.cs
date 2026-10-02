using Pangya_GameServer.Feature;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_DAILY_QUEST : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                if (_packet == null)
                {
                    throw new exception("_packet is null", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.MGR_DAILY_QUEST,
                        2, 0));
                }


                var quest = GameServer.getInstance().DailyQuestsInfo;
                if (DailyQuestManager.CheckCurrentQuestUser(quest, _session))
                {
                    // Get Old Quest do player
                    var old_quest = DailyQuestManager.GetOldQuestUser(_session);

                    foreach (var el in old_quest)
                        _session.UserInfo.Achievements.removeAchievement(el.id);

                    // Add nova quest para o player
                    var v_ai = DailyQuestManager.NewQuestUser(quest, _session);

                    var p = new Packet(0x216);

                    p.WriteInt32((int)UtilTime.GetSystemTimeAsUnix());

                    // Achievement
                    if (v_ai.Count > 0)
                    {

                        p.WriteInt32(v_ai.Count);

                        foreach (var el in v_ai)
                        {
                            p.WriteByte(2);
                            p.WriteUInt32(el._typeid);//ta vindo id repetido
                            p.WriteInt32(el.id);//tá vindo idex repedito
                            p.WriteUInt32(0); // type
                            p.WriteInt32(0); // Qntd antes
                            p.WriteInt32(1); // Qntd depois
                            p.WriteInt32(1); // add value
                            p.WriteZero(25);
                        }
                    }
                    else
                    {
                        p.WriteUInt32(0u);
                    }
                    //send 216
                    _session.Send(p);
                    //send 225
                    _session.Send(Handle_PACKET_RESPONSE.pacote225(_session.UserInfo.DailyQuests, old_quest));

                }
                else
                {
                    var p = new Packet(0x216);
                    p.WriteUInt32((uint)UtilTime.GetSystemTimeAsUnix());
                    p.WriteInt32(0);
                    //send 216
                    _session.Send(p);
                    //send 225
                    _session.Send(Handle_PACKET_RESPONSE.pacote225(_session.UserInfo.DailyQuests, null));
                }

            }
            catch (exception e)
            {

                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_DAILY_QUEST][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}