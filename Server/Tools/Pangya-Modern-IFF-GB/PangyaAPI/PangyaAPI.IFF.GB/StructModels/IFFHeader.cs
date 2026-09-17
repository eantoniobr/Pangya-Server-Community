using System.Runtime.InteropServices;

namespace PangyaAPI.IFF.StructModels
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public class IFFHeader
    {
        /// <summary>
        /// size file data
        /// </summary>
        public short Count { get; set; }

        /// <summary>
        /// ID determining relation to other IFF files
        /// </summary>
        public short BindingID { get; set; }

        /// <summary>
        /// Version of this IFF file
        /// </summary>
        public uint Version { get; set; }
    }
}
