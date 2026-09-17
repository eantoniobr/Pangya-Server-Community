using PangyaAPI.IFF.StructModels;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{
    #region Struct SetItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class SetItem : IFFCommon
    {
        public uint Total { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Item_TypeID { get; set; }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public ushort[] Item_Qty { get; set; }

        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Un { get; set; }
    }
    #endregion

}
