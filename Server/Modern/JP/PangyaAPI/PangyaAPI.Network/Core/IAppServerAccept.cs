using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Core
{
    public interface IAppServerAccept
    {
        Task StartAsync(CancellationToken token);
        void Stop();
    }
}
