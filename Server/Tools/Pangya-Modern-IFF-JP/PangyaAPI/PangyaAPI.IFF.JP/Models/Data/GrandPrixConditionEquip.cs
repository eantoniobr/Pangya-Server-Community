namespace PangyaAPI.IFF.JP.Models.Data
{
    public class GrandPrixConditionEquip
    {
    
        public GrandPrixConditionEquip Clone()
        {
        var clone = (GrandPrixConditionEquip)MemberwiseClone();
        return clone;
        }
}
}