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
    public class BallCollection : IFFEntryList<Ball>
    {
        /// <summary>
        /// parses the Ball.iff file, if all goes well it should read all data present
        /// </summary>
        /// <param name="data">contains all Information about the Ball.iff file, size, item count, version, link id</param>
        /// <exception cref="Exception">if I get exception, I must have done something wrong, correct me please?</exception>
        public void Load(byte[] data)
        {
            PangyaBinaryReader Reader = null;

            try
            {
                Reader = new PangyaBinaryReader(new MemoryStream(data));

                this.Header = (IFFHeader)Reader.Read(new IFFHeader());
                long recordLength = (Reader.GetSize() - 8L) / Header.Count;
                var size = Marshal.SizeOf(new Ball());
                if (!CheckVersionIFF())
                {
                    System.Windows.Forms.MessageBox.Show($"Versao Atual: 13 \n Versao Arquivo: {Header.Version} \nVersao do IFF esta incorreta\n por favor coloque a versão atual ", " Arquivo corrompido !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                if (recordLength != size)
                {
                    throw new Exception(
                      $"The record length ({recordLength}) mismatches the length of the passed structure ({Marshal.SizeOf(new Ball())})");
                }

                for (int i = 0; i < Header.Count; i++)
                {
                    Reader.BaseStream.Seek(8L + (recordLength * i), SeekOrigin.Begin);
                    Reader.Skip(8);
                    var name = Reader.ReadPStr(40);
                    Reader.BaseStream.Seek(8L + (recordLength * i), 0);
                    var item = (Ball)Reader.Read(new Ball());
                    item.Name = name;
                    this.Add(item);
                }
            }
            finally
            {
                Reader.Dispose();
            }
        }

        public Ball GetItem(uint TypeID)
        {
            Ball Ball = new Ball();
            if (!LoadItem(TypeID, ref Ball))
            {
                return Ball;
            }
            return Ball;
        }

        public override string GetItemName(uint TypeID)
        {
            Ball item = new Ball();
            if (!LoadItem(TypeID, ref item))
            {
                return "";
            }
            return item.Name;
        }

        public override uint GetPrice(uint TypeID)
        {
            Ball item = new Ball();
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
            Ball item = new Ball();
            if (!LoadItem(TypeId, ref item))
            {
                return -1;
            }
            return (sbyte)item.PriceType;
        }

        public override bool IsBuyable(uint TypeId)
        {
            Ball item = new Ball();
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
            Ball item = new Ball();

            if (!LoadItem(TypeId, ref item))
            {
                return false;
            }

            return Convert.ToBoolean(item.Enabled);
        }
        public UInt32 GetRealQuantity(UInt32 TypeId, UInt32 Qty)
        {
            Ball Ball = new Ball();
            if (!LoadItem(TypeId, ref Ball))
            {
                return 0;
            }
            if ((Ball.Enabled == 1) && (Ball.Power > 0))
            {
                return Ball.Power;
            }
            return Qty;
        }

        public bool LoadItem(uint ID, ref Ball item)
        {
            if (!this.TryGetValue(ID, out object value))
            {
                item = (Ball)value;
                return false;
            }
            item = (Ball)value;
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
                foreach (Ball item in this)
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

        public void ActiveAll(ref Ball entry)
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
