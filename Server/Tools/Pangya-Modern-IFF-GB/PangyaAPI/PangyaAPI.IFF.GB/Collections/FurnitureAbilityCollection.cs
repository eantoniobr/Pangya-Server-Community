using PangyaAPI.IFF.Lister;
using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PangyaAPI.IFF.Collections
{
    public class FurnitureAbilityCollection : IFFEntryList<FurnitureAbility>
    {

        /// <summary>
        /// parses the FurnitureAbility.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the FurnitureAbility.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new FurnitureAbility());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new FurnitureAbility())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {

                    var item = (FurnitureAbility)Reader.Read(new FurnitureAbility());

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

        public override string GetItemName(uint TypeID)
        {
            throw new NotImplementedException();
        }

        public override uint GetPrice(uint TypeID)
        {
            throw new NotImplementedException();
        }

        public override sbyte GetShopPriceType(uint TypeId)
        {
            throw new NotImplementedException();
        }

        public override bool IsBuyable(uint TypeId)
        {
            throw new NotImplementedException();
        }

        public override bool IsExist(uint TypeId)
        {
            throw new NotImplementedException();
        }

        public override void IffSave(string filePath, bool ActiveNewItens)
        {
            throw new NotImplementedException();
        }

        //Destructor
        ~FurnitureAbilityCollection()
        {
            this.Clear();
        }

    }
}
