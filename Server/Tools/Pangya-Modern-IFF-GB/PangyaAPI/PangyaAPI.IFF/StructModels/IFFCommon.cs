using PangyaAPI.IFF.Definitions;
using PangyaAPI.IFF.Extensions;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using static PangyaAPI.IFF.Extensions.IFFHandleExtension;

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
       /// <summary>
       /// shop flag
       /// </summary>
        public ShopFlag PriceType { get; set; }//104 start position
        public MoneyFlag MoneyFlag { get; set; }//105 start position(0x01 in stock; 0x02 disable gift; 0x03 Special; 0x08 new; 0x10 hot)
        public byte TimeFlag { get; set; }//106 start position
        public byte TimeByte { get; set; }//107 start position
        //-------------------  END  ------------------------------\\

        //------------------ Tiki SHOP---------------------\\
        public uint TPItemCount { get; set; }//111 start position
        public uint TPCount { get; set; }// 109 positon
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

        public void Load(ref PangyaBinaryReader reader, uint LenghtStr)
        {
            //------------------- IFF BASIC ----------------------------\\
            Enabled = reader.ReadUInt32();
            TypeID = reader.ReadUInt32();
            Name = reader.ReadPStr(LenghtStr);
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
            return MemberwiseClone();
        }

        public bool SetValue(IFFCommon common)
        {
            this.Name = common.Name;
            this.MinLevel = common.MinLevel;
            this.Icon = common.Icon;
            this.ItemPrice = common.ItemPrice;
            this.DiscountPrice = common.ItemPrice;
            this.Condition = common.Condition;
            this.PriceType = common.PriceType;
            this.MoneyFlag = common.MoneyFlag;
            this.TimeFlag = common.TimeFlag;
            this.TimeByte = common.TimeByte;
            this.TPItemCount = common.ItemPrice;
            this.TPCount = common.Condition;
            this.Mileage_Points = common.Mileage_Points;
            this.BonusProb = common.BonusProb;
            this.Bonus = common.Bonus;
            this.TikiPointShop = common.TikiPointShop;                    //
            this.TikiPang = common.TikiPang;
            this.DateStart = common.DateStart;
            this.DateEnd = common.DateEnd;
            return true;
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

        public _stFlagShop GetFlagShop()
        {
            BitArray bits = new BitArray(BitConverter.GetBytes((short)PriceType));
            bits = PadToFullByte(bits);
           var flag =new _stFlagShop
            {
                is_cash = bits.Get(0),//
                can_send_mail_and_personal_shop = bits.Get(1),
                can_dup = bits.Get(2),
                special = bits.Get(3),//special
                block_mail_and_personal_shop = bits.Get(4),//new?
                is_saleable = bits.Get(5), // Pang(Only Purchase, CP Gift and Purchase) (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
                is_giftable = bits.Get(6), // CP só pode ser presenteado (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
                only_display = bits.Get(7),    // Apenas Display no shop	
                
            };
            flag.hide_shop = flag.IsHide();

            //bits = new BitArray(BitConverter.GetBytes((short)MoneyFlag));
            //bits = PadToFullByte(bits);

            //var flag2 = new _stFlagShop
            //{
            //    is_cash = bits.Get(0),//
            //    can_send_mail_and_personal_shop = bits.Get(1),
            //    can_dup = bits.Get(2),
            //    special = bits.Get(3),//special
            //    block_mail_and_personal_shop = bits.Get(4),//new?
            //    is_saleable = bits.Get(5), // Pang(Only Purchase, CP Gift and Purchase) (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
            //    is_giftable = bits.Get(6), // CP só pode ser presenteado (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
            //    only_display = bits.Get(7),    // Apenas Display no shop	

            //};
            //flag.is_giftable = true;
            //flag.hide_shop = false;
            //SetFlagShop(ref flag);
            return flag;
        }

        public void SetFlagShop(ref _stFlagShop flagShop)
        {
            BitArray bits = new BitArray(8, false);

            if (flagShop.is_cash)
            {
                bits.Set(0, true);
            }
            if (flagShop.can_send_mail_and_personal_shop)
            {
                bits.Set(1, true);
            }
            if (flagShop.special)
            {
                //bits.SetAll(true);
                bits[3] =(true);
            }
            if (flagShop.block_mail_and_personal_shop)
            {
                bits.Set(4, true);
            }
            if (flagShop.is_saleable)
            {
                bits.Set(5, true);
            }
            if (flagShop.is_giftable)
            {
                bits.Set(6, true);
            }
            if (flagShop.hide_shop)
            {
                for (int i = 0; i < 8; i++)
                {
                    bits.Set(i, false);
                }
            }

            PriceType = (ShopFlag)ConvertToByte(bits);

            flagShop = new _stFlagShop
            {
                is_cash = bits.Get(0),//
                can_send_mail_and_personal_shop = bits.Get(1),
                can_dup = bits.Get(2),
                special = bits.Get(3),//special
                block_mail_and_personal_shop = bits.Get(4),//new?
                is_saleable = bits.Get(5), // Pang(Only Purchase, CP Gift and Purchase) (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
                is_giftable = bits.Get(6), // CP só pode ser presenteado (is_saleable e is_giftable vira flag de só Purchase CP ou Pang)
                only_display = bits.Get(7),    // Apenas Display no shop	

            };

            flagShop.hide_shop = flagShop.IsHide();
        }

        BitArray PadToFullByte(BitArray bits)
        {
            BitArray array = new BitArray(8, false);
            if (bits.Count > 0)
            {
                for (int i = 0; i < bits.Count; i++)
                {
                    if ((bits.Count > 8) && (i < 8))
                    {
                        array.Set(i, bits[i]);
                    }
                }
            }
            return array;
        }

        byte ConvertToByte(BitArray bits)
        {
            byte[] array = new byte[1];
            bits.CopyTo(array, 0);
            return array[0];
        }

        public bool IsBuyItem()
        {

            var flag_shop = GetFlagShop();

            return (Enabled == 1 && flag_shop.is_saleable);
        }

        public bool IsGiftItem()
        {
            var flag_shop = GetFlagShop();

            // É saleable ou giftable nunca os 2 juntos por que é a flag composta Somente Purchase(compra)
            // então faço o xor nas 2 flag se der o valor de 1 é por que ela é um item que pode presentear
            // Ex: 1 + 1 = 2 Não é
            // Ex: 1 + 0 = 1 OK
            // Ex: 0 + 1 = 1 OK
            // Ex: 0 + 0 = 0 Não é
            byte is_giftable =Convert.ToByte(flag_shop.is_giftable);
            byte is_saleable = Convert.ToByte(flag_shop.is_saleable);
            return (Enabled == 1 && flag_shop.is_cash
                    && (is_saleable ^ is_giftable) == 1);
        }

        public bool IsOnlyDisplay()
        {
            var flag_shop = GetFlagShop();
            return (Enabled == 1 && flag_shop.only_display);
        }

        public bool IsOnlyPurchase()
        {
            var flag_shop = GetFlagShop();
            return (Enabled == 1 && flag_shop.is_saleable
                    && flag_shop.is_giftable);
        }

        public bool IsOnlyGift()
        {
            var flag_shop = GetFlagShop();

            return (Enabled == 1 && flag_shop.is_cash
                    && flag_shop.is_giftable&& flag_shop.is_saleable == false);
        }

        public bool IsPSQ()
        {
            var flag_shop = GetFlagShop();

            return (Enabled == 1 && flag_shop.can_send_mail_and_personal_shop);
        }



        public uint GetTypeCard()
        {
            return GetItemSubGroupIdentify22(TypeID);
        }
    }
}
