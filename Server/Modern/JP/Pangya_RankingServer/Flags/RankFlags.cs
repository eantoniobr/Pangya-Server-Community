using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_RankingServer.Flags
{
    public enum RankMenuFlags
    {
        RM_OVERALL,
        RM_COURSE_RECORDS,
        RM_RECORDS,
        RM_COURSE_RECORDS_NATURAL,
        RM_COURSE_RECORDS_GRAND_PRIX
    }

    public enum Rank_Type : byte
    {
        RO_TOTAL_POINTS,
        RO_TOTAL_SCORE,
        RO_TROPHY_POINTS,
        RO_PANG_EARNED,
        RO_TOTAL_HOLES,
        RO_ACHIEVEMENT_POINTS
    }

    public enum Courses : byte
    {
        RCR_BLUE_LAGOON,
        RCR_BLUE_WATER,
        RCR_SEPIA_WIND,
        RCR_WIND_HILL,
        RCR_WIZ_WIZ,
        RCR_WEST_WIZ,
        RCR_BLUE_MOON,
        RCR_SILVIA_CANNON,
        RCR_ICE_CANNON,
        RCR_WHITE_WIZ,
        RCR_SHINNING_SAND,
        RCR_PINK_WIND,
        RCR_DEEP_INFERNO,
        RCR_ICE_SPA,
        RCR_LOST_SEAWAY,
        RCR_EASTERN_VALLEY,
        RCR_ICE_INFERNO,
        RCR_WIZ_CITY,
        RCR_ABBOT_MINE,
        RCR_MYSTIC_RUINS
    }

    public enum Rank_Records : byte
    {
        RR_ALBATROSS,
        RR_HOLE_IN_ONE,
        RR_LEVEL = 3,
        RR_TOTAL_DISTANCE
    }

    public enum Player_Pos_Rank_Type : byte
    {
        PPRT_IN_TOP_RANK, // Tem registro e est� no top rank
        PPRT_NOT_RANK, // N�o tem registro
        PPRT_NOT_TOP_RANK // Tem registro mas n�o est� no top rank
    }
}
