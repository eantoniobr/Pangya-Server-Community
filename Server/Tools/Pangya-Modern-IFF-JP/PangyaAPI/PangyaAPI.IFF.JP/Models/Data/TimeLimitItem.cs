namespace PangyaAPI.IFF.JP.Models.Data
{
    public class TimeLimitItem
    {
    
        public TimeLimitItem Clone()
        {
        var clone = (TimeLimitItem)MemberwiseClone();
        return clone;
        }
}
}