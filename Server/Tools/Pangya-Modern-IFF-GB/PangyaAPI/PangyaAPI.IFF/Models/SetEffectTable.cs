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
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 5)]
        public string Active { get; set; }
        public byte Slot { get; set; }        
        public ushort Effect_Add_Power { get; set; } 
    }
    #endregion
}
