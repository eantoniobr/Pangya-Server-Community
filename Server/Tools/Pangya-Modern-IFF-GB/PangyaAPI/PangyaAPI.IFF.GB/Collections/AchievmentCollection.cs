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
    public class AchievementCollection : IFFEntryList<Achievement>
    {
        /// <summary>
        /// parses the Achievement.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the Achievement.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new Achievement());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new Achievement())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(8);
                    var name = Reader.ReadPStr(40);
                    Reader.Skip(128);
                    Reader.ReadPStr(out string[]quest_name, 129, 1290);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (Achievement)Reader.Read(new Achievement());
                    item.Name = name;
                    item.QuestName = quest_name[0];
                    item.QuestName1 = quest_name[1];
                    item.QuestName2 = quest_name[2];
                    item.QuestName3 = quest_name[3];
                    item.QuestName4 = quest_name[4];
                    item.QuestName5 = quest_name[5];
                    item.QuestName6 = quest_name[6];
                    item.QuestName7 = quest_name[7];
                    item.QuestName8 = quest_name[8];
                    item.QuestName9 = quest_name[9];
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

        public Achievement GetItem(uint TypeID)
        {
            Achievement Achievement = new Achievement();
            if (!LoadItem(TypeID, ref Achievement))
            {
                return Achievement;
            }
            return Achievement;
        }

        public override string GetItemName(uint TypeID)
        {
            Achievement item = new Achievement();
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
            Achievement item = new Achievement();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }

        public bool LoadItem(uint ID, ref Achievement item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (Achievement)value;
                return false;
            }
            item = (Achievement)value;
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
                foreach (Achievement item in this)
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

        public void ActiveAll(ref Achievement entry)
        {
            //what func??
        }
    }
}
