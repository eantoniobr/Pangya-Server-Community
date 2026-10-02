using Pangya_RankingServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;

namespace Pangya_RankingServer.Handles
{
    public class Handle_DUMMY : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet packet)
        {
            int opcode = packet.Type;
            uint uid = session.UserInfo?.uid ?? 0;

            // Log detalhado para análise posterior no console/arquivo
            _smp.message_pool.getInstance().push(new message(
                $"[Handle_DUMMY][Log] Pacote 0x{opcode:X2} recebido de Player[UID={uid}]. " +
                $"Tamanho: {packet.GetBytesReader().HexDump()} bytes. Lógica de resposta ainda não implementada.",
                type_msg.CL_FILE_LOG_AND_CONSOLE));

            // Opcional: Se você quiser ver o conteúdo bruto (Hex) no log, 
            // pode implementar um helper packet.ToHexString() aqui.

            await Task.CompletedTask;
        }
    }
}