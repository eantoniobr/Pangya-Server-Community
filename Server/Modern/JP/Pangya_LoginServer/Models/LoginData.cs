using PangyaAPI.Network;
namespace Pangya_LoginServer.Models
{
    public class LoginData
    {
        public string id;
        public string password; 
        public byte opt_count;
        public uint[] v_opt_unkn = new uint[4];
        public string mac_address;

        public LoginData(Packet reader)
        {
            id = reader.ReadString();         // ushort + string
            password = reader.ReadString();   // ushort + string

            opt_count = reader.ReadByte();

            for (int i = 0; i < (opt_count * 8) / 4; i++)
                v_opt_unkn[i] = reader.ReadUInt32();

            mac_address = reader.ReadPStr(); // ushort + string
        }
        public override string ToString()
        {
            string data = $": [USER = {id}], [PWD = {password}], [MAC = {mac_address}]";
            return data;
        }
    }
}
