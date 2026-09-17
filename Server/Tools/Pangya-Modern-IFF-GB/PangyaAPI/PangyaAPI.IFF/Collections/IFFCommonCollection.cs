using PangyaAPI.IFF.Lister;
using PangyaAPI.IFF.StructModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.IFF.Collections
{
    public class IFFCommonCollection : IFFEntryList<IFFCommon>
    {
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

        public override void IffSave(string filePath, bool ActiveNewItens)
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
    }
}
