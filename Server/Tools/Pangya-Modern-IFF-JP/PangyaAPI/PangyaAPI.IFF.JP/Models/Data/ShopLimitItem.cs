namespace PangyaAPI.IFF.JP.Models.Data
{
    public class ShopLimitItem
    {
    
        public ShopLimitItem Clone()
        {
        var clone = (ShopLimitItem)MemberwiseClone();
        return clone;
        }
}
}