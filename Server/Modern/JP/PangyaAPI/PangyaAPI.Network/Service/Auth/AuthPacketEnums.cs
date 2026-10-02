using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Service.Auth
{
    /// <summary>
    /// Pacotes que o Auth Server envia para o nosso Servidor (Login/Game)
    /// </summary>
    public enum AuthDispatcher//-> recebe do auth
    {
        FIRST_PACKET_KEY = 0x00,
        ASK_LOGIN_RESULT = 0x01,
        SHUTDOWN_SERVER = 0x02,
        BROADCAST_NOTICE = 0x03,
        BROADCAST_TICKER = 0x04,
        BROADCAST_CUBE_WIN = 0x05,
        DISCONNECT_PLAYER = 0x06,
        CONFIRM_DISCONNECT = 0x07,
        NEW_MAIL_ARRIVED = 0x08,
        NEW_RATE = 0x09,
        RELOAD_SYSTEM = 0x0A,
        INFO_PLAYER_ONLINE = 0x0B,
        CONFIRM_PLAYER_INFO = 0x0C,
        CMD_FROM_OTHER_SERVER = 0x0D,
        REPLY_FROM_OTHER_SERVER = 0x0E,
        RECV_KEEP_ALIVE = 0xFE
    } 

    public enum AuthClientDispatcher : ushort
    {
        AUTHENTIC_PLAYER = 0x01,
        REQUEST_DISCONNECT_PLAYER = 0x02,
        CONFIRM_DISCONNECT_PLAYER = 0x03,
        REQUEST_INFO_PLAYER = 0x04,
        CONFIRM_SEND_INFO_PLAYER = 0x05,
        SEND_COMMAND_TO_OTHER_SERVER = 0x06,
        SEND_REPLY_TO_OTHER_SERVER = 0x07, 
        SERVER_HEART = 0xFF
    }
}
