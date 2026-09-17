using PangyaAPI.PAK.Definitions;
using PangyaAPI.PAK.ListPak;
using PangyaAPI.PAK.Models;
using PangyaAPI.PAK.PublicTableKey;
using PangyaAPI.Utilities.BinaryModels;
using PangyaAPI.Utilities.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace PangyaAPI.PAK.Maker
{
    /// <summary>
    /// criado em 21/12/21
    /// atualizado em 13/03/22
    /// se chegou ate aqui, e possivel que eu nao tenho mais o codigo, pois o codigo é unico :D
    /// </summary>
    public partial class PakMaker
    {
        public PakList PakFiles = new PakList();
        public PakHeader PakHeader = new PakHeader();
        public string FilePath;
        public uint[] Pak_Key { get; set; }
        public byte[] TempPak { get; set; }
        public PangyaPakEnum PakType { get; set; }
        public PakMaker()
        {
            PakType = PangyaPakEnum.PakNoSelected;
        }

        public PakMaker(string path)
        {
            FilePath = path;
            var data = File.ReadAllBytes(FilePath);

            if (data[data.Length - 1] != 0x12)
            {
                Console.WriteLine(
                    "\nInvalid Pak, possible reasons: " +
                    "\n- Pak with custom key" +
                    "\n- Pak with custom Lz77" +
                    "\n- Pak spelled wrong" +
                    "\n- Pak with invalid signature"
                    );

                File.WriteAllText("Log.txt", "code: 12" +
                    "\nenvie esse log ao desenvolvedor" +
                    "\nemail: luizinrc@hotmail.com" +
                    "\nfb.com/luizin.fb");

                throw new Exception("Falha ao tentar decriptografar o pak");
            }
        }


        public void Log()
        {
            Console.WriteLine("Pak Name = {0}" +
                "\nCountFile = {1} ", Path.GetFileNameWithoutExtension(FilePath) + ".pak", PakFiles.Count);
            foreach (var pak in PakFiles)
            {
                Console.WriteLine("\n");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("FileSize: " + pak.FileSize);               
                //Verifica se é um diretório
                if (Directory.Exists(Path.GetFileNameWithoutExtension(FilePath) +"//" +pak.FileName))
                {
                    Console.WriteLine("PathName: " + pak.FileName);
                }

                //Verifica se é um arquivo
                if (File.Exists(Path.GetFileNameWithoutExtension(FilePath) + "//" + pak.FileName))
                {
                    Console.WriteLine("FileName: " + pak.FileName);
                }
                Console.WriteLine("FileRealSize: " + pak.RealFileSize);
                Console.WriteLine("ValueCompress: " + pak.Compression);
                Console.WriteLine("------------------------------------------------");
            }
        }

        public void Test()
        {
            using (PangyaBinaryReader reader = new PangyaBinaryReader(new MemoryStream(TempPak)))
            {
                byte[] data = null;

                PakFiles.ForEach(fileEntry =>
                {
                    reader.BaseStream.Seek(fileEntry.Offset, SeekOrigin.Begin);
                    data = reader.ReadBytes((int)fileEntry.FileSize + 1);

                    switch (fileEntry.Compression)
                    {
                        //pak not compress ^^
                        case 0:
                            {

                            }
                            break;

                        //// LZ77 & LZ77 Custom
                        case 1:
                        case 3:
                            data = LZ77.Decompress(data, fileEntry.FileSize, fileEntry.RealFileSize + 128,
                                fileEntry.Compression);
                            break;
                        //create directory for decrypt pak
                        case 2:
                            Directory.CreateDirectory(Path.GetFileNameWithoutExtension(FilePath) + "//" + fileEntry.FileName);
                            break;
                        default:
                            Debug.WriteLine($"Unknown compression value '{fileEntry.Compression.ToString()}'");
                            break;
                    }
                    if (fileEntry.FileSize != 0)
                    {
                        if (Directory.Exists(Path.GetFileNameWithoutExtension(FilePath)) == false)
                        {
                            Directory.CreateDirectory(Path.GetFileNameWithoutExtension(FilePath));
                        }
                        File.WriteAllBytes(Path.GetFileNameWithoutExtension(FilePath) + "//" + fileEntry.FileName, data);
                    }
                });
            }
        }


        public void SaveFile()
        {
            using (PangyaBinaryReader reader = new PangyaBinaryReader(new MemoryStream(File.ReadAllBytes(FilePath))))
            {
                byte[] data = null;

                PakFiles.ForEach(fileEntry =>
                {
                    reader.BaseStream.Seek(fileEntry.Offset, SeekOrigin.Begin);
                    data = reader.ReadBytes((int)fileEntry.FileSize + 1);

                    switch (fileEntry.Compression)
                    {
                        //pak not compress ^^
                        case 0:
                            { 
                            
                            }
                            break;
                            
                        //// LZ77 & LZ77 Custom
                        case 1:
                        case 3:
                            data = LZ77.Decompress(data, fileEntry.FileSize, fileEntry.RealFileSize + 128,
                                fileEntry.Compression);
                            break;
                        //create directory for decrypt pak
                        case 2:
                            Directory.CreateDirectory(Path.GetFileNameWithoutExtension(FilePath) + "//" + fileEntry.FileName);
                            break;
                        default:
                            Debug.WriteLine($"Unknown compression value '{fileEntry.Compression.ToString()}'");
                            break;
                    }
                    if (fileEntry.FileSize != 0)
                    {
                        if(Directory.Exists(Path.GetFileNameWithoutExtension(FilePath)) == false)
                        {
                            Directory.CreateDirectory(Path.GetFileNameWithoutExtension(FilePath));
                        }
                        File.WriteAllBytes(Path.GetFileNameWithoutExtension(FilePath) + "//" + fileEntry.FileName, data);
                    }
                });
            }
        }


        public void FindPakLang(uint Data0, uint Data1)
        {
            uint[] XTeaInfo = new uint[] { Data0, Data1 };
            XTEA.Decipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[0]);
            if (XTeaInfo[0] == 0)
                this.PakType = PangyaPakEnum.GB; // US KEY

            XTeaInfo = new uint[] { Data0, Data1 };
            XTEA.Decipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[1]);
            if (XTeaInfo[0] == 0)
            { PakType = PangyaPakEnum.JP; }// JAPAN KEY

            XTeaInfo = new uint[] { Data0, Data1 };
            XTEA.Decipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[2]);
            if (XTeaInfo[0] == 0)
                PakType = PangyaPakEnum.TH; // THAI KEY

            XTeaInfo = new uint[] { Data0, Data1 };
            XTEA.Decipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[3]);
            if (XTeaInfo[0] == 0)
                PakType = PangyaPakEnum.EU; // Europe KEY


            XTeaInfo = new uint[] { Data0, Data1 };
            XTEA.Decipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[4]);
            if (XTeaInfo[0] == 0)
                PakType = PangyaPakEnum.ID; // INDONESIA KEY


            XTeaInfo = new uint[] { Data0, Data1 };
            XTEA.Decipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[5]);
            if (XTeaInfo[0] == 0)
                PakType = PangyaPakEnum.KR; // KOREAN KEY

            XTeaInfo = new uint[] { Data0, Data1 };

            if (PakType == PangyaPakEnum.PakNoSelected)
                //i don't know the key :(
                PakType = PangyaPakEnum.PakUnknown;
        }


        /// <summary>
        /// Searches for the first file matching to searchPattern in the sepcified path.
        /// </summary>
        /// <param name="path">The path from where to start the search.</param>
        /// <param name="searchPattern">The pattern for which files to search for.</param>
        /// <returns>Either the complete path including filename of the first file found
        /// or string.Empty if no matching file could be found.</returns>
        public IntPtr FindFirstFile(string path, out WIN32_FIND_DATA files)
        {
            return Win32.FindFirstFile(path, out files);
        }

        public bool FindNextFile(IntPtr findnext, out WIN32_FIND_DATA files)
        {
            return Win32.FindNextFile(findnext, out files);
        }

        public bool FindClose(IntPtr findclose)
        {
            return Win32.FindClose(findclose);
        }

        public bool StringCompare(string scompare)
        {
            switch (scompare)
            {
                case ".":
                    return true;
                case "..":
                    return true;
                case "":
                    return true;
                default:
                    return false;

            }
        }

    public    byte[] ConvertUIntoBytes(uint[] value)
        {

            byte[] result;

            result = new byte[Buffer.ByteLength(value)];
            Buffer.BlockCopy(value, 0, result, 0, result.Length);

            return result;
        }

        public uint[] ConvertArray(string value)
        {
            uint[] resultingArray = new uint[8];

            var Bytes = Encoding.UTF8.GetBytes(value);
            Buffer.BlockCopy(Bytes, 0, resultingArray, 0, Bytes.Length);
            return resultingArray;
        }
    }
 
   
}
