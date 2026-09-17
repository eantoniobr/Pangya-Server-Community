namespace PangyaAPI.IFF.JP.Models.Data
{
    public class HoleCupDropItem
    {
    
        public HoleCupDropItem Clone()
        {
        var clone = (HoleCupDropItem)MemberwiseClone();
        return clone;
        }
}
}