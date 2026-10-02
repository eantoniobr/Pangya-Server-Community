using System.Runtime.InteropServices;

namespace PangyaAPI.Network.Models;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public class AuthKeyInfo
{
	public byte valid;

	[field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
	public string key { get; set; }
}
