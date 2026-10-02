using PangyaAPI.Network.Core;
using System.Runtime.InteropServices;
namespace PangyaAPI.Network.Models;
 
public class ChatMacroUser : IMessage
{ 
	public class chat_macro
	{ 
		public string text;
	}
	 
	public chat_macro[] macro;

	public ChatMacroUser()
	{
		macro = new chat_macro[9];
		clear();
	}

	public void setMacro(int index, string macros)
	{
		macro[index].text = macros;
	}

	public void clear()
	{
		for (int i = 0; i < macro.Length; i++)
		{
			macro[i] = new chat_macro();
		}
	}

	public byte[] ToArray()
	{
		using Packet p = new Packet();
		for (int i = 0; i < 9; i++)
		{
			p.WriteString(macro[i].text, 64);
		}
		return p.GetBytes;
	}

    public void ToRead(Packet p)
    {
       
    }
}
