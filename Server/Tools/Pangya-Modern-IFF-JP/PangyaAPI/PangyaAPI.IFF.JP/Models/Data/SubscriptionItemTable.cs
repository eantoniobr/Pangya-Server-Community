namespace PangyaAPI.IFF.JP.Models.Data
{
    public class SubscriptionItemTable
    {
    
        public SubscriptionItemTable Clone()
        {
        var clone = (SubscriptionItemTable)MemberwiseClone();
        return clone;
        }
}
}