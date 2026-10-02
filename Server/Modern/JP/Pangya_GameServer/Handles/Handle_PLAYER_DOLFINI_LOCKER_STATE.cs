using Pangya_GameServer.Session;
using PangyaAPI.Network;
using PangyaAPI.Network.Core;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.Log;
using System;
using System.Threading.Tasks;

namespace Pangya_GameServer.Handles
{
    public class Handle_PLAYER_DOLFINI_LOCKER_STATE : IPacketHandler<Player>
    {
        public async Task Handle(Player session, Packet pkt)
        {
            try
            {
                var p = new Packet(0x170);
                p.WriteUInt32(0);         // Option (Geralmente 0 para consulta simples)
                p.WriteUInt32(session.Inventory.DolfineLocker.isLocker()); // Estado: 1 = Ativo / 0 = Inativo 
                session.Send(p);
            }
            catch (exception e)
            {
                _smp.message_pool.getInstance().push(new message(
                    $"[Handle_PLAYER_DOLFINI_LOCKER_STATE][Error] {e.getFullMessageError()}",
                    type_msg.CL_FILE_LOG_AND_CONSOLE)
                );

                // Em caso de erro, enviamos 0 para não habilitar o botão indevidamente
                var errorPkt = new Packet(0x170);
                errorPkt.WriteUInt32(0);
                errorPkt.WriteUInt32(0);
                session.Send(errorPkt);
            }

        await Task.CompletedTask;
        }
    }
}