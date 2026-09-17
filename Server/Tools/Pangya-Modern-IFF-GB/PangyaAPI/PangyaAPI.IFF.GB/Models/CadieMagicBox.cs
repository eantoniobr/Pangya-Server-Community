using PangyaAPI.IFF.StructModels;
using PangyaAPI.IFF.Definitions;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PangyaAPI.IFF.Models
{
    #region Struct CadieMagicBox.iff
    [Serializable]
    public class CadieMagicBoxA : CadieMagicBox, ICloneable
    {
        public object Clone()
        {
            MemoryStream memoryStream = new MemoryStream();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            return binaryFormatter.Deserialize(memoryStream);
        }
    }
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public class CadieMagicBox 
    {
        public uint MagicID { get; set; }//index
        public uint Enabled { get; set; }//valido
        public CadieBoxSetor Page { get; set; }//showOnPage
        public CadieBoxEnum BoxType { get; set; }//
        public uint Level { get; set; }//okay
        public uint ProdItem { get; set; }
        public uint TypeID { get; set; }
        public uint Quatity { get; set; }
        //

        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] TradeID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] TradeQuantity { get; set; }
        public uint Box_Random_ID { get; set; }
        [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string Name { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime DateStart { get; set; }
        [field: MarshalAs(UnmanagedType.Struct, SizeConst = 16)]
        public IFFTime DateEnd { get; set; }
    }
    #endregion
}
