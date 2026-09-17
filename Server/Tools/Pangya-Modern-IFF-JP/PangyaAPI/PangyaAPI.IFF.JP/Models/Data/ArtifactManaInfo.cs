namespace PangyaAPI.IFF.JP.Models.Data
{
    public class ArtifactManaInfo
    {
    
        public ArtifactManaInfo Clone()
        {
        var clone = (ArtifactManaInfo)MemberwiseClone();
        return clone;
        }
}
}