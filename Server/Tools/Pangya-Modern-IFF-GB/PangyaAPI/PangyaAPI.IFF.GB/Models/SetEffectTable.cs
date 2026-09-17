using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{
    #region Struct SetEffectTable.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SetEffectTable
    {
        public uint ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Effect { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Type { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] TypeID { get; set; }
        public byte Enabled { get; set; }
        ////[field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        //[field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte Slot { get; set; }
        public byte Effect_Add_Power { get; set; }
        public uint Unk { get; set; }

    }
    #endregion
}
