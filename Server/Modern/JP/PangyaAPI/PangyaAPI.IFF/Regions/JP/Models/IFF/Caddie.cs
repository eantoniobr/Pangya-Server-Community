using System.Runtime.InteropServices;
using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.Regions.JP.Models.Generic;
using PangyaAPI.Utilities.Models;
namespace PangyaAPI.IFF.Regions.JP.Models.IFF
{
    #region Struct Caddie.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Caddie : IFFCommon
    {
        public uint valor_mensal { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 10)]
        public IFFStats Stats { get; set; }
        public ushort Point { get; set; }


        public Caddie()
        { }

        public Caddie(ref PangyaBinaryReader read)
        {
            LoadFile(ref read);
        }

        public void LoadFile(ref PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            valor_mensal = reader.ReadUInt32();
            MPet = reader.ReadPStr(40);
            Stats = reader.Read<IFFStats>();
            Point = reader.ReadUInt16();
        }
    }
    #endregion
}
