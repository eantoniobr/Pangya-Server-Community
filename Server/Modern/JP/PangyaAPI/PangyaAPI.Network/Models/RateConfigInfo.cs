using System;
using System.Collections.Generic;
using System.Text;

namespace PangyaAPI.Network.Models
{
    public class RateConfigInfo
    {
        public short scratchy { get; set; }

        public short papel_shop_rare_item { get; set; }

        public short papel_shop_cookie_item { get; set; }

        public short treasure { get; set; }

        public short pang { get; set; }

        public short exp { get; set; }

        public short club_mastery { get; set; }

        public short chuva { get; set; }

        public short memorial_shop { get; set; }

        public short grand_zodiac_event_time { get; set; }

        public short angel_event { get; set; }

        public short grand_prix_event { get; set; }

        public short golden_time_event { get; set; }

        public short login_reward_event { get; set; }

        public short bot_gm_event { get; set; }

        public short smart_calculator { get; set; }

        public short world_tour_event { get; set; }

        public short hole_event { get; set; }

        public short mission_event { get; set; }

        public short point_event_shop { get; set; }

        public uint countBitGrandPrixEvent()
        {
            uint count = 0u;
            for (int i = 0; (long)i < 16L; i++)
            {
                if (((grand_prix_event >> i) & 1) == 1)
                {
                    count++;
                }
            }
            return count;
        }

        public List<uint> getValueBitGrandPrixEvent()
        {
            List<uint> v_value = new List<uint>();
            for (int i = 0; i < 16; i++)
            {
                if (((grand_prix_event >> i) & 1) == 1)
                {
                    v_value.Add((uint)(i + 1));
                }
            }
            return v_value;
        }

        public bool checkBitGrandPrixEvent(int _type)
        {
            if (_type == 0)
            {
                return false;
            }
            return ((Convert.ToUInt32(grand_prix_event) >> _type - 1) & 1) == 1;
        }

        public override string ToString()
        {
            return $"GRAND_ZODIAC_EVENT_TIME={grand_zodiac_event_time}, " + $"GOLDEN_TIME_EVENT={golden_time_event}, " + $"ANGEL_EVENT={angel_event}, " + $"GRAND_PRIX_EVENT={grand_prix_event}, " + $"LOGIN_REWARD_EVENT={login_reward_event}, " + $"BOT_GM_EVENT={bot_gm_event}, " + $"SMART_CALCULATOR_SYSTEM={smart_calculator}, " + $"SCRATCHY={scratchy}, " + $"PAPEL_SHOP_RARE_ITEM={papel_shop_rare_item}, " + $"PAPEL_SHOP_COOKIE_ITEM={papel_shop_cookie_item}, " + $"TREASURE={treasure}, " + $"PANG={pang}, " + $"EXP={exp}, " + $"CLUB_MASTERY={club_mastery}, " + $"CHUVA={chuva}, " + $"MEMORIAL_SHOP={memorial_shop}";
        }
    }

}
