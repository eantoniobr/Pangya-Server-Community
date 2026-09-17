using PangyaAPI.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    #region Struct QuestStuff.iff

    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class QuestStuff : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Counter_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] Counter_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reward_Item_Time { get; set; }

        public QuestStuff Clone()
        {
            return (QuestStuff)_Clone();
        }

        public override object _Clone()
        {
            var clone = (QuestStuff)MemberwiseClone();
            clone.Counter_Item_TypeID = this.Counter_Item_TypeID != null ? (uint[])this.Counter_Item_TypeID.Clone() : null;
            clone.Counter_Item_Qtnd = this.Counter_Item_Qtnd != null ? (uint[])this.Counter_Item_Qtnd.Clone() : null;
            clone.Reward_Item_TypeID = this.Reward_Item_TypeID != null ? (uint[])this.Reward_Item_TypeID.Clone() : null;
            clone.Reward_Item_Qtnd = this.Reward_Item_Qtnd != null ? (uint[])this.Reward_Item_Qtnd.Clone() : null;
            clone.Reward_Item_Time = this.Reward_Item_Time != null ? (uint[])this.Reward_Item_Time.Clone() : null;
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }
    }

    #endregion

}
