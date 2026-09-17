using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.DAT
{
    public class DATFile
    {
        public DATFile(int value, string value2)
        {
            ID = value;
            Line = value2;
        }
        /// <summary>
        /// index line
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// texto armazenarado
        /// </summary>
        public string Line { get; set; }
    }
}
