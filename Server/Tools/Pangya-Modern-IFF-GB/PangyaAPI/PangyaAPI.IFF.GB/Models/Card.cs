using PangyaAPI.IFF.StructModels;
using PangyaAPI.IFF.Definitions;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{
    #region Struct Card.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Card : IFFCommon
    {
        public byte Rarity { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort AccuracySlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        public CardEffectFlag Effect { get; set; }
        public UInt16 EffectValue { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture1;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture2;
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string AdditionalTexture3;
        public ushort EffectTime { get; set; }
        public ushort Volumn { get; set; }
        public UInt32 Position { get; set; }
        public UInt32 flag1 { get; set; }     // !@flag que guarda alguns valores de de N, R, SR, SC e etc
        public UInt32 flag2 { get; set; }		// flag que guarda alguns valores de de N, R, SR, SC e etc
    }
    #endregion
}
