using System;
using System.IO;
using System.Text;
using PangyaAPI.IFF.PublicTableKey;
using PangyaAPI.Utilities.BinaryModels;
using PangyaAPI.Utilities.Cryptography;
namespace PangyaAPI.IFF.Maker
{
    public class IFFCryptor
    {
		#region Fields
		public enum Result
		{
			Sucess = 0,
			File_Not_Found = 2,
			Error = 3,
			Key_Not_Found,
			Test_New_Key
		}
		public enum KeyEnum
		{
			US,
			JP,
			TH,
			EU,
			ID,
			KR
		}

		public enum OperacaoEnum
		{
			Decrypt,
			Encrypt
		}

		public OperacaoEnum ResultOperation;
		public string FilePath = "";
		public uint[] IFF_Key = new uint[0];
		public int Real_Size;
		public byte[] DataFinal;
		#endregion

		//make iff
		#region IFF Encrypt and Decrypt
		/// <summary>
		/// Encrypt/Decrypt pangya.iff
		/// </summary>
		/// <param name="filename">file name</param>
		/// <returns></returns>
		public Result DecryptEncryptFile(string filename)
		{
			FilePath = filename;

			// If data is decrypted -> check what crypt i need
			var result = CheckCryptDecrypt();

			GenKey();
			IFF_Key = TableKey.Key_JP;
			if (IFF_Key[0] == 0)
			{ Console.WriteLine("Key not Found: {0}", Path.GetFileName(filename)); return Result.Key_Not_Found; }

			PangyaBinaryReader Reader = new PangyaBinaryReader(File.OpenRead(filename));
			int size = (int)Reader.GetSize();

			if (size < 0)
			{
				Console.Write("File not found : {0} \n", filename);
				Reader.Close();
				return Result.File_Not_Found;
			}
			Real_Size = size;
			DataFinal = new byte[size + 3];
			byte[] Data = new byte[Reader.GetSize()];
			Reader.Read(Data, 0, size);
			Reader.Close();

			for (int i = 0; i < size; i = i + 8)
			{
				uint[] DataCut = new uint[8];
				if ((size - i) >= 8)
				{
					Buffer.BlockCopy(Data, i, DataCut, 0, 8);
				}
                else
                {
					var temp_data = new byte[size + 3];
					Buffer.BlockCopy(Data, 0, temp_data, 0, size);
					Buffer.BlockCopy(temp_data, i, DataCut, 0, 8);
				}
				if (result)
				{
				 XTEA.Encipher(16,ref DataCut, IFF_Key);
				}
				else
				{
				XTEA.Decipher(16,ref DataCut, IFF_Key);
				}
				Buffer.BlockCopy(DataCut, 0, DataFinal, i, 8);
				//If Decrypt fail ...
				if (i == 0 && DataFinal[0] != 'P' && DataFinal[1] != 'K' && result == false)
				{
					Console.Write("Not {0}.iff... \n", Path.GetFileNameWithoutExtension(filename));
					return Result.Error;
				}
			}
			return Result.Sucess;
		}

		
		void GenKey()
		{
			var typeiff = Path.GetFileNameWithoutExtension(FilePath);
			switch (typeiff)
			{
				case "pangya_jp":
					IFF_Key = TableKey.Key_JP;
					break;
				case "pangya_th":
				IFF_Key=	 TableKey.Key_TH;break; 
				case "pangya_indonesia":
					IFF_Key = TableKey.Key_ID; break;
				default:
					IFF_Key = new uint[0];
					break;
			}
			
		}

		bool CheckCryptDecrypt()
		{
			if (!File.Exists(FilePath))
				throw new FileNotFoundException("Arquivo não encontrado");

			//Ler arquivo e convert em char[]
			var dataResult = Encoding.UTF8.GetChars(File.ReadAllBytes(FilePath));

			// If data is decrypted -> check what crypt i need
			if (dataResult[0] == 'P' && dataResult[1] == 'K')
			{
				Console.WriteLine("Trying to Encrypt ... \n");
				return true;
			}
			else
			{
				Console.WriteLine("Trying to  Decrypt...");
				return false;
			}
		}

		public void SaveResult()
		{
			var data = new byte[Real_Size];

			Buffer.BlockCopy(DataFinal, 0, data, 0, Real_Size);
			File.WriteAllBytes(Path.GetFileNameWithoutExtension(FilePath) + $"_{ResultOperation}.iff", DataFinal);
		}

		public void SaveResult(string filelocalpath)
		{
			File.WriteAllBytes(filelocalpath, DataFinal);
		}
		#endregion
	}
}
