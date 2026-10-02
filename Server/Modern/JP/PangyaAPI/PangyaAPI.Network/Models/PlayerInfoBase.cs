using System;

namespace PangyaAPI.Network.Models
{
    public class PlayerInfoBase
    {
        public uint uid { get; set; }
        public uint m_cap { get; set; }
        public DateTime login_time { get; set; }
        public string token { get; set; }
        public BlockFlag block_flag { get; set; }
        public uint guild_uid { get; set; }
        public string guild_name { get; set; }
        public uint server_uid { get; set; }
        public ushort level { get; set; }
        public byte sex { get; set; }
        public string id { get; set; }
        public string nickname { get; set; }
        public byte m_state_logged { get; set; }
        public string MacAddress { get; set; }
        public PlayerInfoBase()
        {
            this.id = string.Empty;
            this.nickname = string.Empty;
            this.guild_name = string.Empty;
            this.token = string.Empty;
            this.block_flag = new BlockFlag();
            this.login_time = DateTime.Now;
            MacAddress = string.Empty;
        }

        public virtual void Clear()
        {
            uid = 0;
            m_cap = 0;
            token = "302540"; // FIXO
            login_time = DateTime.Now;
            block_flag = new BlockFlag();
            MacAddress = string.Empty;
            guild_uid = 0;
            guild_name = string.Empty;
            server_uid = 0;
            level = 0;
            sex = 0;
            id = string.Empty;
            nickname = string.Empty;
            m_state_logged = 0;
        }

        public void Set(PlayerInfoBase info)
        {
            if (info == null)
                throw new ArgumentNullException(nameof(info), "O parâmetro 'info' não pode ser nulo.");

            this.uid = info.uid;
            this.m_cap = info.m_cap;
            this.login_time = info.login_time;
            this.token = info.token ?? "302540";
            this.block_flag = info.block_flag ?? new BlockFlag();
            this.guild_uid = info.guild_uid;
            this.guild_name = info.guild_name ?? string.Empty;
            this.server_uid = info.server_uid;
            this.level = info.level;
            this.sex = info.sex;
            this.id = info.id ?? string.Empty;
            this.nickname = info.nickname ?? string.Empty;
            this.m_state_logged = info.m_state_logged;
        }
    }
}