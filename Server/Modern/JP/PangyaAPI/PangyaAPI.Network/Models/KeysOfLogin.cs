using System.Runtime.InteropServices;

namespace PangyaAPI.Network.Models;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public class KeysOfLogin
{
	public byte valid;

	[field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
	public string[] keys { get; set; } = new string[2];

	public KeysOfLogin()
	{
		keys = new string[2];
	}
}
