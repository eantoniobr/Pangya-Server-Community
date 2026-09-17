using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.PAK.Models
{
    /// <summary>
    /// contem as informacoes de assinatura, tamanho e etc...
    /// </summary>
    public class PakHeader
    {
        public byte Unknown { get; set; }
        public ushort Unknown1 { get; set; }
        public uint Unknown2 { get; set; }
        public uint ListOffSet { get; set; }
        public uint Count { get; set; }
        public byte Signature { get; set; }
    }
}
