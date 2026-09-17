using PangyaAPI.IFF.StructModels;
using PangyaAPI.IFF.Definitions;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{

    #region Struct CaddieItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CaddieItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet;

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string TexTure;
        public UInt16 Price1Day { get; set; }
        public UInt16 Price7Day { get; set; }
        public UInt16 Price15Day { get; set; }
        public UInt16 Price30Day { get; set; }
        public UInt32 FlagRoll { get; set; }
    }
    #endregion

}
