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
    public class SetItemCollection : IFFEntryList<SetItem>
    {
        /// <summary>
        /// parses the SetItem.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the SetItem.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data), System.Text.Encoding.GetEncoding("Shift_JIS"));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new SetItem());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new SetItem())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    var item = (SetItem)Reader.Read(new SetItem());
                    this.Add(item);
                }
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

        public SetItem GetItem(uint TypeID)
        {
            SetItem SetItem = new SetItem();
            if (!LoadItem(TypeID, ref SetItem))
            {
                return SetItem;
            }
            return SetItem;
        }

        public override string GetItemName(uint TypeID)
        {
            SetItem item = new SetItem();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            SetItem item = new SetItem();
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
            SetItem item = new SetItem();
            if (!LoadItem(TypeId, ref item))
            {
                return -1;
            }
            return (sbyte)item.PriceType;
        }

        public override bool IsBuyable(uint TypeId)
        {
            SetItem item = new SetItem();
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
            SetItem item = new SetItem();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public string GetSetItemStr(UInt32 TypeId)
        {
            string result = "";
            SetItem Items = new SetItem();
            UInt32 Count;
            if (!LoadItem(TypeId, ref Items))
            {
                return result;
            }
            if ((Items.Enabled == 1))
            {
                for (Count = 0; Count <= 9; Count++)
                {
                    if (!(Items.Item_TypeID[Count] > 0))
                    {
                        break;
                    }
                    result += string.Format("{0}, {1}", new object[] { Items.Item_TypeID[Count], Items.Item_Qty[Count] });
                }
                return result;
            }
            return result;
        }

        public bool LoadItem(uint ID, ref SetItem item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (SetItem)value;
                return false;
            }
            item = (SetItem)value;
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
            Update = true;
            Header.Count = (short)Count;
            using (PangyaBinaryWriter writer = new PangyaBinaryWriter())
            {
                writer.WriteStruct(Header);
                foreach (SetItem item in this)
                {
                    var entry = item;
                    entry.DiscountPrice = 0;

                    if (ActiveNewItens)
                    {
                        ActiveAll(ref entry);
                    }
                    writer.WriteStruct(entry);
                }
                File.WriteAllBytes(filePath, writer.GetBytes());
            }
        }

        public void ActiveAll(ref SetItem entry)
        {
            //what func?
        }
    }
}
