using PangyaAPI.IFF.StructModels;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace PangyaAPI.IFF.Models
{
    #region Struct Part.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Part : IFFCommon
    {
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string MPet { get; set; }
        public uint EquipmentCategory { get; set; }// o tipo do item, 0, 2 normal, 8 e 9 UCC, 5 acho que é base ou commom Item
        public short PosMask { get; set; }
        public short HideMask { get; set; }
        public UInt32 Un2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture1 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture2 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture3 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture4 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture5 { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Texture6 { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Impact { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort PowerSlot { get; set; }
        public ushort ControlSlot { get; set; }
        public ushort ImpactSlot { get; set; }
        public ushort SpinSlot { get; set; }
        public ushort CurveSlot { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] EquippableWith { get; set; }
        public uint SubPart1 { get; set; }
        public uint SubPart2 { get; set; }
        public ushort CardCharSlots { get; set; }
        public ushort CardCaddieSlots { get; set; }
        public uint Points { get; set; }
        public uint RentPang { get; set; }
        public UInt32 Un4 { get; set; }

		public uint getPersonagem()
		{
			checked
			{
                return Convert.ToUInt32(Extensions.IFFHandleExtension.GetTypeIDValues(TypeID).CharacterType);
            }
		}

        public uint newTypeid(uint num, uint serial)
        {            
            return Extensions.IFFHandleExtension.GenerateNewTypeID(getPersonagem(), num, 2, EquipmentCategory, serial);
        }
        public uint newTypeid(uint CharacterType,uint Pos,uint Category, uint serial)
        {
            return Extensions.IFFHandleExtension.GenerateNewTypeID(CharacterType, Pos, 2, EquipmentCategory, serial);
        }
    }
    #endregion
}
