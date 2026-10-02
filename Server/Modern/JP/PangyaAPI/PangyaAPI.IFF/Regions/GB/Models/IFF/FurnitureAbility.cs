using System.Runtime.InteropServices;
using PangyaAPI.Utilities;
namespace PangyaAPI.IFF.Regions.GB.Models.IFF
{
    /// <summary>
    /// Is Struct file FurnitureAbility.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class FurnitureAbility
    {
        public uint Enabled { get; set; }
        public uint TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Unknown { get; set; }
        [field: MarshalAs(UnmanagedType.Struct)]
        public SystemTime StartTime { get; set; }
        public uint Unknown2 { get; set; }
        public uint TypeID_Item { get; set; }
        public uint Price { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Unknown3 { get; set; }
    }
}
