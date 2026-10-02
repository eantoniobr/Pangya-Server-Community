using System.Runtime.InteropServices;
using PangyaAPI.Utilities;
namespace PangyaAPI.IFF.Models
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 36)]
    public class IFFDate
    {
        public IFFDate()
        {
            Start = new SystemTime();
            End = new SystemTime();
        }
        //-------------------- TIME IFF--------------\\
        [field: MarshalAs(UnmanagedType.Bool, SizeConst = 4)]
        public bool active { get; set; }//156 start position
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public SystemTime Start { get; set; }// 160 start position
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public SystemTime End { get; set; }// 176 start position
        //--------------------------------------------------\\
        public bool Check()
        {
            if (active)
            {
                return true;
            }
            return false;
        }
        public void Clear()
        {
            Start = new SystemTime();
            End = new SystemTime();
        }
    }
}
