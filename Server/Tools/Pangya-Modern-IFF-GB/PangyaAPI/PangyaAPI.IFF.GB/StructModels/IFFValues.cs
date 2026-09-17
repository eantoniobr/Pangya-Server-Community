using PangyaAPI.IFF.Models;
using PangyaAPI.IFF.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.IFF.StructModels
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class IFFValues
    {
        public CharacterType CharacterType;
        public ushort Character_Raw;
        public ushort Group;
        public ushort Type;
        public ushort Pos;
        public ushort Serial;
    }
}
