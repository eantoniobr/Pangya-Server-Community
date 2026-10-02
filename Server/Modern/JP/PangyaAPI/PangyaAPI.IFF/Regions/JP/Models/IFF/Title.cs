using System.Runtime.InteropServices;

namespace PangyaAPI.IFF.Regions.JP.Models.IFF
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Title
    {
        public uint Active { get; set; }
        public uint ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Icon { get; set; }
    }
}
