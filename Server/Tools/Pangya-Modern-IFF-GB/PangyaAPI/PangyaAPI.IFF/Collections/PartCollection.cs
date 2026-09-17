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
    public class PartCollection : IFFEntryList<Part>
    {
        /// <summary>
        /// parses the Part.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the Part.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));
                
                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new Part());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new Part())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    var item = (Part)Reader.Read(new Part());                    
                    //if (item.Icon != "")
                    //{
                        this.Add(item);
                    //}
                }
                this.OrderBy(c=> c.TypeID);
            }
            catch(Exception ex)
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

        public Part GetItem(uint TypeID)
        {
            Part Part = new Part();
            if (!LoadItem(TypeID, ref Part))
            {
                return Part;
            }
            return Part;
        }

        public override string GetItemName(uint TypeID)
        {
            Part item = new Part();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            Part item = new Part();
            if (!LoadItem(TypeID, ref item))
            {
                return 99999999;
            }
            return item.ItemPrice;
        }

        public uint GetRentalPrice(uint TypeId)
        {
            Part item = new Part();
            if (!LoadItem(TypeId, ref item))
            {
                return 0;
            }
            if ((item.Enabled == 1))
            {
                return item.RentPang;
            }
            return 0;
        }

        public override sbyte GetShopPriceType(uint TypeId)
        {
            Part item = new Part();
            if (!LoadItem(TypeId, ref item))
            {
                return -1;
            }
            return item.GetShopPriceType();
        }

        public override bool IsBuyable(uint TypeId)
        {
            Part item = new Part();
            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }
           return item.IsBuyable();
        }

        public override bool IsExist(uint TypeId)
        {
            Part item = new Part();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public bool LoadItem(uint ID, ref Part item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
               item = (Part)value;
                return false;
            }
            item = (Part)value;
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
                foreach (Part item in this)
                {
                    var entry = item;
                    if (entry.ItemPrice >= 10000000)
                    {
                        entry.ItemPrice = 99999;
                        entry.DiscountPrice = 0;
                    }
                    //if (ActiveNewItens)
                    //{
                    //    ActiveAll(ref entry);
                    //}
                    ////if (entry.Icon != "" && entry.PriceType == 0)
                    ////{
                    ////    if (entry.ItemPrice >= 10000000)
                    ////    {
                    ////        entry.ItemPrice = 99999;
                    ////    }
                    ////    entry.Personal_Shop_Active();
                    ////}
                    writer.WriteStruct(entry);
                }
                File.WriteAllBytes(filePath, writer.GetBytes());
                Update = true;
            }
        }

        //public void IffSave2(PartCollection PartList)
        //{
        //    Header.Count = (short)PartList.Count;
        //    using (PangyaBinaryWriter writer = new PangyaBinaryWriter())
        //    {
        //        writer.WriteStruct(Header);
        //        foreach (Part item in this)
        //        {
        //            var entry = item;
        //            writer.WriteStruct(entry);
        //        }
        //        File.WriteAllBytes(filePath, writer.GetBytes());
        //    }
        //}

        public void ActiveAll(ref Part entry)
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
            string data ="";
            foreach (Part item in this)
            {
                var entry = item;
                if (entry.PriceType == Definitions.ShopFlag.NonGiftable && entry.MoneyFlag == Definitions.MoneyFlag.None && entry.TimeByte == 0 && entry.TimeFlag == 0)
                {
                  data +=($"\n case {entry.TypeID}:" +
                        $"\nbreak;");                    
                }
            }
            File.WriteAllText("Itens_Active_In_Personal_Shop2.txt", data);
        }
    }
}
