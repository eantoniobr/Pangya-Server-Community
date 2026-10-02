using System.Runtime.InteropServices;
using PangyaAPI.IFF.Regions.GB.Models.Generic;

namespace PangyaAPI.IFF.Regions.GB.Models.IFF
{

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class CounterItem : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 88)]
        public byte[] Bytes { get; set; }//8 start position
    }
}