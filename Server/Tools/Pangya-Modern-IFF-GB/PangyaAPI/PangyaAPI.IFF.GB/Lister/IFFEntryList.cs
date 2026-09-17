using PangyaAPI.IFF.StructModels;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.Collections.Generic;
namespace PangyaAPI.IFF.Lister
{
    public abstract partial class IFFEntryList<T> : List<T>
    {
        public IFFHeader Header { get; set; }
        public bool Update { get; set; } = false;
        public abstract string GetItemName(uint TypeID);
        public abstract uint GetPrice(uint TypeID);
        public abstract sbyte GetShopPriceType(uint TypeId);
        public abstract bool IsBuyable(uint TypeId);
        public abstract bool IsExist(uint TypeId);
        public abstract void IffSave(string filePath,bool ActiveNewItens);

        public bool CheckVersionIFF()
        {
            return Header.Version == 13;
        }
    }
}