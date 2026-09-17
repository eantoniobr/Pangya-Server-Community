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
    public class SetEffectTableCollection : IFFEntryList<SetEffectTable>
    {
        /// <summary>
        /// parses the SetEffectTable.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the SetEffectTable.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new SetEffectTable());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new SetEffectTable())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    var item = (SetEffectTable)Reader.Read(new SetEffectTable());
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

        public SetEffectTable GetItem(uint TypeID)
        {
            SetEffectTable SetEffectTable = new SetEffectTable();
            if (!LoadItem(TypeID, ref SetEffectTable))
            {
                return SetEffectTable;
            }
            return SetEffectTable;
        }

        public override string GetItemName(uint TypeID)
        {
            return "";
        }

        public override uint GetPrice(uint TypeID) => 0;

        public uint GetRentalPrice(uint TypeId) => 0;

        public sbyte GetShopPriceType() => 0;

        public override sbyte GetShopPriceType(uint TypeId) => 0;

        public override bool IsBuyable(uint TypeId) => true;


        public override bool IsExist(uint TypeId)
        {
           return true;
        }

        public bool LoadItem(uint ID, ref SetEffectTable item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (SetEffectTable)value;
                return false;
            }
            item = (SetEffectTable)value;
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
                foreach (SetEffectTable item in this)
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

        public void ActiveAll(ref SetEffectTable entry)
        {
            //what func??
        }
    }
}
