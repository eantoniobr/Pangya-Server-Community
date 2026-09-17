using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using PangyaAPI.IFF.Lister;
using System.Diagnostics;

namespace PangyaAPI.IFF.Collections
{
    public class FurnitureCollection : IFFEntryList<Furniture>
    {
        /// <summary>
        /// parses the Furniture.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the Furniture.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new Furniture());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new Furniture())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(8);
                    var name = Reader.ReadPStr(40);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (Furniture)Reader.Read(new Furniture());
                    item.Name = name;

                    //if (item.Icon != "")
                    //{
                    this.Add(item);
                    //}
                }
                this.OrderBy(c => c.TypeID);
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace trace = new StackTrace(ex, true);
                var frame = trace.GetFrame(0);
                Console.WriteLine("Local: {0} ", frame.GetFileName());
            }
            finally
            {
                Reader.Dispose();
            }
        }

        public Furniture GetItem(uint TypeID)
        {
            Furniture Furniture = new Furniture();
            if (!LoadItem(TypeID, ref Furniture))
            {
                return Furniture;
            }
            return Furniture;
        }

        public override string GetItemName(uint TypeID)
        {
            Furniture item = new Furniture();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            Furniture item = new Furniture();
            if (!LoadItem(TypeID, ref item))
            {
                return 99999999;
            }
            return item.ItemPrice;
        }

        public uint GetRentalPrice(uint TypeId)
        {
            Furniture item = new Furniture();
            if (!LoadItem(TypeId, ref item))
            {
                return 0;
            }
           
            return 0;
        }

        public override sbyte GetShopPriceType(uint TypeId)
        {
            Furniture item = new Furniture();
            if (!LoadItem(TypeId, ref item))
            {
                return -1;
            }
            return item.GetShopPriceType();
        }

        public override bool IsBuyable(uint TypeId)
        {
            Furniture item = new Furniture();
            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }
            return item.IsBuyable();
        }

        public override bool IsExist(uint TypeId)
        {
            Furniture item = new Furniture();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public bool LoadItem(uint ID, ref Furniture item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (Furniture)value;
                return false;
            }
            item = (Furniture)value;
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
                foreach (Furniture item in this)
                {
                    var entry = item;
                    writer.WriteStruct(entry);
                }
                File.WriteAllBytes(filePath, writer.GetBytes());
            }
        }
        public void ActiveAll(ref Furniture entry)
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

        public void Check_Active_In_Personal_Shop()
        {
            string data = "";
            foreach (Furniture item in this)
            {
                var entry = item;
                if (entry.PriceType == Definitions.ShopFlag.NonGiftable && entry.MoneyFlag == Definitions.MoneyFlag.None && entry.TimeByte == 0 && entry.TimeFlag == 0)
                {
                    data += ($"\n name: {item.Name} | TypeID: {entry.TypeID}\n");
                }
            }
            File.WriteAllText("Itens_Active_In_Personal_Shop.txt", data);
        }
    }
}
