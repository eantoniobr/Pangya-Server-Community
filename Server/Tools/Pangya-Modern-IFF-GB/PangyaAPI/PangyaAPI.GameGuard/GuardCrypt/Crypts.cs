//DataHdr: array[0..89] of byte = (
// 	$4D, $75, $45, $6E, $67, $2E, $69, $6E, $69, $00, // name
//   $35, $3C, $05, $11, $01, $07, $24, $B5, $6A, $19, $B2, $A8, $38, $F6, $BD, $E3, // sig
//   $21, $7A, $03, $20, $5B, $97, $72, $71, $1F, $36, $48, $B5, $E1, $CB, $9C, $01, // na
//   $AA, $21, $DE, $CA, $B4, $6E, $D0, $DD, $53, $0B, $11, $A8, $67, $EC, $CD, $E4, // tu
//   $8D, $BA, $E2, $23, $9C, $74, $E7, $33, $BF, $F6, $9D, $3A, $66, $BC, $1B, $D6, // re

//   $22, $26, $81, $32,  //keyF
//   $0A, $00, $00, $00,  //FileName - 13(example PangyaUS.ini add 0 finish code)
//   $40, $00, $00, $00,  //Signatures len - 64
//   $21, $26, $81, $32   //KeyS
// );

using PangyaAPI.GameGuard.GuardData;
using PangyaAPI.GameGuard.PublicTableKey;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.IO;
using System.Text;
namespace PangyaAPI.GameGuard.GuardCrypt
{
	public class Crypts
	{
		public readonly int HEADERSIZE = 93;//size GameGuardHeader
											//start
		public readonly int GGSIG3 = 847324707;
		public readonly int GGSIG4 = 847324708;
		//final
		public readonly int GGSIG1 = 0x32812622;
		public readonly int GGSIG2 = 0x32812621;

		public readonly bool DEBUG = true;
		public WinCrypt Win32 { get; set; }
		public GameGuardHeaders GGHeader;
		public GGData GGData { get; set; }
		public byte[] Data;
		public byte[] Signature { get; set; }

		public Crypts()
		{
			GGData = new GGData();
			Win32 = new WinCrypt();
			GGHeader = new GameGuardHeaders();
			DEBUG = false;
			Data = new byte[0];
			Signature = new byte[0];
		}

		public enum Result
		{
			Sucess = 0,
			File_Not_Found = 2,
			Error = 3,
			Key_Not_Found,
			Test_New_Key
		}

		public Result DecryptEncryptFile(string filename)
        {
			string outfile = Path.GetFileNameWithoutExtension(filename) + "_Dec.ini";
			if (DecryptINI(ref filename, ref outfile))
            {
				return Result.Sucess;
            }
			return Result.Error;
        }
		//100 work, by LuisMK
		public bool DecryptINI(ref string inputFile, ref string outputFile)
		{
			var data = File.ReadAllBytes(inputFile);
			var Reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(inputFile)));
			if (File.Exists(inputFile) == false)
			{
				Console.Write("error");
				Console.Write("\n");
				Console.Read();
				return false;
			}

			else
			{
				var id = data.ProcuraNoArquivo(Path.GetFileNameWithoutExtension(inputFile) +".ini");
				var file_len =( Path.GetFileNameWithoutExtension(inputFile) + ".ini").Length + 1;
				uint bfSize = Reader.GetPosition();
				Reader.Seek(0, 2);
				uint efSize = Reader.GetPosition();
				uint fSize = efSize - bfSize;
				Reader.Read();
                Reader.Seek(id[0], 0);//encontrou o primeiro nome
				int signature =(int) (id[1] - (Reader.GetPosition() + file_len) - 16); 
				GGHeader.GameGuardFirst = new GameGuardHeaders().ReadFirst(Reader.ReadPStr((uint)file_len), Reader.ReadBytes(signature), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32());
				var name = Reader.ReadPStr((uint)file_len);
				signature = (int)(fSize - Reader.GetPosition() - 16);
				GGHeader.GameGuardTwo = new GameGuardHeaders().ReadTwo(name, Reader.ReadBytes(signature), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32(), Reader.ReadUInt32());
				Reader.Seek(0, 0);
				Reader.ReadBytes(out byte[] Data, Convert.ToInt32(fSize - 16 - GGHeader.GameGuardTwo.Signature_size));
				Reader.Close();
				if (Win32.SetupCrypt())
				{
					if (Win32.VerifySignature(GameGuardTableKeys.RSAKEY, Data, Convert.ToUInt32(fSize - 16 - GGHeader.GameGuardTwo.Signature_size), (GGHeader.GameGuardTwo.Signature), GGHeader.GameGuardTwo.Signature_size))
					{
						if (Win32.DecryptData(GameGuardTableKeys.HASHKEY, ref Data, Convert.ToUInt32(fSize - 16 - GGHeader.GameGuardFirst.Filename_size - GGHeader.GameGuardFirst.Signature_size) - 13))
						{
							GGData.OldBytes = Data;
							GGData.NewBytes = new byte[Data.Length - GGHeader.GameGuardFirst.Signature_size - GGHeader.GameGuardTwo.Signature_size - 16];
							Console.WriteLine("decrypted: {0}", inputFile);
							Buffer.BlockCopy(Data, 0, GGData.NewBytes, 0, GGData.NewBytes.Length);
							return true;
						}
						else
						{
							Console.Write("Failed to decrypt Data: {0:D}");
						}
					}
					else
					{
						Console.Write("Failed to verify signature: {0:x}");
						return false;
					}
				}
				else
				{
					Console.Write("Failed to aquire context: {0:x}");
					return false;
				}
			}
			Win32.Clear(true, IntPtr.Zero);
			return false;
		}
		
		
		
		/// <summary>
		/// not encrypt 75%, work not finish
		/// </summary>
		/// <param name="inputFile"></param>
		/// <param name="outputFile"></param>
		public void EncryptINI(ref string inputFile, ref string outputFile)
		{
			if (File.Exists(inputFile) == false)
			{
				Console.Write("error");
				Console.Write("\n");
				Console.Read();
				return;
			}
			else
			{
				using (var inFile = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(inputFile))))
				{
					inFile.Seek(0, 0);
					uint bfSize = inFile.GetPosition();
					inFile.Seek(0, 2);
					uint efSize = inFile.GetPosition();
					uint fSize = (efSize - bfSize);

					inFile.Seek(0, 0);
					byte[] inData = new byte[fSize];
					inFile.ReadBytes(out inData, (int)fSize);
					if (Win32.SetupCrypt(null))
					{
						var hash = new byte[64];
						inFile.Close();
						if (Win32.EncryptData(GameGuardTableKeys.HASHKEY, ref inData, fSize))
						{
							byte[] temp = inData;
							CheckIni(inputFile, outputFile, ref temp);
						}
						else
						{
							Console.Write("Failed to decrypt Data: {0:D}", 1);
						}
					}
					else
					{
						Console.Write("Failed to create signature: {0:D}", 2);
					}
				}
			}
			Win32.Clear(true, IntPtr.Zero);
		}

		public void Log()
		{
			if (DEBUG)
			{
				Console.Write("Sig1: {0}\n", GGHeader.GameGuardTwo.Filename_size);
				Console.Write("Sig: {0}\n", Signature.HexDump());
				Console.Write($"Data Encrypted: {Data.HexDump()}");
			}
		}

		public bool CheckIni(string filename, string outputFile, ref byte[] temp)
		{
			var Binary = new PangyaBinaryWriter();
			var hash = new byte[64];
			var result = false;
			switch (Path.GetFileNameWithoutExtension(filename))
			{
				case "PangyaUS":
					{
						var Size = temp.Length;
						Binary.WriteBytes(temp, 541);//writer 541 
						Binary.WriteStr("PangyaUS.ini", 13);
						temp = new byte[292];
						Binary.WriteBytes(temp, 292);//hash (49 + 256)
						Binary.WriteInt32(GGSIG3);
						Binary.WriteUInt32(49);//what?? PangyaUS.ini.+hashs(PangyaUS.ini.½œ-8(s!L?ó|R3¬2yÙ1z¥Å®´8eòa×ý.)
						Binary.WriteUInt32(256);//signature size 1??
						Binary.WriteInt32(GGSIG4);
						Binary.WriteStr("PangyaUS.ini", 13);
						byte[] hashBase = new byte[64];
						temp = new byte[64];
						Win32.EncryptData(GameGuardTableKeys.HASHKEY, ref temp, 64);
						Win32.ConcatCharStar(temp, ref hashBase, 64, 0);
						temp = Encoding.UTF8.GetBytes("PangyaUS.ini\x0");
						Win32.ConcatCharStar(temp, ref hashBase, 13, 64);

						Win32.CreateSignature(GameGuardTableKeys.HASHKEY, ref hashBase, 64, ref hash);
						//hash
						Binary.Write(hash, 64);
						Binary.Write(GGSIG1);
						Binary.WriteUInt32(13);//PangyaUS.ini.
						Binary.Write(64);//signature size 2
						Binary.Write(GGSIG2);
						Binary.SaveWrite(outputFile);
						Console.WriteLine("encrypted");
						result = true;
					}
					break;
				default:
					break;
			}
			return result;
		}

		public string DecryptXOR(byte[] szString, int iLen)
		{
			//Every encrypted string starts with "01" byte
			//The key is actually a bit longer then the string (5 bytes)
			//String ends on byte "00" as normal strings also do
			if (szString.Length == 0 || szString[0] != 1 || iLen < 5)
				return null;

			//Changes 2 bytes for more "security" lol
			var dwKey = szString[1];
			dwKey = (byte)(dwKey + dwKey * 2);
			szString[2] ^= (byte)(dwKey + 0x65); //Byte 3

			dwKey = (byte)(dwKey + dwKey * 2 + 3);
			szString[3] ^= (byte)(dwKey + 0x65); //Byte 4

			//Main decryption routine
			int i;
			for (i = 0; i < iLen - 5; i++)
			{
				dwKey++;

				dwKey = (byte)(dwKey + dwKey * 2);
				byte bDL = dwKey;
				bDL += 0x65;
				szString[i] = ((byte)(bDL ^ (szString[i + 4])));
			}

			//Overwrite the end with a string terminator (the key, no actual part of the string)
			//String size + 5
			i = i - 1;
			for (int j = 0; j < 5; j++)
				if (szString.Length > i + j)
					szString[i + j] = 0x00;

			return Encoding.UTF7.GetString(szString);
		}

		public void SaveResult(string file)
        {
			File.WriteAllBytes(file, GGData.NewBytes);

			File.WriteAllBytes(file.Replace(".ini", "_Sig.ini"), Data);
		}
	}
}
