using PangyaAPI.IFF.JP.Models.General;
using System.Runtime.InteropServices;

namespace PangyaAPI.IFF.JP.Models.Data
{

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CounterItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        public byte[] Bytes { get; set; }//8 start position

        public CounterItem Clone()
        {
            return (CounterItem)_Clone();
        }

        public override object _Clone()
        {
            var clone = (CounterItem)MemberwiseClone();
            clone.Bytes = this.Bytes != null ? (byte[])this.Bytes.Clone() : null;
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }
    }
}