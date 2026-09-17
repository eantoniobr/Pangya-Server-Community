using PangyaAPI.IFF.StructModels;
using PangyaAPI.IFF.Definitions;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{



    #region Struct LevelUpItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class LevelUpPrizeItem
    {
        public byte Active { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string Name { get; set; }
        public ushort Level { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] TypeID;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Quantity;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Time;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]
        public string Description { get; set; }
    }
    #endregion

}
