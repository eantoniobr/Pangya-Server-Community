using PangyaAPI.Utilities;
using System.Text;

namespace PangyaAPI.Network.Models
{
    public class ServerInfo
    {
        private byte[] name_bytes; 
        public string nome {get=> name_bytes.GetString();  set => name_bytes.SetString(value); }  
        public int uid { get; set; } 
        public int max_user { get; set; } 
        public int curr_user { get; set; } 
        public string ip { get; set; } = ""; 
        public int port { get; set; } 
        public int angelic_wings_num { get; set; } 
        public short event_map { get; set; } 
        public short app_rate { get; set; } 
        public short scratch_rate { get; set; } 
        public short img_no { get; set; }  
        public sbyte tipo { get; set; }
        public string version { get; set; }
        public string version_client { get; set; }
        public uint packet_version { get; set; } 
        public Property propriedade { get; set; } 
        public EventFlag event_flag { get; set; }
        public RateConfigInfo rate { get; set; }
        public Flag flag { get; set; }

        public ServerInfo()
        {
            propriedade = new Property(); 
            event_flag = new EventFlag(0);
            rate = new RateConfigInfo();
            flag = new Flag();
            name_bytes = new byte[40];
        }

        public byte[] ToArray()
        {
            using Packet p = new Packet();
            p.WriteString(nome, 28);
            p.WriteInt32(983);
            p.WriteZero(8);
            p.WriteInt32(uid);
            p.WriteInt32(max_user);
            p.WriteInt32(curr_user);
            p.WriteString(ip, 18);
            p.WriteInt32(port);
            p.WriteUInt32(propriedade.ulProperty);
            p.WriteInt32(angelic_wings_num);
            p.WriteUInt16(event_flag.usEventFlag);
            p.WriteInt16(event_map);
            p.WriteInt16(app_rate);
            p.WriteInt16(scratch_rate);
            p.WriteInt16(img_no);
            return p.GetBytes;
        }

        public ServerInfo ToRead(Packet p)
        {
            nome = p.ReadString(40);
            uid = p.ReadInt32();
            max_user = p.ReadInt32();
            curr_user = p.ReadInt32();
            ip = p.ReadString(18);
            port = p.ReadInt32();
            propriedade.ulProperty = p.ReadUInt32();
            angelic_wings_num = p.ReadInt32();
            event_flag.usEventFlag = p.ReadUInt16();
            event_map = p.ReadInt16();
            app_rate = p.ReadInt16();
            scratch_rate = p.ReadInt16();
            img_no = p.ReadInt16();
            return this;
        }
    }

}
