using PangyaAPI.PAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.PAK.ListPak
{
    public class PakList : List<PakFileEx>
    {
        public double Size { get; set; }

        public double Packed_Size { get; set; }
        public PakList()
        {
        }

        public PakList(int capacity): base(capacity) { }

        public void Calc()
        {
            for (int i = 0; i < Count; i++)
            {

                Size += Convert.ToSingle(this[i].RealFileSize);
                Packed_Size += Convert.ToSingle(this[i].FileSize);
            }
        }

        public List<PakFileEx> GetPakList(bool isfolder)
        {
            if (isfolder)
            {
                return this.Where(c => c.IsFolder == isfolder).ToList();
            }

            return this.Where(c => c.IsFile == isfolder).ToList();
        }
    }
}
