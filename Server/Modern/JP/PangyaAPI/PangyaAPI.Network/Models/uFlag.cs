using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Models
{
    public class Flag
    {
        public ulong ullFlag { get; set; }

        public bool Unknown0
        {
            get
            {
                return (ullFlag & 1) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 1) : (ullFlag & 0xFFFFFFFFFFFFFFFEuL));
            }
        }

        public bool all_game
        {
            get
            {
                return (ullFlag & 2) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 2) : (ullFlag & 0xFFFFFFFFFFFFFFFDuL));
            }
        }

        public bool buy_and_gift_shop
        {
            get
            {
                return (ullFlag & 4) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 4) : (ullFlag & 0xFFFFFFFFFFFFFFFBuL));
            }
        }

        public bool gift_shop
        {
            get
            {
                return (ullFlag & 8) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 8) : (ullFlag & 0xFFFFFFFFFFFFFFF7uL));
            }
        }

        public bool papel_shop
        {
            get
            {
                return (ullFlag & 0x10) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x10) : (ullFlag & 0xFFFFFFFFFFFFFFEFuL));
            }
        }

        public bool personal_shop
        {
            get
            {
                return (ullFlag & 0x20) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x20) : (ullFlag & 0xFFFFFFFFFFFFFFDFuL));
            }
        }

        public bool stroke
        {
            get
            {
                return (ullFlag & 0x40) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x40) : (ullFlag & 0xFFFFFFFFFFFFFFBFuL));
            }
        }

        public bool match
        {
            get
            {
                return (ullFlag & 0x80) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x80) : (ullFlag & 0xFFFFFFFFFFFFFF7FuL));
            }
        }

        public bool tourney
        {
            get
            {
                return (ullFlag & 0x100) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x100) : (ullFlag & 0xFFFFFFFFFFFFFEFFuL));
            }
        }

        public bool team_tourney
        {
            get
            {
                return (ullFlag & 0x200) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x200) : (ullFlag & 0xFFFFFFFFFFFFFDFFuL));
            }
        }

        public bool guild_battle
        {
            get
            {
                return (ullFlag & 0x400) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x400) : (ullFlag & 0xFFFFFFFFFFFFFBFFuL));
            }
        }

        public bool pang_battle
        {
            get
            {
                return (ullFlag & 0x800) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x800) : (ullFlag & 0xFFFFFFFFFFFFF7FFuL));
            }
        }

        public bool approach
        {
            get
            {
                return (ullFlag & 0x1000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x1000) : (ullFlag & 0xFFFFFFFFFFFFEFFFuL));
            }
        }

        public bool lounge
        {
            get
            {
                return (ullFlag & 0x2000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x2000) : (ullFlag & 0xFFFFFFFFFFFFDFFFuL));
            }
        }

        public bool scratchy
        {
            get
            {
                return (ullFlag & 0x4000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x4000) : (ullFlag & 0xFFFFFFFFFFFFBFFFuL));
            }
        }

        public bool Unknown1
        {
            get
            {
                return (ullFlag & 0x8000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x8000) : (ullFlag & 0xFFFFFFFFFFFF7FFFuL));
            }
        }

        public bool rank_server
        {
            get
            {
                return (ullFlag & 0x10000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x10000) : (ullFlag & 0xFFFFFFFFFFFEFFFFuL));
            }
        }

        public bool ticker
        {
            get
            {
                return (ullFlag & 0x20000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x20000) : (ullFlag & 0xFFFFFFFFFFFDFFFFuL));
            }
        }

        public bool mail_box
        {
            get
            {
                return (ullFlag & 0x40000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x40000) : (ullFlag & 0xFFFFFFFFFFFBFFFFuL));
            }
        }

        public bool grand_zodiac
        {
            get
            {
                return (ullFlag & 0x80000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x80000) : (ullFlag & 0xFFFFFFFFFFF7FFFFuL));
            }
        }

        public bool single_play
        {
            get
            {
                return (ullFlag & 0x100000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x100000) : (ullFlag & 0xFFFFFFFFFFEFFFFFuL));
            }
        }

        public bool grand_prix
        {
            get
            {
                return (ullFlag & 0x200000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x200000) : (ullFlag & 0xFFFFFFFFFFDFFFFFuL));
            }
        }

        public bool Unknown2
        {
            get
            {
                return (ullFlag & 0xC00000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0xC00000) : (ullFlag & 0xFFFFFFFFFF3FFFFFuL));
            }
        }

        public bool guild
        {
            get
            {
                return (ullFlag & 0x1000000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x1000000) : (ullFlag & 0xFFFFFFFFFEFFFFFFuL));
            }
        }

        public bool ssc
        {
            get
            {
                return (ullFlag & 0x2000000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x2000000) : (ullFlag & 0xFFFFFFFFFDFFFFFFuL));
            }
        }

        public bool Unknown3
        {
            get
            {
                return (ullFlag & 0xC000000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0xC000000) : (ullFlag & 0xFFFFFFFFF3FFFFFFuL));
            }
        }

        public bool memorial_shop
        {
            get
            {
                return (ullFlag & 0x10000000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x10000000) : (ullFlag & 0xFFFFFFFFEFFFFFFFuL));
            }
        }

        public bool short_game
        {
            get
            {
                return (ullFlag & 0x20000000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x20000000) : (ullFlag & 0xFFFFFFFFDFFFFFFFuL));
            }
        }

        public bool char_mastery
        {
            get
            {
                return (ullFlag & 0x40000000) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x40000000) : (ullFlag & 0xFFFFFFFFBFFFFFFFuL));
            }
        }

        public bool Unknown4
        {
            get
            {
                return (ullFlag & 0x80000000u) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x80000000u) : (ullFlag & 0xFFFFFFFF7FFFFFFFuL));
            }
        }

        public bool lolo_copound_card
        {
            get
            {
                return (ullFlag & 0x100000000L) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x100000000L) : (ullFlag & 0xFFFFFFFEFFFFFFFFuL));
            }
        }

        public bool cadie_recycle
        {
            get
            {
                return (ullFlag & 0x200000000L) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x200000000L) : (ullFlag & 0xFFFFFFFDFFFFFFFFuL));
            }
        }

        public bool legacy_tiki_shop
        {
            get
            {
                return (ullFlag & 0x400000000L) != 0;
            }
            set
            {
                ullFlag = (value ? (ullFlag | 0x400000000L) : (ullFlag & 0xFFFFFFFBFFFFFFFFuL));
            }
        }

        public Flag(ulong _ull = 0uL)
        {
            ullFlag = _ull;
        }
    }
}
