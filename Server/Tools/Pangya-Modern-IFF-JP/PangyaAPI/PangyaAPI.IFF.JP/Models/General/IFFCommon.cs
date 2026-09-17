using System;
using System.Runtime.InteropServices;
using PangyaAPI.IFF.JP.Models.Flags;
using PangyaAPI.IFF.JP.Extensions;
using System.Text;
namespace PangyaAPI.IFF.JP.Models.General
{
    /// <summary>
    /// Ref's:
    /// my code first: https://github.com/oung/Py_Source_JP/tree/master/Src/PangyaFileCore
    ///<code></code>
    /// replace: https://github.com/Acrisio-Filho/SuperSS-Dev/blob/master/Server%20Lib/Projeto%20IOCP/TYPE/data_iff.h
    /// update in 30/06/2023 - 10:40 AM by LuisMK
    ///<code></code>
    /// Common data structure found at the head of many IFF datasets
    ///<code></code>
    /// Size 192 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public partial class IFFCommon : ICloneable
    {
        //------------------- IFF BASIC ----------------------------\\
        /// <summary>
        /// Active item
        /// </summary>
        [field: MarshalAs(UnmanagedType.Bool, SizeConst = 4)]
        public bool Active { get; set; }//0 start position
        /// <summary>
        /// Tipo Index do item
        /// </summary>
        public uint ID { get; set; }//4 start position
        /// <summary>
        /// nome do item em bytes
        /// </summary>
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        byte[] NameInBytes { get; set; }//8 start position
        /// <summary>
        /// level do item
        /// </summary>
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 1)]
        public IFFLevel Level { get; set; }//72 start position
        /// <summary>
        /// Nome do icone 
        /// </summary>
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 43)]  //is 40, 3 bytes isnt used 
        public string ShopIcon { get; set; }//73 start position 
        //--------------------------end--------------------------------\\

        //------------------ SHOP DADOS ---------------------------------\\
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFShopData Shop { get; set; } = new IFFShopData();  //116 start position
        //-------------------  END  ------------------------------\\
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 24)]
        public IFFTikiShopData tiki { get; set; } = new IFFTikiShopData(); //132 start position
        //-------------------- TIME IFF--------------\\
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 36)]
        public IFFDate date { get; set; } = new IFFDate(); //176 start position
        public string Name
        {
            get => Encoding.GetEncoding("Shift_JIS").GetString(NameInBytes ?? (new byte[0])).Replace("\0", "");
            set => NameInBytes = Encoding.GetEncoding("Shift_JIS").GetBytes(value.PadRight(64, '\0'));
        }
        /// <summary>
        /// voce pode carregar qualquer iff(que contem o Base)
        /// </summary>
        /// <param name="reader">binario de leitura</param>
        /// <param name="LenghtStr">tamanho do string name</param>
        public void Load(ref PangyaBinaryReader reader, uint LenghtStr, long recordLength = 0, uint version = 11, bool jump = false)
        {
            //------------------- IFF BASIC ----------------------------\\
            Active = reader.ReadUInt32() > 0;
            ID = reader.ReadUInt32();
            Name = reader.ReadPStr(LenghtStr);
            Level = new IFFLevel
            {
                level = reader.ReadByte() //49 start position
            };
            ShopIcon = reader.ReadPStr(43); //89 start position
            //--------------------------end--------------------------------\\
            //------------------ SHOP DADOS ---------------------------------\\
            Shop = (IFFShopData)reader.Read(new IFFShopData(), 16);
            //-------------------  END  ------------------------------\\
            //------------------ Tiki SHOP---------------------\\
            if (version != 11)
            {
                tiki = (IFFTikiShopData)reader.Read(new IFFTikiShopData(), 24);
            }
            //-----------------------------------------------\\

            //-------------------- TIME IFF--------------\\
            date = (IFFDate)reader.Read(new IFFDate(), 36);
            //--------------------------------------------------\\
            if (jump)
            {
                reader.Skip(36);
            }
        }
        /// <summary>
        /// voce pode carregar qualquer iff(que contem o Base)
        /// </summary>
        /// <param name="reader">binario de leitura</param>
        /// <param name="LenghtStr">tamanho do string name</param>
        public void Load(ref PangyaBinaryReader reader, uint LenghtStr)
        {
            //------------------- IFF BASIC ----------------------------\\
            Active = reader.ReadUInt32() > 0;
            ID = reader.ReadUInt32();
            Name = reader.ReadPStr(LenghtStr);
            Level = new IFFLevel
            {
                level = reader.ReadByte() //49 start position
            };
            ShopIcon = reader.ReadPStr(43); //89 start position
            //--------------------------end--------------------------------\\
            //------------------ SHOP DADOS ---------------------------------\\
            Shop = (IFFShopData)reader.Read(new IFFShopData(), 16);
            //-------------------  END  ------------------------------\\
            //------------------ Tiki SHOP---------------------\\
            tiki = (IFFTikiShopData)reader.Read(new IFFTikiShopData(), 24);
            //-----------------------------------------------\\

            //-------------------- TIME IFF--------------\\
            date = (IFFDate)reader.Read(new IFFDate(), 36);
            //--------------------------------------------------\\
        }
        /// <summary>
        /// Envia uma notificao ao Editor/Dev 
        /// voce n�o pode listar este item pois o valor ira 
        /// ativar um codigo no ProjectG de alerta
        /// </summary>
        public bool SendMessage()
        {
            bool result = Shop.flag_shop.can_send_mail_and_personal_shop
             || Shop.flag_shop.block_mail_and_personal_shop
             || Shop.flag_shop.IsSale;
            if (result && Shop.Price >= 999999990)
            {
                var check = (Shop.flag_shop.ShopFlag == ShopFlag.BannerNew &&
                  Shop.flag_shop.MoneyFlag == MoneyFlag.None);
                if (Shop.flag_shop.IsShop && !check) //psq pode ter valor alto, mas se for um psq especifico, não pode
                {
                    // MessageBox.Show($"\nBe careful, you activated an item, but did not change its price({999999990})\n check this item({ID})", "Pangya Modern Editor");
                    return true;
                }
            }
            return false;

        }


        public string GetItemName()
        {
            return Name;
        }
        public uint Price
        {
            get => Shop == null ? 0 : Shop.Price;
            set => Shop.Price = value;
        }
        public byte ItemLevel
        {
            get => (byte)(Level == null ? 0 : Level.level);
            set => Level.level = value;
        }
        public uint DiscountPrice
        {
            get => Shop == null ? 0 : Shop.DiscountPrice;
            set => Shop.DiscountPrice = value;
        }


        public bool IsExist()
        {
            return Convert.ToBoolean(Active);
        }
        //conversion this 
        public virtual IFFCommon CreateNewItem()
        {
            Name = "";
            ShopIcon = "";
            date = new IFFDate
            {
                End = new IFFTime(),
                Start = new IFFTime()
            };
            tiki = new IFFTikiShopData
            {
                Bonus = new short[2]
            };
            Shop = new IFFShopData
            {
                flag_shop = new FlagShop()
            };
            Level = new IFFLevel();
            Shop.flag_shop.time_shop = new TimeShop();
            return this;
        }

        public IFFCommon()
        {
            Name = "";
            ShopIcon = "";
            date = new IFFDate
            {
                End = new IFFTime(),
                Start = new IFFTime()
            };
            tiki = new IFFTikiShopData
            {
                Bonus = new short[2]
            };
            Shop = new IFFShopData
            {
                flag_shop = new FlagShop()
            };
            Level = new IFFLevel();
            Shop.flag_shop.time_shop = new TimeShop();
        }

        public void GenerateID(uint iffType, uint num, uint serial)
        {
            ID = GenerateNewTypeID(iffType, 0, num, 2, 0, serial);
        }
        public void GenerateID(uint iffType, uint charID, uint pos, uint type, uint serial)
        {
            ID = GenerateNewTypeID(iffType, charID, pos, 2, type, serial);
        }
        uint GenerateNewTypeID(uint iffType, uint characterId, uint pos, uint group, uint type, uint serial)
        {
            if (group - 1 < 0)
            {
                group = 0;
            }
            return (uint)Convert.ToUInt64((iffType * Math.Pow(2.0, 26.0)) + (characterId * Math.Pow(2.0, 18.0)) + (pos * Math.Pow(2.0, 13.0)) + (group * Math.Pow(2.0, 11.0)) + (type * Math.Pow(2.0, 9.0)) + serial);
        }

        public bool IsDupItem()
        {
            return Active && Shop.flag_shop.IsDuplication;
        }

        public bool IsSale()
        {
            return Active && Shop.flag_shop.IsShop;
        }

        public bool IsHot()
        {
            return Shop.flag_shop.IsHot && Active;
        }

        public bool IsNormal()
        {
            return Active && (Shop.flag_shop.IsNormal);
        }

        public bool IsNew()
        {
            if (IsHide)
            {
                return false;
            }
            return Active && Shop.flag_shop.IsNew;
        }

        public bool IsGiftItem()
        {
            // � saleable ou giftable nunca os 2 juntos por que � a flag composta Somente Purchase(compra)
            // ent�o fa�o o xor nas 2 flag se der o valor de 1 � por que ela � um item que pode presentear
            // Ex: 1 + 1 = 2 N�o �
            // Ex: 1 + 0 = 1 OK
            // Ex: 0 + 1 = 1 OK
            // Ex: 0 + 0 = 0 N�o �
            byte is_giftable = Convert.ToByte(Shop.flag_shop.IsGift);
            byte _is_saleable = Convert.ToByte(Shop.flag_shop.IsSale);
            if (Active && Shop.flag_shop.IsCash
                    && (_is_saleable ^ is_giftable) == 1)
            {
                return true;
            }
            else if (Shop.flag_shop.IsGift)
            {
                return true;
            }
            return false;
        }

        public bool IsOnlyDisplay()
        {
            return (Active && Shop.flag_shop.IsDisplay);
        }

        public bool IsOnlyPurchase()
        {
            return (Active && Shop.flag_shop.IsSale
                    && Shop.flag_shop.IsGift);
        }

        public bool IsOnlyGift()
        {
            return (Active && Shop.flag_shop.IsCash
                    && Shop.flag_shop.IsSale && Shop.flag_shop.IsGift == false);
        }

        public bool IsPSQ()
        {
            if (Active)
            {
                if (Shop.flag_shop.IsPSQ)
                {
                    return true;
                }
                if (Shop.flag_shop.IsTradeable)
                {
                    return true;
                }
                if (Shop.flag_shop.can_send_mail_and_personal_shop)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public bool IsHide  // 98% 
        {
            get
            {
                if (date.Start.TimeActive)
                {

                    if (date.Start.Year >= DateTime.Now.Year && date.Start.Day >= DateTime.Now.Day && date.Start.Month >= DateTime.Now.Month)
                        return false;
                    if (DateTime.Now.Year > date.Start.Year && DateTime.Now.Day > date.Start.Day && DateTime.Now.Month > date.Start.Month && !Shop.flag_shop.IsShop)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.None;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                        Price = 999999990;
                        date.Clear();
                        return true;
                    }
                    if (date.Start.Year < DateTime.Now.Year && Shop.flag_shop.IsShop)   //tempo antigo 2007-2008
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.None;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                        Price = 999999990;
                        date.Clear();
                        return true;
                    }
                }
                if (DateTime.Now.Year > date.Start.Year && DateTime.Now.Day > date.Start.Day && DateTime.Now.Month > date.Start.Month && !Shop.flag_shop.IsShop)
                    if (date.Start.Year == 0)
                    {
                        date.Clear();
                        if (Shop.flag_shop.MoneyFlag == 0 && Shop.flag_shop.ShopFlag == 0)
                        {
                            return true;
                        }
                        if (Shop.flag_shop.MoneyFlag == 0 && Shop.flag_shop.ShopFlag == ShopFlag.BannerNew)
                        {
                            return false;
                        }

                        if (Shop.flag_shop.ShopFlag == (ShopFlag)6 && Shop.flag_shop.MoneyFlag == 0)
                        {
                            return true;
                        }
                        if (Shop.flag_shop.MoneyFlag == 0 && Shop.flag_shop.ShopFlag == 0)
                        {
                            return true;
                        }
                        if (Shop.flag_shop.MoneyFlag == 0 && Shop.flag_shop.ShopFlag == ShopFlag.BannerNew)
                        {
                            return false;    // é psq
                        }
                        if (Shop.flag_shop.MoneyFlag == (MoneyFlag)21 && Shop.flag_shop.ShopFlag == ShopFlag.BannerNew)
                        {
                            return true;
                        }
                        if (Shop.flag_shop.ShopFlag == ShopFlag.Giftable && Shop.flag_shop.MoneyFlag == MoneyFlag.BannerNew)
                        {
                            return true;
                        }
                        if (Shop.flag_shop.ShopFlag == 0 && Shop.flag_shop.MoneyFlag == MoneyFlag.BannerNew)
                        {
                            return true;
                        }
                        if (Shop.flag_shop.ShopFlag == 0 && Shop.flag_shop.MoneyFlag == MoneyFlag.Active)
                        {
                            return true;
                        }

                        if (Shop.flag_shop.ShopFlag == ShopFlag.Combine96 && Shop.flag_shop.MoneyFlag == MoneyFlag.BannerNew)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                        return true;

                if (Shop.flag_shop.ShopFlag == ShopFlag.Combine96 && Shop.flag_shop.MoneyFlag == MoneyFlag.BannerNew)
                {
                    return false;
                }
                if (date.Start.Year > 0 && date.Start.Day > 0 && DateTime.Now.Year > date.Start.Year && DateTime.Now.Day > date.Start.Day && Shop.flag_shop.IsShop)
                {
                    return true;
                }
                if (!Shop.flag_shop.IsNormal && (!Shop.flag_shop.IsSale || !Shop.flag_shop.can_send_mail_and_personal_shop || !Shop.flag_shop.IsDuplication) && !Shop.flag_shop.IsNew && !IsGiftItem() && !Shop.flag_shop.IsHot && !Shop.flag_shop.IsDisplay)
                {
                    return true;
                }
                if (Shop.flag_shop.ShopFlag == (ShopFlag)6 && Shop.flag_shop.MoneyFlag == 0)
                {
                    return true;
                }

                if (Shop.flag_shop.ShopFlag == ShopFlag.Giftable && Shop.flag_shop.MoneyFlag == MoneyFlag.Active)
                {
                    return true;
                }
                if (Shop.flag_shop.ShopFlag == ShopFlag.Giftable && Shop.flag_shop.MoneyFlag == MoneyFlag.Active)
                {
                    return true;
                }
                //if (Shop.flag_shop.ShopFlag == ShopFlag.Combine96 && Shop.flag_shop.MoneyFlag == 0)
                //{
                //    return true;
                //}

                if (Shop.flag_shop.ShopFlag == ShopFlag.Combine96 && Shop.flag_shop.MoneyFlag == MoneyFlag.Active)
                {
                    return false;
                }

                //if (Shop.flag_shop.ShopFlag == ShopFlag.Pang && Shop.flag_shop.MoneyFlag == 0)  //ativo na loja
                //{
                //    return true;
                //}
                return false;
            }
        }
        public int GetTypeCashDB()
        {
            if (Shop.flag_shop.IsShop)
            {
                if (IsPSQ())
                    return 5; //esta ativo os dois

                if (Shop.flag_shop.IsCash || Shop.flag_shop.IsPang)
                    return 3;
            }
            else if (IsPSQ())
            {
                return 4;
            }
            return 0;
        }
        /// <summary>
        /// verifica � pang, cookie ou esta oculto dentro do shopping
        /// </summary>
        /// <returns>0= cookies, 1= pang, 2= hide </returns>
        public int GetTypeCash()
        {
            if (IsHide)
                return 0;

            else if (Shop.flag_shop.IsCash)
                return 1;
            else if (Shop.flag_shop.IsPang)
                return 2;
            else if (Shop.flag_shop.IsDisplay)
                return 3;
            else if (IsPSQ())  // � hide no shop normal, porem no psq � ativo, tenho que ver um codigo melhor depois
            {
                if (Shop.flag_shop.IsCash)
                    return 1;
                else if (Shop.flag_shop.IsPang)
                    return 2;
                return 0;
            }
            return 0;
        }

        public void SetItemNew(int tipoMoeda)
        {
            SetFlagShop(tipoMoeda, IsNew: true, IsHot: false, IsNormal: false, IsPSQ: false, IsDesativado: false, Is_OnlyDisplay: false, IsGift: false, IsSpecial: false);
        }

        public void SetItemHot(int tipoMoeda)
        {
            SetFlagShop(tipoMoeda, IsNew: false, IsHot: true, IsNormal: false, IsPSQ: false, IsDesativado: false, Is_OnlyDisplay: false, IsGift: false, IsSpecial: false);
        }

        public void SetItemNormal(int tipoMoeda)
        {
            SetFlagShop(tipoMoeda, IsNew: false, IsHot: false, IsNormal: true, IsPSQ: false, IsDesativado: false, Is_OnlyDisplay: false, IsGift: false, IsSpecial: false);
        }

        public void SetItemPSQ(int tipoMoeda)
        {
            SetFlagShop(tipoMoeda, IsNew: false, IsHot: false, IsNormal: false, IsPSQ: true, IsDesativado: false, Is_OnlyDisplay: false, IsGift: false, IsSpecial: false);
        }

        public void SetItemGift(int tipoMoeda)
        {
            SetFlagShop(tipoMoeda, IsNew: false, IsHot: false, IsNormal: true, IsPSQ: false, IsDesativado: false, Is_OnlyDisplay: false, IsGift: true, IsSpecial: false);
        }

        public void SetItemDesativado()
        {

            SetFlagShop(0, IsNew: false, IsHot: false, IsNormal: false, IsPSQ: false, IsDesativado: true, Is_OnlyDisplay: false, IsGift: false, IsSpecial: false);
        }

        public void SetItemDisplay()
        {
            SetFlagShop(0, IsNew: false, IsHot: false, IsNormal: false, IsPSQ: false, IsDesativado: false, Is_OnlyDisplay: true, IsGift: false, IsSpecial: false);
        }

        /// <summary>
        /// seta tipo de bandeira a ser exibida no shopFlag
        /// </summary>
        /// <param name="tipoMoeda">false = pang, true = cookies</param>
        /// <param name="IsNew">novo item</param>
        /// <param name="IsHot">item quente</param>
        /// <param name="IsNormal"> item normal</param>
        /// <param name="IsPSQ"> item personal shop</param>
        /// <param name="IsGift">item gift</param>
        /// <param name="IsDesativado">desativado</param>
        /// <param name="Is_OnlyDisplay">item para ficar visivel, mas não pode comprar</param>
        public void SetFlagShop(int tipoMoeda /*pang = false*/, bool IsNew = false, bool IsHot = false, bool IsNormal = false, bool IsPSQ = false, bool IsDesativado = false, bool Is_OnlyDisplay = false, bool IsGift = false, bool IsSpecial = false)
        {

            if (Is_OnlyDisplay)
            {
                Shop.flag_shop.ShopFlag = ShopFlag.Only_Display;
                Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                Price = 999999990;
                return;
            }
            else if (IsDesativado)
            {
                Shop.flag_shop.ShopFlag = ShopFlag.None;
                Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                Price = 999999990;
                return;
            }
            if (tipoMoeda == 0)
            {
                if (IsNew == false && IsHot == false && IsNormal == false && IsPSQ == false && Is_OnlyDisplay == false && IsGift == false && IsSpecial == false)
                {
                    Shop.flag_shop.ShopFlag = ShopFlag.None;
                    Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                    Price = 999999990;
                }
            }
            else
            {
                ///corrigir alguns aqui:
                if (tipoMoeda == 2) // pangs
                {
                    if (IsNew && IsGift && IsNormal) //new, gift, item normal(precisa melhorar)
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)32;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.Active;
                        IsGift = false;
                        IsNew = false;
                        IsNormal = false;
                    }
                    if (IsHot && IsGift && IsNormal) //hot, gift, item normal(precisa fazer correto)
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)32;
                        Shop.flag_shop.MoneyFlag = (MoneyFlag)02;

                        IsGift = false;
                        IsHot = false;
                        IsNormal = false;
                    }
                    if (IsNew && IsGift) //new, gift, item normal(precisa melhorar)
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)32;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.Active;
                        IsGift = false;
                        IsNew = false;
                        IsNormal = false;
                    }
                    if (IsNew && IsPSQ) //new, gift, item normal(meu codigo)
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)34;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.Active;
                        IsNew = false;
                        IsPSQ = false;
                    }
                    if (IsPSQ && IsGift) // combinacao dos 3(ativo no shop normal e tambem no psq)
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)34;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                        IsPSQ = false;
                        IsGift = false;
                    }
                    if (IsHot && IsGift) // gift + hot
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)34;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.BannerNew;
                        IsHot = false;
                        IsGift = false;
                    }
                    //sem combinacoes
                    if (IsHot)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Combine96;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.BannerNew;
                    }
                    else if (IsGift) // combinacao dos 3(ativo no shop normal e tambem no psq)
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)32;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                    }
                    else if (IsPSQ) // combinacao dos 3(ativo no shop normal e tambem no psq)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.BannerNew;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                    }
                    else if (IsNew) // normal +new is cookies
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Pang; //tenho que ver depois aqui
                        Shop.flag_shop.MoneyFlag = (MoneyFlag)21;
                    }
                    else if (IsNormal) // isso é normal
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)96;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                    }
                }
                else if (tipoMoeda == 1) // cookies
                {
                    if (IsNew && IsGift && IsNormal) //new, gift, item normal(meu codigo)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Cookies_0;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.Active;
                        IsGift = false;
                        IsNew = false;
                        IsNormal = false;
                    }
                    if (IsHot && IsGift && IsNormal) //hot, gift, item normal(meu codigo)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Cookies_0;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.BannerNew;
                        IsHot = false;
                        IsGift = false;
                        IsNormal = false;
                    }
                    else if (IsGift && IsNormal) // combina item + gift(normal)
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)33;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                        IsGift = false;
                        IsNormal = false;
                    }
                    if (IsHot && IsNormal) // combina item + hot(flag hot)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Combine;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.BannerNew;
                        IsHot = false;
                        IsNormal = false;
                    }
                    if (IsHot && IsGift) // gift + hot
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Cookies_0;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.BannerNew;
                        IsHot = false;
                        IsGift = false;
                    }
                    else if (IsGift) // combinacao dos 3(vi hot + isGift)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Cookies_0;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                    }
                    else if (IsNew) // normal +new is cookies
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Cookies_0;
                        Shop.flag_shop.MoneyFlag = (MoneyFlag)21;
                    }
                    else if (IsHot) // somente hot
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.Combine;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.BannerNew;
                    }
                    else if (IsNormal) // somente normal :D
                    {
                        Shop.flag_shop.ShopFlag = (ShopFlag)97;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                    }
                    else if (IsPSQ) // combinacao dos 3(ativo no shop normal e tambem no psq)
                    {
                        Shop.flag_shop.ShopFlag = ShopFlag.BannerNew;
                        Shop.flag_shop.MoneyFlag = MoneyFlag.None;
                    }
                }
            }
            if (date.Start.TimeActive)
            {
                if (DateTime.Now.Year > date.Start.Year && DateTime.Now.Day > date.Start.Day && DateTime.Now.Month > date.Start.Month && !Shop.flag_shop.IsShop)
                {
                    date.Clear();
                }
                if (date.Start.Year < DateTime.Now.Year && Shop.flag_shop.IsShop)   //tempo antigo 2007-2008
                {
                    date.Clear();
                }
            }
            SendMessage();
        }

        object ICloneable.Clone()
        {
            return _Clone();
        }

        public virtual object _Clone()
        {
            var clone = (IFFCommon)MemberwiseClone();
            clone.NameInBytes = this.NameInBytes != null ? (byte[])this.NameInBytes.Clone() : null;
            clone.Level = this.Level?.Clone();
            clone.Shop = this.Shop?.Clone();
            clone.tiki = this.tiki?.Clone();
            clone.date = this.date?.Clone();
            return clone;
        }
    }
}
