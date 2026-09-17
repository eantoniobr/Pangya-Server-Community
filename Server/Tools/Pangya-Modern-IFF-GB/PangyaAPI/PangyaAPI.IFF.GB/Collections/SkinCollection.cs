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
    public class SkinCollection : IFFEntryList<Skin>
    {
        /// <summary>
        /// parses the Skin.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the Skin.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new Skin());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new Skin())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(8);
                    var name = Reader.ReadPStr(40);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (Skin)Reader.Read(new Skin());
                    item.Name = name;
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

        public Skin GetItem(uint TypeID)
        {
            Skin Skin = new Skin();
            if (!LoadItem(TypeID, ref Skin))
            {
                return Skin;
            }
            return Skin;
        }

        public override string GetItemName(uint TypeID)
        {
            Skin item = new Skin();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            Skin item = new Skin();
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
            Skin item = new Skin();
            if (!LoadItem(TypeId, ref item))
            {
                return -1;
            }
            return (sbyte)item.PriceType;
        }

        public override bool IsBuyable(uint TypeId)
        {
            Skin item = new Skin();
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
            Skin item = new Skin();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public UInt32 GetPrice(UInt32 TypeID, uint Day)
        {
            foreach (var Item in this)
            {
                if (Item.Enabled == 1 && Item.TypeID == TypeID)
                {
                    switch (Day)
                    {
                        case 1:
                            return Item.Price7Day;
                        case 15:
                            return Item.Price15Day;
                        case 30:
                            return Item.Price30Day;
                    }
                }

                if (Item.Price7Day == 0 && Item.Price15Day == 0 && Item.Price30Day == 0 && Item.TypeID == TypeID)
                {
                    return (uint)Item.PriceType;
                }
            }

            return 0;
        }

        public byte GetSkinFlag(UInt32 TypeId)
        {
            Skin Items = new Skin();
            if (!LoadItem(TypeId, ref Items))
            {
                return 0;
            }
            if ((Items.TypeID == TypeId) && (Items.Enabled == 1))
            {
                if ((Items.Price7Day == 0) && (Items.Price30Day == 0) && (Items.Price15Day == 0))
                {
                    return 0;
                }
                else
                {
                    return 0x20;
                }
            }
            return 0;
        }

        public bool LoadItem(uint ID, ref Skin item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (Skin)value;
                return false;
            }
            item = (Skin)value;
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
                foreach (Skin item in this)
                {
                    var entry = item;
                    if (ActiveNewItens)
                    {
                        ActiveAll(ref entry);
                    }
                    writer.WriteStruct(entry);
                }
                File.WriteAllBytes(filePath, writer.GetBytes());
            }
        }

        public void ActiveAll(ref Skin entry)
        {
            //what func?
        }
    }
}
