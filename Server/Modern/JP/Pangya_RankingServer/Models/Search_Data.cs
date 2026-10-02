using Pangya_RankingServer.Flags;
using PangyaAPI.Network;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pangya_RankingServer.Models
{
    public class SearchData
    {
        public SearchData(uint _ul = 0u)
        {
            this.rank_menu = RankMenuFlags.RM_OVERALL;
            this.rank_menu_item = (byte)Rank_Type.RO_TOTAL_POINTS;
            this.term_s5_type = 0;
            this.class_type = 0;
            this.page = 0u;
        }

        public SearchData(Packet reader)
        {
            this.rank_menu = RankMenuFlags.RM_OVERALL;
            this.rank_menu_item = (byte)Rank_Type.RO_TOTAL_POINTS;
            this.term_s5_type = 0;
            this.class_type = 0;
            this.page = 0u;

            ToRead(reader);
        }

        public string toString()
        {
            return "RANK_MENU: " + Convert.ToString((ushort)rank_menu) + "\nRANK_MENU_ITEM: " + Convert.ToString((ushort)rank_menu_item) + "\nPAGE: " + Convert.ToString(page) + "\nTERM_S5_TYPE: " + Convert.ToString(term_s5_type) + "\nCLASS_TYPE: " + Convert.ToString(class_type);
        }

        public RankMenuFlags rank_menu { get; set; }
        public byte rank_menu_item { get; set; }
        public byte term_s5_type { get; set; } 
        public byte class_type { get; set; } 
        public uint page;

        public void ToRead(Packet _packet)
        {
            rank_menu = (RankMenuFlags)_packet.ReadByte();
            rank_menu_item = _packet.ReadByte();
            term_s5_type = _packet.ReadByte();
            class_type = _packet.ReadByte();
            page = _packet.ReadUInt32();
        }
    }

    public class SearchDataEx : SearchData
    {
        public SearchDataEx(uint _ul = 0u) : base(_ul)
        {
            this.active = 0;
        } 
        public byte active { get; set; }
    }
}
