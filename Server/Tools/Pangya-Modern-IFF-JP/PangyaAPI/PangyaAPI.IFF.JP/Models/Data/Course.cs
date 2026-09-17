using PangyaAPI.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    /// <summary>
    /// Is Struct file Course.iff
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Course : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Mpet { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Gbin { get; set; }
        public byte Star { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 43)]
        public string XML { get; set; }
        public float RatePang { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] Seq { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public uint[] ulUnknown { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] Par_Hole { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] Min_Score_Hole { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
        public byte[] Max_Score_Hole { get; set; }
        public ushort usUnknown { get; set; }

        public Course Clone()
        {
            return (Course)_Clone();
        }

        public override object _Clone()
        {
            var clone = (Course)MemberwiseClone();
            clone.Seq = this.Seq != null ? (byte[])this.Seq.Clone() : null;
            clone.ulUnknown = this.ulUnknown != null ? (uint[])this.ulUnknown.Clone() : null;
            clone.Par_Hole = this.Par_Hole != null ? (byte[])this.Par_Hole.Clone() : null;
            clone.Min_Score_Hole = this.Min_Score_Hole != null ? (byte[])this.Min_Score_Hole.Clone() : null;
            clone.Max_Score_Hole = this.Max_Score_Hole != null ? (byte[])this.Max_Score_Hole.Clone() : null;
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }
    }
}
