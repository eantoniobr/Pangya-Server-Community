using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using PangyaAPI.IFF.Lister;
using System.Windows.Forms;

namespace PangyaAPI.IFF.Collections
{
    public class GrandPrixDataCollection : IFFEntryList<GrandPrixData>
    {
        /// <summary>
        /// parses the GrandPrixData.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the GrandPrixData.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new GrandPrixData());

                if (!CheckVersionIFF())
                {
                    MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }

                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new GrandPrixData())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(18);
                    var name = Reader.ReadPStr(66);
                    Reader.Skip(208);
                    var info = Reader.ReadPStr(516);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (GrandPrixData)Reader.Read(new GrandPrixData());
                    item.Name = name;
                    item.Info = info;
                    if (item.TypeID == 26368)
                    {

                    }
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

        public GrandPrixData GetItem(uint TypeID)
        {
            GrandPrixData GrandPrixData = new GrandPrixData();
            if (!LoadItem(TypeID, ref GrandPrixData))
            {
                return GrandPrixData;
            }
            return GrandPrixData;
        }

        public override string GetItemName(uint TypeID)
        {
            GrandPrixData item = new GrandPrixData();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID) => 0;

        public uint GetRentalPrice(uint TypeId) => 0;

        public sbyte GetShopPriceType() => 0;

        public override sbyte GetShopPriceType(uint TypeId) => 0;

        public override bool IsBuyable(uint TypeId) => true;


        public override bool IsExist(uint TypeId)
        {
            GrandPrixData item = new GrandPrixData();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public bool LoadItem(uint ID, ref GrandPrixData item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (GrandPrixData)value;
                return false;
            }
            item = (GrandPrixData)value;
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
                foreach (GrandPrixData item in this)
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

        public void ActiveAll(ref GrandPrixData entry)
        {
            //what func??
        }
    }
}
