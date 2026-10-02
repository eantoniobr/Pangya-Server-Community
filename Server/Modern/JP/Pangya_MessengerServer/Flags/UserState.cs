using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_MessengerServer.Flags
{
    [Flags]
    public enum UserState : byte
    {
        None = 0,
        sex = 1 << 0, // Bit 0
        online = 1 << 1, // Bit 1
        _friend = 1 << 2, // Bit 2
        request_friend = 1 << 3, // Bit 3
        block = 1 << 4, // Bit 4
        play = 1 << 5, // Bit 5
        AFK = 1 << 6, // Bit 6
        busy = 1 << 7  // Bit 7
    }
}
