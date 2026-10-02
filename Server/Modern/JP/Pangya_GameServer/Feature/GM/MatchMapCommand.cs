using Pangya_GameServer.Flags;
using Pangya_GameServer.Repository;
using Pangya_GameServer.Server;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Pangya_GameServer.Manager.TradeShopManager;

namespace Pangya_GameServer.Feature.GM
{
    public class MatchMapCommand : IGMCommand
    {

        public async Task Execute(Player session, Packet pkt)
        {
            try
            {
                var Map = pkt.ReadInt32();
                var room = session.GetRoom();
                 
                _smp.message_pool.getInstance().push(new message(
                    $"[GM-Action] Executor: {session.UserInfo.nickname} (UID: {session.UserInfo.uid}) | Command: MatchCourse | Value: {Map}",
                    type_msg.CL_ONLY_CONSOLE));

                // 3. Validação de Estado
                if (room == null || room.GameRun())//jogo esta em percuso, nao pode editar.
                {
                    session.SendChatNotice("This needs to be in a room first.");
                    // Opcional: Enviar mensagem ao player dizendo que ele precisa estar em uma sala
                    return;
                }

                // 4. Lógica de Negócio
                if (Enum.IsDefined(typeof(ROOM_INFO_COURSE), (ROOM_INFO_COURSE)Map))
                {
                    room.SetCourse((byte)Map);
                    room.SendHeadRoom();
                    GameServer.getInstance().sendUpdateRoomInfo(room, 3);
                    _smp.message_pool.getInstance().push(new message($"[MatchCourseCommand][Sucess] ROOM[ID: {room.GetRoomId()}, UPDATE: {(ROOM_INFO_COURSE)Map}, NICK: {session.UserInfo.nickname}]", type_msg.CL_FILE_LOG_AND_CONSOLE));
                }
            }
            catch (Exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[MatchCourseCommand][Error] {e.Message} | StackTrace: {e.StackTrace}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

            await Task.CompletedTask;
        }
    }
}