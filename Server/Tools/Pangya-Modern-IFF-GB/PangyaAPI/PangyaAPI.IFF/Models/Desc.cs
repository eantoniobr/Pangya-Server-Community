using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{

    #region Struct Desc.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Desc
    {
        public uint TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string Description { get; set; }
    }
    #endregion

}
