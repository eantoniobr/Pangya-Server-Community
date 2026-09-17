using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using PangyaAPI.IFF.Lister;
namespace PangyaAPI.IFF.Collections
{
    public class CardCollection : IFFEntryList<Card>
    {
        /// <summary>
        /// parses the Card.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the Card.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new Card());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new Card())})");
                }
               // string pack_id = "";

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(8);
                    var name = Reader.ReadPStr(40);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (Card)Reader.Read(new Card());
                    item.Name = name;
                    this.Add(item);
                    //switch (item.TypeID)
                    //{
                    //    case 2088763415:

                    //    case 2092957696:

                    //    case 2092957700:

                    //    case 2092957701:

                    //    case 2092957703:

                    //    case 2092957704:

                    //    case 2092957705:

                    //    case 2092957707:

                    //    case 2092957708:

                    //    case 2092957709:

                    //    case 2092957710:

                    //    case 2092957711:

                    //    case 2092957712:

                    //    case 2092957713:

                    //    case 2092957714:

                    //    case 2092957715:

                    //    case 2092957716:

                    //    case 2092957717:

                    //    case 2092957718:

                    //    case 2092957719:

                    //    case 2092957720:

                    //    case 2092957721:

                    //    case 2092957722:

                    //    case 2092957723:

                    //    case 2092957724:
                    //        item.ItemPrice = 1900;
                    //        break;
                    //    default: break;
                    //}
                }
                    //File.WriteAllText("Card_Pack_List.txt",pack_id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Reader.Dispose();
            }
        }

        public Card GetItem(uint TypeID)
        {
            Card Card = new Card();
            if (!LoadItem(TypeID, ref Card))
            {
                return Card;
            }
            return Card;
        }

        public override string GetItemName(uint TypeID)
        {
            Card item = new Card();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            Card item = new Card();
            if (!LoadItem(TypeID, ref item))
            {
                return 99999999;
            }
            return item.ItemPrice;
        }

        public sbyte GetShopPriceType()
        {
            foreach (var item in this)
            {
                if (item.PriceType > 0)
                {
                    return (sbyte)item.PriceType;
                }
            }
            return 0;
        }

        public override sbyte GetShopPriceType(uint TypeId)
        {
            Card item = new Card();
            if (!LoadItem(TypeId, ref item))
            {
                return -1;
            }
            return (sbyte)item.PriceType;
        }

        public override bool IsBuyable(uint TypeId)
        {
            Card item = new Card();
            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }
            if (item.Enabled == 1 && item.MoneyFlag == 0 || (int)item.MoneyFlag == 1 || (int)item.MoneyFlag == 2)
            {
                return true;
            }
            return false;
        }

        public override bool IsExist(uint TypeId)
        {
            Card item = new Card();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public bool LoadItem(uint ID, ref Card item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (Card)value;
                return false;
            }
            item = (Card)value;
            return true;
        }

        public bool TryGetValue(uint ID, out object value)
        {
            if (this.Any(c => c.TypeID == ID))
            {
                value = this.First(c => c.TypeID == ID);
                return true;
            }
            value = new object();
            return false;
        }

        public override void IffSave(string filePath, bool ActiveNewItens)
        {
            Header.Count = (short)Count;
            using (PangyaBinaryWriter writer = new PangyaBinaryWriter())
            {
                writer.WriteStruct(Header);
                foreach (Card item in this)
                {
                    switch (item.TypeID)
                    {
                        case 2088763415:

                        case 2092957696:

                        case 2092957700:

                        case 2092957701:

                        case 2092957703:

                        case 2092957704:

                        case 2092957705:

                        case 2092957707:

                        case 2092957708:

                        case 2092957709:

                        case 2092957710:

                        case 2092957711:

                        case 2092957712:

                        case 2092957713:

                        case 2092957714:

                        case 2092957715:

                        case 2092957716:

                        case 2092957717:

                        case 2092957718:

                        case 2092957719:

                        case 2092957720:

                        case 2092957721:

                        case 2092957722:

                        case 2092957723:

                        case 2092957724:
                            ActiveNewItens = false;
                            break;
                        default:
                            ActiveNewItens = true;
                            break;
                    }
                    var entry = item;
                    if (ActiveNewItens)
                    {
                        ActiveAll(ref entry);
                    }
                    writer.WriteStruct(entry);
                }
                File.WriteAllBytes(filePath, writer.GetBytes());
                Update = true;
            }
        }

        public void ActiveAll(ref Card entry)
        {
            if (entry.Icon != "")
            {
                entry.PriceType = Definitions.ShopFlag.Unknown03;//ativa os card?
                entry.MoneyFlag = 0;
                entry.DiscountPrice = 0;
                entry.TimeFlag = 0;
                if (entry.ItemPrice >= 10000000)
                {
                    entry.ItemPrice = 99999;
                }
            }
        }
    }
}
