using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangya_MessengerServer.Flags
{
    public enum RoomFlags : int
    {
        STROKE,
        MATCH,
        LOUNGE,
        GAME_TYPE,
        TOURNEY,
        TOURNEY_TEAM,
        GUILD_BATTLE,
        PANG_BATTLE,
        GAME_TYPE_08,
        GAME_TYPE_09,//
        APPROCH,
        GRAND_ZODIAC_INT,// GM_EVENT = 0x0B,
        GAME_TYPE_12,
        GRAND_ZODIAC_ADV,
        GRAND_ZODIAC_PRACTICE,
        GAME_TYPE_15,
        GAME_TYPE_16,
        GAME_TYPE_17,
        SPECIAL_SHUFFLE_COURSE,
        PRACTICE,
        GRAND_PRIX,
        DEFAULT = -1
    }
}
