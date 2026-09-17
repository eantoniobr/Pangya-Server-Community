namespace PangyaAPI.IFF.JP.Models.Data
{
    public class CharacterMastery
    {
    
        public CharacterMastery Clone()
        {
        var clone = (CharacterMastery)MemberwiseClone();
        return clone;
        }
}
}