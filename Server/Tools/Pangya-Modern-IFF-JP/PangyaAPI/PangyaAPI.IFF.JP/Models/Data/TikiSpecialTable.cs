using PangyaAPI.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    /// <summary>
    /// Is Struct file TikiSpecialTable.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class TikiSpecialTable
    {
        public uint Enable;
        public byte TypeID;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 35)]
        public string Name;
        public uint Qty;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] TypeID_Item;
    
        public TikiSpecialTable Clone()
        {
        var clone = (TikiSpecialTable)MemberwiseClone();
        clone.TypeID_Item = this.TypeID_Item != null ? (uint[])this.TypeID_Item.Clone() : null;
        return clone;
        }
}
}
