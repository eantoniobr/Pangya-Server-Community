namespace PangyaAPI.IFF.JP.Models.Data
{
    public class SpecialPrizeItem
    {
    
        public SpecialPrizeItem Clone()
        {
        var clone = (SpecialPrizeItem)MemberwiseClone();
        return clone;
        }
}
}