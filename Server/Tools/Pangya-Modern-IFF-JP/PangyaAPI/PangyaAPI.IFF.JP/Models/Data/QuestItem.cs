using PangyaAPI.IFF.JP.Models.General;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{


    #region Struct QuestItem.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class QuestItem : IFFCommon
    {
        public uint Unknown { get; set; }
        public uint Quest_Type { get; set; }
        public uint Quest_Counter { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public uint[] Quest_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Reward_Item_TypeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Reward_Item_Qtnd { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] Reward_Item_Time { get; set; }
        public uint Unknown1 { get; set; }

        public QuestItem Clone()
        {
            return (QuestItem)_Clone();
        }

        public override object _Clone()
        {
        var clone = (QuestItem)MemberwiseClone();
        clone.Quest_TypeID = this.Quest_TypeID != null ? (uint[])this.Quest_TypeID.Clone() : null;
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
