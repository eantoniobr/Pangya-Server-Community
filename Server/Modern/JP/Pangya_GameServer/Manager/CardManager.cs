using System;
using System.Collections.Generic;
using System.Linq;
using Pangya_GameServer.Models;
using PangyaAPI.Network;
using PangyaAPI.Utilities.Models;

namespace Pangya_GameServer.Manager
{
    public class CardManager : Dictionary<int, CardInfo>
    {
        public byte[] Build()
        {
            var p = new Packet();
            try
            {
                p.WriteUInt16((ushort)Count);
                p.WriteUInt16((ushort)Count);
                foreach (var item in Values)
                {
                    p.WriteBytes(item.ToArray());
                }
                return p.GetBytes;
            }
            catch (Exception)
            {
                return new byte[0];
            }
        }
         
        public CardInfo findCardById(int _id)
        {
            return this.Values.FirstOrDefault(c => c.id == _id);
        }

        public CardInfo findCardByTypeid(uint _typeid)
        {
            return this.Values.FirstOrDefault(c => c._typeid == _typeid);
        }

        public CardInfo findCardByTypeidAndId(uint _typeid, int _id)
        {
            return this.Values.FirstOrDefault(c => c.id == _id && c._typeid == _typeid);
        }
    }
}
