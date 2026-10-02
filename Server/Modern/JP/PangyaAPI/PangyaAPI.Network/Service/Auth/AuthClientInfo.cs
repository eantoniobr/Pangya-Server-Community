using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Service.Auth
{
    public class AuthClientInfo
    {
        /// <summary>
        /// Unique identifier of the player
        /// </summary>
        public uint PlayerId { get; set; }

        /// <summary>
        /// Username of the player
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// ID of the server where player is connected
        /// </summary>
        public uint ServerId { get; set; }

        /// <summary>
        /// Timestamp when player was authenticated
        /// </summary>
        public DateTime AuthenticatedAt { get; set; }

        /// <summary>
        /// Gets the duration of the current session
        /// </summary>
        public TimeSpan SessionDuration => DateTime.UtcNow - AuthenticatedAt;

        public override string ToString()
        {
            return $"{Username} (UID: {PlayerId}) on Server {ServerId}";
        }
    }
}
