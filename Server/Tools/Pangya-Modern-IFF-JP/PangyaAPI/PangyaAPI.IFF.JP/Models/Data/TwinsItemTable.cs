namespace PangyaAPI.IFF.JP.Models.Data
{
    public class TwinsItemTable
    {
    
        public TwinsItemTable Clone()
        {
        var clone = (TwinsItemTable)MemberwiseClone();
        return clone;
        }
}
}