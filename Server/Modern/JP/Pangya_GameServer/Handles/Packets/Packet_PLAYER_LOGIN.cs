using PangyaAPI.Network.Handle;

namespace Pangya_GameServer.Handles.Packets;


public class Packet_PLAYER_LOGIN : PacketResult
{
    public string Login { get; private set; }
    public uint UID { get; private set; }
    public uint NtreevUID { get; private set; }
    public ushort Command { get; private set; }
    public string LKey { get; private set; }
    public string ClientVersion { get; private set; }
    public bool HasClientVersion { get; private set; }
    public uint PacketVersion { get; private set; }
    public string MacAddress { get; private set; }
    public bool HasMAC => !string.IsNullOrEmpty(MacAddress); // Propriedade calculada (fica mais limpo)
    public string GKey { get; private set; }
    public bool HasGKey => !string.IsNullOrEmpty(GKey); // Propriedade calculada
    public bool HasLKey => !string.IsNullOrEmpty(LKey); // Propriedade calculada

    /// <summary>
    /// Faz o parse dos bytes Do pacote De login Para as propriedades Da classe.
    /// </summary>
    public bool IsValid { get; private set; } = false;

    public override void Load()
    {
        try
        {
            this.Login = ReadString();
            this.UID = ReadUInt32();
            this.NtreevUID = ReadUInt32();
            this.Command = ReadUInt16();
            this.LKey = ReadString();
            this.HasClientVersion = ReadPStr(out string version);
            this.ClientVersion = this.HasClientVersion ? version : string.Empty;
            this.PacketVersion = VersionDecrypt(ReadUInt32(out uint packetVer) ? packetVer : 0);
            this.MacAddress = ReadString();
            this.GKey = ReadString();

            IsValid = (Size == 0);
        }
        catch
        {
            IsValid = false;
        }
    }

    public uint VersionDecrypt(uint packet_version)
    {
        string PacketVerKey = "{782AE110-2EEF-4c61-B030-A53F17634F7D}";
        byte[] tmpPVer = BitConverter.GetBytes(packet_version);
        int index = 0;

        for (int i = 0; i < PacketVerKey.Length; i++)
        {
            tmpPVer[index] ^= (byte)PacketVerKey[i];
            index = (index == 3) ? 0 : index + 1;
        }
        return BitConverter.ToUInt32(tmpPVer, 0);
    }
}
