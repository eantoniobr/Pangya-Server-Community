using Pangya_GameServer.Engine;
using Pangya_GameServer.Feature;
using Pangya_GameServer.Flags;
using Pangya_GameServer.Manager;
using Pangya_GameServer.Models;
using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.IFF.Flags;
using PangyaAPI.IFF.Handle.JP;
using PangyaAPI.IFF.Regions.JP.Models.Generic;
using PangyaAPI.IFF.Regions.JP.Models.IFF;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using snmdb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pangya_GameServer.Models.DefineConstants;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_SYNC_ACTION_GAME : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                var r = _session.GetRoom();

                if (r == null)
                    throw new exception("[Handle_PLAYER_SYNC_ACTION_GAME][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + " ] tentou trocar localizacao na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas ela nao existe. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                           10, 0));

                TPLAYER_ACTION type = (TPLAYER_ACTION)_packet.ReadByte();

                var p = new Packet(0xC4); 
                p.WriteInt32(_session.ConnectionID);
                p.WriteByte(type); 
                switch (type)
                {
                    case TPLAYER_ACTION.PLAYER_ACTION_ROTATION: // R - Face
                        {
                            _session.UserInfo.CurrentLocation.r = _packet.ReadFloat();//W

                            p.WriteFloat(_session.UserInfo.CurrentLocation.r); 
                            break;
                        }
                    case TPLAYER_ACTION.PLAYER_ACTION_MOTION_ROOM: // Motion In Room
                        {
                            _session.UserInfo.ChatSpecial = _packet.Message; 
                             
                            p.WriteBytes(_session.UserInfo.ChatSpecial); 
                            break;
                        }
                    case TPLAYER_ACTION.PLAYER_ACTION_LOUNGER_LOC: // X Z R, coordenada inicial do player no lounge
                        {
                            var location_add = new PlayerRoomInfo.stLocation().ToRead(_packet);

                            _session.UserInfo.CurrentLocation.x += location_add.x;
                            _session.UserInfo.CurrentLocation.z += location_add.z;
                            _session.UserInfo.CurrentLocation.y += location_add.y;  
                            p.WriteBytes(location_add.ToArray()); 
                            break;
                        }
                    case TPLAYER_ACTION.PLAYER_ACTION_LOUNGER_STATE: // Estado do player na sala, se o player esta sentado, deitado ou em pé
                        {
                            _session.UserInfo.PostureRoom = _packet.ReadUInt32(); 
                            p.WriteUInt32(_session.UserInfo.PostureRoom);
                            break;
                        }
                    case TPLAYER_ACTION.PLAYER_ACTION_MOVE: // Player está andando no lounge, X, Z, R
                        {
                            var location_add = new PlayerRoomInfo.stLocation().ToRead(_packet);

                            _session.UserInfo.CurrentLocation.x += location_add.x;
                            _session.UserInfo.CurrentLocation.z += location_add.z;
                            _session.UserInfo.CurrentLocation.y += location_add.y; 
                            p.WriteBytes(location_add.ToArray()); 
                            break;
                        }
                    case TPLAYER_ACTION.PLAYER_ACTION_MOTION_LOUNGER: // Motion no lounge
                        {
                            _session.UserInfo.ChatSpecial = _packet.Message; 
                            p.WriteBytes(_session.UserInfo.ChatSpecial); 
                            break;
                        }
                    case TPLAYER_ACTION.PLAYER_ACTION_ACK_PLAYER: // Estado do player de icon no lounge
                        {
                            _session.UserInfo.LoungeState = _packet.ReadUInt32(); 
                            p.WriteUInt32(_session.UserInfo.LoungeState); 
                            break;
                        }
                    case TPLAYER_ACTION.PLAYER_ANIMATION_WITH_EFFECTS: // Motion no lounge de item especial
                        {
                            _session.UserInfo.ChatSpecial = _packet.Message; 
                            p.WriteBytes(_session.UserInfo.ChatSpecial); 
                            break;
                        }
                    default:
                        throw new exception("[Handle_PLAYER_PLAYER_LOCATION_ROOM][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + " ] tentou trocar localizacao na sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas o type desconhecido. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                            11, 0));
                } 
                r.UpdatePlayerInfo(_session);
                r.SendBroadCast(p);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[Handle_PLAYER_PLAYER_LOCATION_ROOM][ErrorSystem] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + " ] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }
    }
}