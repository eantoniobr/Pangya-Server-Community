using Pangya_AuthServer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_AuthServer.Handles.Commands
{
    public interface ICmdHandler
    {
        Task Execute(CommandInfo el);
    }
}
