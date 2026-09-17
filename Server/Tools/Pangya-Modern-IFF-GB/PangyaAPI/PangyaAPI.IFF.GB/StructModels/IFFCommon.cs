using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.Extensions;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;

namespace PangyaAPI.IFF.StructModels
{
    /// <summary>
    /// update in 26/02/2022 - 21:40 PM by LuisMK
    /// Common data structure found at the head of many IFF datasets
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public partial class IFFCommon : ICloneable //size = 0x90(144 bytes)
    {
        //------------------- IFF BASIC ----------------------------\\
        public uint Enabled { get; set; }//0 start position
        public uint TypeID { get; set; }//4 start position
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name { get; set; }//8 start position
        public ItemLevelEnum MinLevel { get; set; }//48 start position
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 43)]
        public string Icon { get; set; }//49 start position
        //--------------------------end--------------------------------\\

        //------------------ SHOP DADOS ---------------------------------\\
        public uint ItemPrice { get; set; }//92 start position
        public uint DiscountPrice { get; set; }//96 start position
        public uint Condition { get; set; }//100 start position(Aqui é a condição do angel wing seu valor é 6, as outras angel wings do outros characters variam entre 1, 5, 6 e 0 (acho que seja a sexta condição de quit rate menor que 3%)
        public ShopFlag PriceType { get; set; }//101 start position
        public MoneyFlag MoneyFlag { get; set; }//102 start position(0x01 in stock; 0x02 disable gift; 0x03 Special; 0x08 new; 0x10 hot)
        public byte TimeFlag { get; set; }//130 start position
        public byte TimeByte { get; set; }//131 start position
        //-------------------  END  ------------------------------\\

        //------------------ Tiki SHOP---------------------\\
        public uint TPItemCount { get; set; }//135 start position
        public uint TPCount { get; set; }// 139 positon
        public ushort Mileage_Points { get; set; }// 140 start position
        public ushort BonusProb { get; set; }// 142 start position
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public short[] Bonus { get; set; }// 144 start position
        public uint TikiPointShop { get; set; }// 148 start position
        public uint TikiPang { get; set; }// 152 start position
      //-----------------------------------------------\\

        //-------------------- TIME IFF--------------\\
        public uint Active_Item_Time { get; set; }//156 start position
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime DateStart { get; set; }// 160 start position
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime DateEnd { get; set; }// 176 start position
        //--------------------------------------------------\\
       
        public void Load(ref PangyaBinaryReader reader, int LenghtStr)
        {
            //------------------- IFF BASIC ----------------------------\\
            Enabled = reader.ReadUInt32();
            TypeID = reader.ReadUInt32();
            Name = reader.ReadPStr(64);
            MinLevel = (ItemLevelEnum)reader.ReadByte(); //49 start position
            Icon = reader.ReadPStr(43); //89 start position
            //--------------------------end--------------------------------\\

            //------------------ SHOP DADOS ---------------------------------\\
            ItemPrice = reader.ReadUInt32(); //95 start position
            DiscountPrice = reader.ReadUInt32(); //99 start position
            Condition = reader.ReadUInt32(); //103 start position
            PriceType = (ShopFlag)reader.ReadByte(); //104 start position
            MoneyFlag = (MoneyFlag)reader.ReadByte(); //105 start position(0x01 in stock; 0x02 disable gift; 0x03 Special; 0x08 new; 0x10 hot)
            TimeFlag = reader.ReadByte(); //106 start position
            TimeByte = reader.ReadByte(); //107 start position
            //-------------------  END  ------------------------------\\

            //------------------ Tiki SHOP---------------------\\
            TPItemCount = reader.ReadUInt32(); //111 start position
            TPCount = reader.ReadUInt32(); // 115 positon
            Mileage_Points = reader.ReadUInt16(); // 117 start position
            BonusProb = reader.ReadUInt16(); // 119 start position
            Bonus = reader.ReadShorts(2); // 121 start position
            TikiPointShop = reader.ReadUInt32(); // 127 start position
            TikiPang = reader.ReadUInt32(); // 131 start position
            //-----------------------------------------------\\

            //-------------------- TIME IFF--------------\\
            Active_Item_Time = reader.ReadUInt32();

            DateStart = new IFFTime { Year = reader.ReadUInt16(), Month = reader.ReadUInt16(), DayOfWeek = reader.ReadUInt16(), Day = reader.ReadUInt16(), Hour = reader.ReadUInt16(), Minute = reader.ReadUInt16(), Second = reader.ReadUInt16(), MilliSecond = reader.ReadUInt16() };// 149 start position
            DateEnd = new IFFTime { Year = reader.ReadUInt16(), Month = reader.ReadUInt16(), DayOfWeek = reader.ReadUInt16(), Day = reader.ReadUInt16(), Hour = reader.ReadUInt16(), Minute = reader.ReadUInt16(), Second = reader.ReadUInt16(), MilliSecond = reader.ReadUInt16() }; // 163 start position
            //--------------------------------------------------\\
        }

        public IFFCommon Load(byte[] data)
        {
            var item = new IFFCommon();
            using (PangyaBinaryReader Reader = new PangyaBinaryReader(new MemoryStream(data)))
            {
               item = (IFFCommon)Reader.Read(item);
            };
            return item;
        }

        public bool ShopPangYa_ActiveAll()
        {
            MoneyFlag = 0;
            PriceType = ShopFlag.Unknown32;
            TimeFlag = 21;
            if (ItemPrice <= 10000000)
            {
                ItemPrice = 9999;
            }
            return true;
        }

        //so aparece pro part.iff
        public bool Personal_Shop_Active()
        {
            //ativa no personal shop
           PriceType = ShopFlag.NonGiftable;
           MoneyFlag = MoneyFlag.None;
            if (ItemPrice <= 10000000)
            {
                ItemPrice = 9999;
            }
            return true;
        }

        public string GetItemName()
        {
            return Name;
        }

        public uint GetPrice()
        {
            return ItemPrice;
        }

        public sbyte GetShopPriceType()
        {
            return (sbyte)PriceType;
        }

        public bool IsBuyable()
        {
            if (Enabled == 1 && MoneyFlag == 0 || (int)MoneyFlag == 1 || (int)MoneyFlag == 2)
            {
                return true;
            }
            return false;
        }

        public bool IsExist() 
        { 
            return Convert.ToBoolean(Enabled);
        }

        public object Clone()
        {
            return this;
        }
        public IFFCommon CreateNewItem()
        {
            Name = "[NOVO ITEM]";
            Icon = "[NOVO ICON]";
            Bonus = new short[2]; 
            DateStart = new IFFTime();
            DateEnd = new IFFTime();
              return this;
        }
        public uint TypeItem()
        {
            return (uint)((int)((TypeID & 0x3fc0000) / Math.Pow(2.0, 18.0)));
        }
        public IFFValues Values()
        {
            return IFFHandleExtension.GetTypeIDValues(TypeID);
        }
    }
}
