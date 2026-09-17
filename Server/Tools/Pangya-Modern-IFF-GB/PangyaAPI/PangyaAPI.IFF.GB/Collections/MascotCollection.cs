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
    public class MascotCollection : IFFEntryList<Mascot>
    {
        /// <summary>
        /// parses the Mascot.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the Mascot.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new Mascot());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                
                
                
                
                
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new Mascot())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(8);
                    var name = Reader.ReadPStr(40);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (Mascot)Reader.Read(new Mascot());
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

        public Mascot GetItem(uint TypeID)
        {
            Mascot Mascot = new Mascot();
            if (!LoadItem(TypeID, ref Mascot))
            {
                return Mascot;
            }
            return Mascot;
        }

        public override string GetItemName(uint TypeID)
        {
            Mascot item = new Mascot();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            Mascot item = new Mascot();
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
            Mascot item = new Mascot();
            if (!LoadItem(TypeId, ref item))
            {
                return -1;
            }
            return (sbyte)item.PriceType;
        }

        public override bool IsBuyable(uint TypeId)
        {
            Mascot item = new Mascot();
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
            Mascot item = new Mascot();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public UInt32 GetPrice(UInt32 TypeID, uint Day)
        {
            Mascot Mascot = new Mascot();
            if (!LoadItem(TypeID, ref Mascot))
            {
                return 0;
            }
            if (Mascot.Enabled == 1)
            {
                switch (Day)
                {
                    case 1:
                        return Mascot.Price1Day;
                    case 7:
                        return Mascot.Price7Day;
                    case 30:
                        return Mascot.Price30Day;
                }
            }

            if (Mascot.Price1Day == 0 && Mascot.Price7Day == 0 && Mascot.Price30Day == 0)
            {
                return (uint)Mascot.PriceType;
            }
            return 0;
        }

        public uint GetSalary(uint TypeId, uint Day)
        {
            Mascot Item = new Mascot();
            if (!LoadItem(TypeId, ref Item))
            {
                return 0;
            }
            if (Item.Enabled == 1)
            {
                switch (Day)
                {
                    case 1:
                        return Item.Price1Day;
                    case 7:
                        return Item.Price7Day;
                    case 30:
                        return Item.Price30Day;
                }
            }
            return 0;
        }

        public bool LoadItem(uint ID, ref Mascot item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (Mascot)value;
                return false;
            }
            item = (Mascot)value;
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
            ActiveNewItens = true;
            using (PangyaBinaryWriter writer = new PangyaBinaryWriter())
            {
                writer.WriteStruct(Header);
                foreach (Mascot item in this)
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

        public void ActiveAll(ref Mascot entry)
        {
            if (entry.Name.Contains("Game Pot"))
            {
                entry.PriceType = 0;
                entry.MoneyFlag = 0;
                entry.DiscountPrice = 0;
                entry.ItemPrice = 0;
            }
            if (entry.DiscountPrice == 58928)
            {
                entry.DiscountPrice = 0;
            }
            if (entry.Icon != "" && entry.PriceType == 0 && entry.Name.Contains("Game Pot") == false)
            {
                entry.PriceType = Definitions.ShopFlag.Active;
                entry.MoneyFlag = 0;
                entry.DiscountPrice = 0;
                entry.TimeFlag = 0x15;
                if (entry.ItemPrice >= 10000000)
                {
                    entry.ItemPrice = 99999;
                }
            }
        }
    }
}
