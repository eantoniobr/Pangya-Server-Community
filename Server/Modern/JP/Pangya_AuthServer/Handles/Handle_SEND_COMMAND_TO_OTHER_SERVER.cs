using Pangya_AuthServer.Manager;
using Pangya_AuthServer.Server;
using Pangya_AuthServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pangya_AuthServer.Handles
{
    public class Handle_SEND_COMMAND_TO_OTHER_SERVER : IAuthPacketHandler<Player>
    {
        public async Task Handle(Player _session, Packet _packet)
        {
            try
            { 
                uint targetUidOrType = _packet.ReadUInt32();
                ushort commandId = _packet.ReadUInt16();

                // 2. Extrair o Payload (o que sobrou no pacote)
                int payloadSize = _packet.Size;
                byte[] commandData = null;

                if (payloadSize > 0)
                {
                    commandData = _packet.ReadBytes(payloadSize);
                }

                Console.WriteLine($"[Command Relay] Server {_session.UserInfo.uid} -> Alvo {targetUidOrType} | Cmd: {commandId}");

                // 3. Lógica de busca de destino (UID específico ou Tipo)
                var target = AuthServer.getInstance().FindPlayer(targetUidOrType);

                if (target != null)
                {
                    // Envia para um servidor específico (Unicast)
                    await SendRelay(target, _session.UserInfo.uid, commandId, commandData);
                }
                else
                {
                    // Se não achou por UID, tenta buscar todos do mesmo Tipo (Excluindo o remetente)
                    var serversOfType = AuthServer.getInstance().FindPlayerByTypeExcludeUID(targetUidOrType, _session.UserInfo.uid);

                    if (serversOfType != null && serversOfType.Count > 0)
                    {
                        // Envia para todos (Broadcast)
                        foreach (var srv in serversOfType)
                        {
                            await SendRelay(srv, _session.UserInfo.uid, commandId, commandData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[Command Warning] Alvo {targetUidOrType} não encontrado no sistema.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Command Error] Handle_SEND_COMMAND_TO_OTHER_SERVER: {ex.Message}");
            }
        }

        // Método auxiliar para evitar repetição de código (DRY)
        private async Task SendRelay(Player target, uint senderUid, ushort commandId, byte[] data)
        {
            using (var response = new Packet(0x0D)) // OpCode 0x0D para comandos
            {
                response.WriteUInt32(senderUid);
                response.WriteUInt16(commandId);

                if (data != null && data.Length > 0)
                {
                    response.WriteBytes(data);
                }
                else
                {
                    response.WriteUInt16(0); // Vazio
                }

                target.SendAuth(response);
            }
        }
    }
}