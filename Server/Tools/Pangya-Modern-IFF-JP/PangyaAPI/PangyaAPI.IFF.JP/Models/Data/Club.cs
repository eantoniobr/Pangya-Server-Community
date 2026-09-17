using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models.General;
using System.IO;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{

    #region Struct Club.iff

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Club : IFFCommon
    {
      
        public Club()
        { }

        public Club(ref PangyaBinaryReader read)
        {
            LoadFile(ref read);
        }

        public void LoadFile(ref PangyaBinaryReader reader)
        {
            Load(ref reader, 40);
            MPet = reader.ReadPStr(40);
            ClubType = reader.ReadUInt16();
            Stats = reader.Read<IFFStats>();
        }

        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort ClubType { get; set; }

        [field: MarshalAs(UnmanagedType.Struct)]
        public IFFStats Stats { get; set; }
        public Club Clone()
        {
            return (Club)_Clone();
        }

        public override object _Clone()
        {
        var clone = (Club)MemberwiseClone();
        clone.Stats = this.Stats?.Clone();
        clone.Level = this.Level?.Clone();
        clone.Shop = this.Shop?.Clone();
        clone.tiki = this.tiki?.Clone();
        clone.date = this.date?.Clone();
        return clone;
        }
}
    #endregion

}
