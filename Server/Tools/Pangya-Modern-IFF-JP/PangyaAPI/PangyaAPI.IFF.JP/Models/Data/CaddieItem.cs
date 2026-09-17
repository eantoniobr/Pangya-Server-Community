using PangyaAPI.IFF.JP.Models.General;
using PangyaAPI.IFF.JP.Models.Flags;
using System;
using System.Runtime.InteropServices;
using PangyaAPI.IFF.JP.Extensions;
using System.Globalization;

namespace PangyaAPI.IFF.JP.Models.Data
{
    #region Struct CaddieItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CaddieItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TexTure { get; set; }
        public UInt16 Price1Day { get; set; }
        public UInt16 Price7Day { get; set; }
        public UInt16 Price15Day { get; set; }
        public UInt16 Price30Day { get; set; }
        public uint unit_power_guage_start { get; set; }
        public CaddieItem(PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            MPet = reader.ReadPStr(40);
            TexTure = reader.ReadPStr(40);
            Price1Day = reader.ReadUInt16();
            Price7Day = reader.ReadUInt16();
            Price15Day = reader.ReadUInt16();
            Price30Day = reader.ReadUInt16();
            unit_power_guage_start = reader.ReadUInt32();
        }
        enum CaddieType : byte
        {
            COOKIE,     // CASH
            PANG,       // PANG
            ESPECIAL,   // ACHO, por que não tem nenhum item com esse, não vi pelo menos
            UPGRADE
        }
        public CaddieItem()
        { }

        public CaddieItem Clone()
        {
            return (CaddieItem)_Clone();
        }

        public override object _Clone()
        {
            var clone = (CaddieItem)MemberwiseClone();
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }
    }
    #endregion

}
