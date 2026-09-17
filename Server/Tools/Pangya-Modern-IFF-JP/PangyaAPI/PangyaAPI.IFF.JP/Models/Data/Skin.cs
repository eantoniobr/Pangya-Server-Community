using PangyaAPI.IFF.JP.Models.General;
using PangyaAPI.IFF.JP.Models.Flags;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    #region Struct Skin.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Skin : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public byte horizontal_scroll { get; set; }    // By TH S4 - (HScroll)    
        public byte vertical_scroll { get; set; }      // By TH S4 - (VScroll) 256 efeito de rolagem vertical
        public ushort Price1Day { get; set; }
        public ushort Price7Day { get; set; }
        public ushort Price15Day { get; set; }
        public ushort Price30Day { get; set; }
        public ushort Price365Day { get; set; }

        public override object _Clone()
        {
            var clone = (Skin)MemberwiseClone();
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }

        public Skin Clone()
        {
            return (Skin)_Clone();
        }
    }
    #endregion        
}
