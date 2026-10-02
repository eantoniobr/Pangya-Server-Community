using Pangya_GameServer.Channels;
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
using PangyaAPI.Network.Session;
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
    public class Handle_PLAYER_KICK_PLAYER_OF_ROOM : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                uint uid = _packet.ReadUInt32();

                var r = _session.GetRoom();

                if (r == null)
                {
                    throw new exception("[Handle_PLAYER_KICK_PLAYER_OF_ROOM][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou chutar um PLAYER [UID=" + (uid) + "] da sala[NUMERO=" + (_session.UserInfo.Member.sala_numero) + "], mas sala nao existe. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        10, 0));
                }

                if (r.GetMaster() != _session.UserInfo.uid)
                {
                    throw new exception("[Handle_PLAYER_KICK_PLAYER_OF_ROOM][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou chutar um PLAYER [UID=" + (uid) + "] da sala[NUMERO=" + r.GetRoomId() + "], mas o player nao é master da sala para poder chutar(kick) o player. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        11, 0));
                }

                // Se não for GM, não pode kikar o player da sala com jogo em andamento
                if (!_session.UserInfo.UserCapabilities.game_master && r.CurrentGame != null)
                {
                    throw new exception("[Handle_PLAYER_KICK_PLAYER_OF_ROOM][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou chutar um PLAYER [UID=" + (uid) + "] da sala[NUMERO=" + r.GetRoomId() + "], mas o player é GM para poder chutar o player da sala com o jogo em andamento.", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        13, 0));
                }

                var _sessionKick = r.FindSessionByOid(uid);

                if (_sessionKick == null)
                {
                    throw new exception("[Handle_PLAYER_KICK_PLAYER_OF_ROOM][Error] PLAYER[UID= " + _session.UserInfo.uid + ", ID: " + _session.UserInfo.id + "] tentou chutar um PLAYER [UID=" + (uid) + "] da sala[NUMERO=" + r.GetRoomId() + "], mas o player nao existe na sala. Hacker ou Bug", ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.CHANNEL,
                        12, 0));
                }

                if (_sessionKick.UserInfo.uid == _session.UserInfo.uid)
                {
                    // Enviamos um aviso para o chat do próprio GM em vez de dar erro fatal
                    _session.SendChatNotice("no executed, other player");

                    _smp.message_pool.getInstance().push(new message(
                        $"[Handle_PLAYER_KICK_FROM_ROOM][Warning] GM {_session.UserInfo.nickname} tentou se auto-desconectar (Bloqueado).",
                        type_msg.CL_FILE_LOG_AND_CONSOLE));

                    return; // Interrompe a execução aqui
                }

                // Player precisa do pacote para sair da sala
                // Não precisa verifica se é Grand Prix o multiplayer,
                // o pacote do multiplayer serve para kikar o player da sala. O pacote do GP no GP buga
                // Nota: Assumindo que LeaveRoomMultiPlayer esteja acessível via contexto ou classe estática correspondente
                _sessionKick.GetChannel().LeaveRoomMultiPlayer(_sessionKick, 3);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message("[channel:Handle_PLAYER_KICK_PLAYER_OF_ROOM][ErrorSystem] " + e.getFullMessageError(), type_msg.CL_FILE_LOG_AND_CONSOLE));
            }

        await Task.CompletedTask;
        }
    }
}