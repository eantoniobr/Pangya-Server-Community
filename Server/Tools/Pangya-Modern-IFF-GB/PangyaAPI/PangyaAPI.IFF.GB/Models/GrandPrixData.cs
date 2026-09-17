using PangyaAPI.IFF.StructModels;
using System.Runtime.InteropServices;

namespace PangyaAPI.IFF.Models
{

    #region Struct GrandPrixData.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class GrandPrixData
    {
        public uint Enable { get; set; }
        public uint TypeID { get; set; }
        public uint TypeID_Link { get; set; }
        public uint TypeGP { get; set; }
        public ushort TimeHole { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65 + 1)]
        public string Name { get; set; }
        public uint TicketTypeID { get; set; }
        public uint TicketQuantity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        public string Image { get; set; }//[39 + 1];
        public byte Natural { get; set; }
        public byte ShortBase { get; set; }
        public byte HoleSize { get; set; }
        public uint Artifact { get; set; }
        public uint Map { get; set; }
        public uint Mode { get; set; }
        public byte TotalHole { get; set; }
        public byte MinLevel { get; set; }
        public byte MaxLevel { get; set; }
        public byte Unknown2 { get; set; }
        public uint Condition1 { get; set; }
        public uint Condition2 { get; set; }
        public int ScoreBotMax { get; set; }
        public int ScoreBotMed { get; set; }
        public int ScoreBotMin { get; set; }
        public uint Diffucult { get; set; }
        public uint PangReward { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 + 1)]
        public uint[] RewardTypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 + 1)]
        public uint[] RewardQuantity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4 + 1)]
        public uint[] Time { get; set; }
        public IFFTime Open { get; set; }
        public IFFTime Start { get; set; }
        public IFFTime End { get; set; }
        public uint Unknown6 { get; set; }
        public uint Clear_GP_TypeID { get; set; }
        public uint Lock_YN { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 516)]
        public string Info { get; set; }
    }
    #endregion
}
