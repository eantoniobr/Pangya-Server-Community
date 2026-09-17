using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models.General;
using System.IO;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    #region Struct ClubSet.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClubSet : IFFCommon
    {


        public ClubSet()
        {
            Stats = new IFFStats();
            SlotStats = new IFFSlotStats();
        }

        public ClubSet(ref PangyaBinaryReader read, uint strLen)
        {
            LoadFile(ref read, strLen);
        }

        public void LoadFile(ref PangyaBinaryReader reader, uint strLen)
        {
            Load(ref reader, strLen);
            Clubs = reader.Read<SubClubs>();
            Stats = reader.Read<IFFStats>();
            SlotStats = reader.Read<IFFSlotStats>();
            ClubType = reader.ReadUInt32();
            rank_s_stat = reader.ReadUInt32();
            total_recovery = reader.ReadUInt32();
            Rate = reader.ReadSingle();
            Rank_WorkShop = reader.ReadUInt32();
            flag_transformar = reader.ReadUInt16();
            ulUnknown = reader.ReadUInt32();
            text_pangya = reader.ReadUInt32();
        }
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 16)]
        public class SubClubs
        {
            public uint Wood { get; set; }
            public uint Iron { get; set; }
            public uint Wedge { get; set; }
            public uint Putter { get; set; }
        
        public SubClubs Clone()
        {
        var clone = (SubClubs)MemberwiseClone();
        return clone;
        }
}

        [field: MarshalAs(UnmanagedType.Struct)]
        public SubClubs Clubs { get; set; }
        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFStats Stats { get; set; }

        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFSlotStats SlotStats { get; set; }
        public uint ClubType { get; set; }
        public uint rank_s_stat { get; set; }
        public uint total_recovery { get; set; }
        public float Rate { get; set; }
        public uint Rank_WorkShop { get; set; }
        public uint flag_transformar { get; set; }
        public uint ulUnknown { get; set; }
        public uint text_pangya { get; set; }

        public ClubSet Clone()
        {
            return (ClubSet)_Clone();
        }

        public override object _Clone()
        {
        var clone = (ClubSet)MemberwiseClone();
        clone.Clubs = this.Clubs?.Clone();
        clone.Stats = this.Stats?.Clone();
        clone.SlotStats = this.SlotStats?.Clone();
        clone.Level = this.Level?.Clone();
        clone.Shop = this.Shop?.Clone();
        clone.tiki = this.tiki?.Clone();
        clone.date = this.date?.Clone();
        return clone;
        }
}
    #endregion

}
