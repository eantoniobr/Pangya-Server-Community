using PangyaAPI.IFF.StructModels;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{
    #region Struct ClubSet.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class ClubSet : IFFCommon
    {
        public uint Wood { get; set; }
        public uint Iron { get; set; }
        public uint Wedge { get; set; }
        public uint Putter { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort ImpactSlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public uint ClubType { get; set; }
        public uint ClubSPoint { get; set; }
        public uint RecoveryLimit { get; set; }
        public float RateWorkshop { get; set; }
        public uint Rank_WorkShop { get; set; }
        public ushort Transafer { get; set; }
        public ushort Flag1 { get; set; }
        public uint Unknown7 { get; set; }
        public uint Real_TypeID { get; set; }
    }
    #endregion

}
