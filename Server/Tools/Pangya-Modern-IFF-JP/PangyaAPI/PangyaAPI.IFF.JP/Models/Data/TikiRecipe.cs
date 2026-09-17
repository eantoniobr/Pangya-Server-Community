using PangyaAPI.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    /// <summary>
    /// Is Struct file TikiRecipe.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class TikiRecipe
    {
        public uint Enable;
        public byte TypeID;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 35)]
        public string Name;
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Unknown;
    
        public TikiRecipe Clone()
        {
        var clone = (TikiRecipe)MemberwiseClone();
        clone.Unknown = this.Unknown != null ? (uint[])this.Unknown.Clone() : null;
        return clone;
        }
}
}
