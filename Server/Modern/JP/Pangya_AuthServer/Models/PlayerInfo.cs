using PangyaAPI.Network.Models;

namespace Pangya_AuthServer.Models
{
    public class CommandInfo
    {
        public CommandInfo(uint _ul = 0u)
        {

        } 
        public string toString()
        {
            return "IDX=" + Convert.ToString(idx) + ", ID=" + Convert.ToString(id) + ", ARG1=" + Convert.ToString(arg[0]) + ", ARG2=" + Convert.ToString(arg[1]) + ", ARG3=" + Convert.ToString(arg[2]) + ", ARG4=" + Convert.ToString(arg[3]) + ", ARG5=" + Convert.ToString(arg[4]) + ", TARGET=" + Convert.ToString(target) + ", FLAG=" + Convert.ToString(flag) + ", VALID=" + Convert.ToString((ushort)valid) + ", RESERVEDATE=" + Convert.ToString(reserveDate);
        }
        public uint idx { get; set; }
        public uint id { get; set; }
        public uint[] arg { get; set; } = new uint[5];
        public uint target { get; set; }
        public ushort flag { get; set; }
        public byte valid = 1;
        public DateTime reserveDate { get; set; } = DateTime.Now;
    }

    public enum COMMAND_ID : uint
    {
        BROADCAST_NOTICE,
        BROADCAST_TICKER,
        BROADCAST_CUBE_WIN,
        SHUTDOWN,
        NEW_ITEM_NOTICE,
        NEW_RATE,
        ADM_KICK_FROM_WEBSITE,
        RELOAD_SYSTEM
    }

    public class TickerInfo
    {
        public TickerInfo()
        {
            nick = "";
            msg = "";
        }
        
        public bool isValid()
        {
            return (!(msg.Length == 0) && !(nick.Length == 0));
        }
        public string nick { get; set; } = "";
        public string msg { get; set; } = "";
    }

    /// <summary>
    /// Tracks authenticated player sessions on the Auth Server
    /// </summary>
    public class PlayerInfo : PlayerInfoBase
    { 
        public uint tipo { get; set; } 
    }
}
