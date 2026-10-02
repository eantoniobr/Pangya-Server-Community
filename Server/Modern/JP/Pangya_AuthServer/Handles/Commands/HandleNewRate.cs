using Pangya_AuthServer.Feature;
using Pangya_AuthServer.Models;
using Pangya_AuthServer.Repository;
using Pangya_AuthServer.Server;
using PangyaAPI.Network;

namespace Pangya_AuthServer.Handles.Commands
{
    public class HandleNewRate : ICmdHandler
    {
        public async Task Execute(CommandInfo el)
        {
            var p = new Packet(0x09);
            p.WriteUInt32(el.arg[0]); // Tipo Rate
            p.WriteUInt32(el.arg[1]); // Amount

            await CommandSender.SendToTarget(el, p);
        }
    }
}