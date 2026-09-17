using PangyaAPI.IFF.StructModels;
using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.Models
{


    #region Struct Item.iff
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class Item : IFFCommon
    {
        public uint ItemType { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]

        public string Texture { get; set; }
        public ushort Power { get; set; }
        public ushort Control { get; set; }
        public ushort Accuracy { get; set; }
        public ushort Spin { get; set; }
        public ushort Curve { get; set; }
        public ushort Unkown { get; set; }

#pragma warning disable CS0108 // "Item.CreateNewItem()" oculta o membro herdado "IFFCommon.CreateNewItem()". Use a nova palavra-chave se foi pretendido ocultar.
        public Item CreateNewItem()
#pragma warning restore CS0108 // "Item.CreateNewItem()" oculta o membro herdado "IFFCommon.CreateNewItem()". Use a nova palavra-chave se foi pretendido ocultar.
        {
            Icon = "";
            Name = "[NOVO ITEM]";
            Bonus = new short[2];
            DateStart = new IFFTime();
            DateEnd = new IFFTime();
            Texture = "";
            return this;
        }
    }
    #endregion
}