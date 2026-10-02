using System.Runtime.InteropServices;

namespace PangyaAPI.Network.Models;

public class AuthServerKey
{
	public int server_uid;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
	public string key;

	public byte valid = 1;

	public bool isValid()
	{
		if (valid == 1)
		{
			return !string.IsNullOrEmpty(key);
		}
		return false;
	}

	public bool checkKey(string _str)
	{
		if (isValid())
		{
			return string.Compare(_str, key) == 0;
		}
		return false;
	}
}
