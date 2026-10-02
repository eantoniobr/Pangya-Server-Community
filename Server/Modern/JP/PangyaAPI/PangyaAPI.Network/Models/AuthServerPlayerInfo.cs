namespace PangyaAPI.Network.Models;

public class AuthServerPlayerInfo
{
	public uint uid;

	public string id;

	public string ip;

	public int option;

	public AuthServerPlayerInfo(uint _uid = 0u)
	{
		uid = _uid;
		id = string.Empty;
		ip = string.Empty;
		option = -1;
	}

	public AuthServerPlayerInfo(uint _uid, string _id, string _ip)
	{
		uid = _uid;
		id = _id;
		ip = _ip;
		option = 1;
	}

	public void Clear()
	{
		uid = 0u;
		option = -1;
		if (!string.IsNullOrEmpty(id))
		{
			id = string.Empty;
		}
		if (!string.IsNullOrEmpty(ip))
		{
			ip = string.Empty;
		}
	}
}
