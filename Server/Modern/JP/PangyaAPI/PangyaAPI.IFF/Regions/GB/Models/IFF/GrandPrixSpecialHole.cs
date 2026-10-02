using System;
using System.Runtime.InteropServices;

namespace PangyaAPI.IFF.Regions.GB.Models.IFF
{
    #region Struct GrandPrixSpecialHole.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class GrandPrixSpecialHole
    {
        public UInt32 Enable { get; set; }
        public UInt32 TypeID { get; set; }
        public UInt32 HolePOS { get; set; }
        public UInt32 Map { get; set; }
        public UInt32 Hole { get; set; }
    }
    #endregion
}
