using PangyaAPI.IFF.JP.Models.General;
using System.Runtime.InteropServices;
using System.Text;

namespace PangyaAPI.IFF.JP.Models.Data
{
    #region Struct Achievement.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Achievement : IFFCommon
    {
        public uint TypeID_Quest_Index { get; set; }
        public uint Achievement_Type { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName { get; set; }
        public string QuestName
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName).Replace("\0", "");
            set => BQuestName = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName1 { get; set; }
        public string QuestName1
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName1).Replace("\0", "");
            set => BQuestName1 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName2 { get; set; }
        public string QuestName2
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName2).Replace("\0", "");
            set => BQuestName2 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName3 { get; set; }
        public string QuestName3
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName3).Replace("\0", "");
            set => BQuestName3 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName4 { get; set; }
        public string QuestName4
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName4).Replace("\0", "");
            set => BQuestName4 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName5 { get; set; }
        public string QuestName5
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName5).Replace("\0", "");
            set => BQuestName5 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName6 { get; set; }
        public string QuestName6
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName6).Replace("\0", "");
            set => BQuestName6 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName7 { get; set; }
        public string QuestName7
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName7).Replace("\0", "");
            set => BQuestName7 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName8 { get; set; }
        public string QuestName8
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName8).Replace("\0", "");
            set => BQuestName8 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
        private byte[] BQuestName9 { get; set; }
        public string QuestName9
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(BQuestName9).Replace("\0", "");
            set => BQuestName9 = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(129, '\0'));
        }
        public short Tipo { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Quest_TypeID { get; set; }
        public uint Option { get; set; }

        public Achievement Clone()
        {
            return (Achievement)_Clone();
        }

        public override object _Clone()
        {
            var clone = (Achievement)MemberwiseClone();
            clone.BQuestName = this.BQuestName != null ? (byte[])this.BQuestName.Clone() : null;
            clone.BQuestName1 = this.BQuestName1 != null ? (byte[])this.BQuestName1.Clone() : null;
            clone.BQuestName2 = this.BQuestName2 != null ? (byte[])this.BQuestName2.Clone() : null;
            clone.BQuestName3 = this.BQuestName3 != null ? (byte[])this.BQuestName3.Clone() : null;
            clone.BQuestName4 = this.BQuestName4 != null ? (byte[])this.BQuestName4.Clone() : null;
            clone.BQuestName5 = this.BQuestName5 != null ? (byte[])this.BQuestName5.Clone() : null;
            clone.BQuestName6 = this.BQuestName6 != null ? (byte[])this.BQuestName6.Clone() : null;
            clone.BQuestName7 = this.BQuestName7 != null ? (byte[])this.BQuestName7.Clone() : null;
            clone.BQuestName8 = this.BQuestName8 != null ? (byte[])this.BQuestName8.Clone() : null;
            clone.BQuestName9 = this.BQuestName9 != null ? (byte[])this.BQuestName9.Clone() : null;
            clone.Quest_TypeID = this.Quest_TypeID != null ? (uint[])this.Quest_TypeID.Clone() : null;
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }
    }
    #endregion
}
