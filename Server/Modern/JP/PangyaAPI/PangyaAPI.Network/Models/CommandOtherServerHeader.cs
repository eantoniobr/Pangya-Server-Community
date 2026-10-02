using PangyaAPI.Utilities.Models;

namespace PangyaAPI.Network.Models;

public class CommandOtherServerHeader
{
	public uint send_server_uid_or_type { get; set; }

	public short command_id { get; set; }

	public CommandOtherServerHeader(uint ul = 0u)
	{
		send_server_uid_or_type = ul;
		command_id = 0;
	}

	public void Clear()
	{
		send_server_uid_or_type = 0u;
		command_id = 0;
	}

	public byte[] ToArray()
	{
		using PangyaBinaryWriter p = new PangyaBinaryWriter();
		p.Write(send_server_uid_or_type);
		p.Write(command_id);
		return p.GetBytes;
	}
}
