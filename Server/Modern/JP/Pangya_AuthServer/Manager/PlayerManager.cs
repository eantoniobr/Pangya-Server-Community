using Pangya_AuthServer.Session;
using PangyaAPI.Network.Core;
using System.Net.Sockets;

namespace Pangya_AuthServer.Manager
{
    /// <summary>
    /// Manages player sessions connected to the authentication server
    /// </summary>
    public class PlayerManager : AppSessionManager<Player>
    {
        public PlayerManager(int maxUsers) : base(maxUsers)
        {
        }

        public List<Player> FindPlayerByType(uint _type)
        { 
            List<Player> v_p = new List<Player>();
            foreach (var el in base._sessions.Values)
            {
                if (el != null && el.GetCapability() == _type)
                {
                    v_p.Add(el);
                }
            } 

            return v_p;
        }

        public List<Player> GetAllPlayer()
        {
            return base._sessions.Values
                .OfType<Player>()
                .Where(p => p.Connected)
                .ToList();
        }

        public List<Player> FindPlayerByTypeExcludeUID(uint _type, uint _uid)
        {

            List<Player> v_p = new List<Player>();

            foreach (var el in base._sessions.Values)
            {
                if (el != null
                    && el.GetCapability() == _type
                    && el.GetUID() != _uid)
                {
                    v_p.Add(el);
                }
            }
            return v_p;
        }

        public Player FindPlayer(uint _uid, bool _oid)
        {
            Player _Player = null;

            foreach (var el in base._sessions.Values)
            {
                if (((!_oid) ? el.GetUID() : (uint)el.ConnectionID) == _uid)
                {
                    _Player = el;
                    break;
                }
            }

            return _Player;
        }
    }
}
