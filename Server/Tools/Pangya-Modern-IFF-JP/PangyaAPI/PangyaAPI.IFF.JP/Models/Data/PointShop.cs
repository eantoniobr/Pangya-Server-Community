using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.JP.Models.Data
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 20)]
    public class PointShop 
    {
        [field: MarshalAs(UnmanagedType.Bool, SizeConst = 4)]
        public bool Active { get; set; }
        public uint ID { get; set; }
        public uint Points { get; set; }   // Quantidade de pontos para trocar por itens
        public uint Quantity { get; set; } // Quantidade de itens para trocar pelos pontos
        public uint Flag { get; set; }  
    
        public PointShop Clone()
        {
        var clone = (PointShop)MemberwiseClone();
        return clone;
        }
}
}