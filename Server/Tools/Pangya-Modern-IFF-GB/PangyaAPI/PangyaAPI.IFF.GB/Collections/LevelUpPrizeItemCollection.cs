using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.IO;
using System.Runtime.InteropServices;
using PangyaAPI.IFF.Lister;
namespace PangyaAPI.IFF.Collections
{
    public class LevelUpPrizeItemCollection : IFFEntryList<LevelUpPrizeItem>
    {
        /// <summary>
        /// parses the LevelUpPrizeItem.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the LevelUpPrizeItem.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new LevelUpPrizeItem());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new LevelUpPrizeItem())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(8);
                    var name = Reader.ReadPStr(40);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (LevelUpPrizeItem)Reader.Read(new LevelUpPrizeItem());
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

        public LevelUpPrizeItem GetItem(uint TypeID)
        {
            LevelUpPrizeItem LevelUpPrizeItem = new LevelUpPrizeItem();
            if (!LoadItem(TypeID, ref LevelUpPrizeItem))
            {
                return LevelUpPrizeItem;
            }
            return LevelUpPrizeItem;
        }

        public override string GetItemName(uint TypeID)
        {
            LevelUpPrizeItem item = new LevelUpPrizeItem();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            return 0;
        }

        public uint GetRentalPrice(uint TypeId)
        {
            return 0;
        }

        public sbyte GetShopPriceType()
        {
           
            return 0;
        }

        public override sbyte GetShopPriceType(uint TypeId)
        {
            return 0;
        }

        public override bool IsBuyable(uint TypeId)
        {
            return false;
        }

        public override bool IsExist(uint TypeId)
        {
            return Convert.ToBoolean(0);
        }

        public bool LoadItem(uint ID, ref LevelUpPrizeItem item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (LevelUpPrizeItem)value;
                return false;
            }
            item = (LevelUpPrizeItem)value;
            return true;
        }

        public bool TryGetValue(uint ID, out object value)
        {
            value = new object();
            return false;
        }

        public override void IffSave(string filePath, bool ActiveNewItens)
        {
            Header.Count = (short)Count;
            using (PangyaBinaryWriter writer = new PangyaBinaryWriter())
            {
                writer.WriteStruct(Header);
                foreach (LevelUpPrizeItem item in this)
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

        public void ActiveAll(ref LevelUpPrizeItem entry)
        {
            //what func?
        }
    }
}
