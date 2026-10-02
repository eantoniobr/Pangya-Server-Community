using Pangya_GameServer.PacketFunc;
using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Network.Repository;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using PangyaAPI.Utilities.Models;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_CONNECT_MSNSERVER : IPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            {
                // 1. Validação de bloqueio
                if (_session.UserInfo.block_flag.m_flag.rank_server)//tenho que fazer o messenger
                {
                    throw new exception($"[UID={_session.UserInfo.uid}] Jogador bloqueado para MSN Server.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 7010, 0));
                }

                // 2. Busca servidor no DB 
                var serverList = DBCommand.GetMsn();

                // 3. Verifica disponibilidade
                if (serverList == null || serverList.Count == 0)
                {
                    throw new exception($"[UID={_session.UserInfo.uid}] Requisitou MSN Server, mas nenhum está online no DB.",
                        ExceptionError.STDA_MAKE_ERROR_TYPE(STDA_ERROR_TYPE.GAME_SERVER, 7011, 0));
                }

                // 4. Envio de sucesso (conecta ao primeiro disponível)  
                _session.Send(Handle_PACKET_RESPONSE.pacote0FC(serverList));
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message($"[Handle_PLAYER_CONNECT_MSNSERVER][Error] {e.getFullMessageError()}", type_msg.CL_FILE_LOG_AND_CONSOLE));
                var p = new Packet(0xFC);
                p.WriteByte((byte)0); 
                _session.Send(p);
            }
        }
    }
}