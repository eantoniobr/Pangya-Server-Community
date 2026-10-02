using System.Runtime.InteropServices;
using PangyaAPI.IFF.Regions.JP.Models.Generic;
namespace PangyaAPI.IFF.Regions.JP.Models.IFF
{
    #region Struct HairStyle.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class HairStyle : IFFCommon
    {
        public byte Color { get; set; }
        public byte Character { get; set; }
        public ushort Blank { get; set; }
    }
    #endregion
}
