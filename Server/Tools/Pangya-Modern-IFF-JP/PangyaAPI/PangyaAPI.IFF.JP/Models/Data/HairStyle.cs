using PangyaAPI.IFF.JP.Models.General;
using PangyaAPI.IFF.JP.Models.Flags;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    #region Struct HairStyle.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class HairStyle : IFFCommon
    {
        public byte Color { get; set; }
        public byte Character { get; set; }
        public ushort Blank { get; set; }
        public HairStyle Clone()
        {
            return (HairStyle)_Clone();
        }

        public override object _Clone()
        {
            var clone = (HairStyle)MemberwiseClone();
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }
    }
    #endregion
}
