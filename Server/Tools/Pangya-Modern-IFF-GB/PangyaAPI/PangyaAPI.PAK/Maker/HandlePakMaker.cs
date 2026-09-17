using PangyaAPI.PAK.Definitions;
using PangyaAPI.PAK.Models;
using PangyaAPI.PAK.PublicTableKey;
using PangyaAPI.Utilities.BinaryModels;
using static PangyaAPI.Utilities.Cryptography.XOR;
using PangyaAPI.Utilities.Cryptography;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
namespace PangyaAPI.PAK.Maker
{
    public class HandlePakMaker : PakMaker
    {
        public PakResultEnum OpenPak(string path)
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
                return PakResultEnum.Signature_Invalid;
            }
            using (PangyaBinaryReader reader = new PangyaBinaryReader(new MemoryStream(data)))
            {

                TempPak = reader.GetRemainingData();
                reader.Seek(-16L, 2);

                PakHeader = (PakHeader)reader.ReadObject(PakHeader);

                Console.WriteLine("OffSet -> {0}", PakHeader.ListOffSet);
                Console.WriteLine("Count -> {0}", PakHeader.Count);
                Console.WriteLine("Sign -> {0}", PakHeader.Signature);

                reader.BaseStream.Seek(PakHeader.ListOffSet, SeekOrigin.Begin);
                if (PakHeader.Count > 0)
                {
                    for (uint i = 0; i < PakHeader.Count; i++)
                    {
                        PakFileEx fileEntry = new PakFileEx
                        {
                            FileNameLength = reader.ReadByte(),
                            Compression = reader.ReadByte(),
                            Offset = reader.ReadUInt32(),
                            FileSize = reader.ReadUInt32(),
                            RealFileSize = reader.ReadUInt32()
                        };

                        byte[] tempName = reader.ReadBytes(fileEntry.FileNameLength);

                        //is universal pak?
                        if (fileEntry.Compression < 4 && fileEntry.Compression > -1)
                        {
                            fileEntry.FileName = XOR_data(Encoding.UTF7.GetChars(tempName), fileEntry.FileNameLength, 1);
                            reader.BaseStream.Seek(1L, SeekOrigin.Current);
                            PakType = PangyaPakEnum.Universal;
                        }
                        else
                        {

                            if (PakType == PangyaPakEnum.PakNoSelected)
                            {
                                FindPakLang(fileEntry.Offset, fileEntry.RealFileSize);
                                Pak_Key = PublicKeyTable.XTEA_ALL_KEY[(int)PakType];
                                if (PakType == PangyaPakEnum.PakUnknown)
                                {
                                    Console.WriteLine("The Pak version Invalid !");
                                }
                            }

                           
                            var name = DecryptFileName(tempName, Pak_Key);
                            fileEntry.PathFull = name;
                            if (PakFiles.Count == 0 && IsFolder(name))
                            {
                                fileEntry.FolderSource = name;
                                fileEntry.FolderSub = "...";
                            }
                            if (PakFiles.Count > 0 && IsFolder(name))
                            {
                                fileEntry.FolderSource = "...";
                                fileEntry.FolderSub = GetPath(name);
                            }
                            if (PakFiles.Count > 0 && IsFolder(name) == false)
                            {
                                fileEntry.FolderSource = "...";
                                fileEntry.FolderSub = GetPath(name);
                            }
                            fileEntry.IsFolder = IsFolder(name);
                            fileEntry.IsSubFolder = IsFolder(name);
                            fileEntry.IsOthersFolder = IsSubFolder(name);
                            fileEntry.IsFile = IsFile(name);
                            fileEntry.FileName = GetFileNameExtension(name);
                            fileEntry.Compression ^= 0x20;

                            uint[] decryptionData = { fileEntry.Offset, fileEntry.RealFileSize };

                            XTEA.Decipher(16, ref decryptionData, Pak_Key);
                            fileEntry.Index = (int)i;
                            fileEntry.Offset = decryptionData[0];
                            fileEntry.RealFileSize = decryptionData[1];
                        }
                        PakFiles.Add(fileEntry);
                    }
                }

            }
            PakFiles.Calc();
            return PakResultEnum.Sucess;
        }
        public void UpdateKeyPak(string path)
        {

        }
        public void CreatePak(int EncryptType)
        {
            List<string> ListOfFile = new List<string>();
            List<string> ListOfFolder = new List<string>();


            ListFile(ListOfFile, ListOfFolder);
            Console.WriteLine("Number of File found : {0:D} \n", ListOfFile.Count);

            // PART 1 - Put ALL data in the file ... And save Offset and all 
            uint NumFiles = (uint)(ListOfFile.Count + ListOfFolder.Count);
            byte Sign = 0x12;
            int FakeSize = 0;
            uint[] XTeaInfo = new uint[2];

            string SaveFileName = "ProjectG999";
            switch ((PangyaPakEnum)EncryptType)
            {
                case PangyaPakEnum.GB:
                    SaveFileName += "gb.pak";
                    break;
                case PangyaPakEnum.JP:
                    SaveFileName += "jp.pak";
                    break;
                case PangyaPakEnum.TH:
                    SaveFileName += "th.pak";
                    break;
                case PangyaPakEnum.EU:
                    SaveFileName += "eu.pak";
                    break;
                case PangyaPakEnum.ID:
                    SaveFileName += "id.pak";
                    break;
                case PangyaPakEnum.KR:
                    SaveFileName += "kr.pak";
                    break;
                case PangyaPakEnum.PakOld:
                    SaveFileName += "th.pak";
                    break;
            }
            File.Open(SaveFileName, FileMode.OpenOrCreate).Close();
            PangyaBinaryWriter OutPak;

            PakFiles = new ListPak.PakList(ListOfFile.Count + 1);

            OutPak = new PangyaBinaryWriter();
            for (int i = 0; i < ListOfFile.Count; i++)
            {
                string Filename = ListOfFile[i];

                string RealFileName = "NewPak/";
                RealFileName += Filename;

                var FileData = new PangyaBinaryReader(File.Open(RealFileName, FileMode.OpenOrCreate, FileAccess.Read));


                if (FileData == null)
                {
                    Console.WriteLine("File not found : {0} \n", RealFileName);
                    continue;
                }

                FileData.Seek(0, 2);
                PakFiles.Add(new PakFileEx()
                {
                    FileName = Filename,
                    FileNameLength = (byte)(ListOfFile[i].Length),
                    Compression = 3,
                    Offset = (uint)FileData.BaseStream.Position,
                    RealFileSize = (uint)FileData.BaseStream.Position,
                });

                byte[] DATAin = new byte[PakFiles[i].RealFileSize];
                byte[] DATAout = new byte[1024 * 4096];

                //Now Read File
                FileData.Seek(0, 0);

                DATAin = FileData.ReadBytes(DATAin.Length);
                //Now need to Compress for know the new size
                uint newsize = (uint)LZ77.Compress(DATAin, PakFiles[i].RealFileSize, ref DATAout);
                PakFiles[i].FileSize = newsize;
                OutPak.WriteBytes(DATAout, (int)newsize);
                Console.WriteLine("File Compressed : {0} \n", RealFileName);
                DATAout = null;
            }

            uint OffsetList = (uint)OutPak.BaseStream.Position - 18;

            byte FolderMode = 0x02;
            if (EncryptType != 6)
            {
                FolderMode ^= 0x20;
            }

            // PART 2 - DO THE TABLE-ROLL
            Console.WriteLine("Create table ... ");
            //Folder !
            for (int i = 0; i < ListOfFolder.Count; i++)
            {
                string sFolderName = ListOfFolder[i];
                byte[] bFolderName = new byte[ListOfFolder[i].Length + 9];
                char[] FolderName = new char[ListOfFolder[i].Length + 9];

                var convert_temp = Encoding.UTF7.GetBytes(sFolderName);
                Buffer.BlockCopy(convert_temp, 0, bFolderName, 0, convert_temp.Length);
                uint[] IntFolderName = ConvertArray(sFolderName);
                FolderName = sFolderName.ToCharArray();

                uint size = (uint)(ListOfFolder[i].Length);
                uint Offset = 0;
                uint RealFileSize = 0;
                if (EncryptType != 6)
                {
                    bFolderName = ConvertUIntoBytes(IntFolderName);
                    if (size < 8)
                    {
                        uint[] DataCut = new uint[8];
                        Buffer.BlockCopy(bFolderName, 0, DataCut, 0, 8);
                        XTEA.Encipher(16, ref DataCut, PublicKeyTable.XTEA_ALL_KEY[EncryptType]);
                        Buffer.BlockCopy(DataCut, 0, bFolderName, 0, 8);
                    }
                    else
                    {
                        for (int y = 0; y < ListOfFolder[i].Length; y = y + 8)
                        {
                            uint[] DataCut = new uint[8];
                            Buffer.BlockCopy(bFolderName, y, DataCut, 0, 8);
                            XTEA.Encipher(16, ref DataCut, PublicKeyTable.XTEA_ALL_KEY[EncryptType]);
                            Buffer.BlockCopy(DataCut, 0, bFolderName, y, 8);
                            size = (uint)y;
                        }
                    }

                    XTeaInfo[0] = Offset;
                    XTeaInfo[1] = RealFileSize;
                    XTEA.Encipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[EncryptType]);
                    Offset = XTeaInfo[0];
                    RealFileSize = XTeaInfo[1];
                }
                else
                {
                    sFolderName = XOR_data(FolderName, (int)size, 1);
                }

                size = (uint)bFolderName.Length - 1;
                OutPak.WriteByte((byte)size);
                OutPak.Write(FolderMode);
                OutPak.Write(Offset);
                OutPak.Write(FakeSize);
                OutPak.Write(RealFileSize);
                OutPak.WriteBytes(bFolderName, (int)size);
                if (EncryptType == 6)
                {
                    OutPak.Write(FakeSize);
                }
            }

            for (int i = 0; i < ListOfFile.Count; i++)
            {
                byte[] bFolderName = new byte[ListOfFile[i].Length];
                uint[] IntFolderName = ConvertArray(ListOfFile[i]);

                uint size = (uint)ListOfFile[i].Length;
                if (EncryptType != 6)
                {
                    bFolderName = ConvertUIntoBytes(IntFolderName);
                    for (int y = 0; y < PakFiles[i].FileNameLength; y += 8)
                    {
                        uint[] DataCut = new uint[8];
                        Buffer.BlockCopy(bFolderName, y, DataCut, 0, 8);
                        XTEA.Encipher(16, ref DataCut, PublicKeyTable.XTEA_ALL_KEY[EncryptType]);
                        Buffer.BlockCopy(DataCut, 0, bFolderName, y, 8);
                        size = (uint)y;
                    }

                    PakFiles[i].Compression ^= 0x20;
                    XTeaInfo[0] = PakFiles[i].Offset;
                    XTeaInfo[1] = PakFiles[i].RealFileSize;
                    XTEA.Encipher(16, ref XTeaInfo, PublicKeyTable.XTEA_ALL_KEY[EncryptType]);
                    PakFiles[i].Offset = XTeaInfo[0];
                    PakFiles[i].RealFileSize = XTeaInfo[1];
                }
                else
                {
                    bFolderName = Encoding.UTF8.GetBytes(XOR_data(ListOfFile[i].ToCharArray(), (int)size, 1));
                }
                File.WriteAllBytes("FileCompressName.hex", bFolderName);
                size = (uint)bFolderName.Length - 1;

                OutPak.WriteByte((byte)size);
                OutPak.Write(PakFiles[i].Compression);
                OutPak.Write(PakFiles[i].Offset);
                OutPak.Write(PakFiles[i].FileSize);
                OutPak.Write(PakFiles[i].RealFileSize);
                OutPak.WriteBytes(bFolderName, (int)size);
                if (EncryptType == 6)
                {
                    OutPak.Write(FakeSize);
                }
            }
            Console.WriteLine(" DONE \n");
            // PART 3 - The "header" of the footer ?
            OutPak.Write(OffsetList);
            OutPak.Write(NumFiles);
            OutPak.Write(Sign);
            File.WriteAllBytes(SaveFileName, OutPak.GetBytes());


            //DONE 
            OutPak.Close();
        }

        //by LuisMK
        private void ListFile(List<string> FileList, List<string> FolderList)
        {
            FileList.Clear();

            string OriginalDir = "NewPak";
            string Mask = "//*";
            string ActualFolder = OriginalDir + Mask;

            uint i = uint.MaxValue;

            do
            {

                if (i != uint.MaxValue)
                {
                    ActualFolder = OriginalDir + "/" + FolderList[(int)i] + Mask;
                }

                var hSearch = FindFirstFile(ActualFolder, out WIN32_FIND_DATA file);
                if (hSearch != Win32.INVALID_HANDLE_VALUE)
                {
                    do
                    {
                        var result = StringCompare(file.cFileName);

                        if (!result)
                        {
                            if (file.dwFileAttributes == FileAttributes.Directory && i == uint.MaxValue)
                            {
                                FolderList.Add(file.cFileName);
                            }
                            else if (file.dwFileAttributes != FileAttributes.Directory && i == uint.MaxValue)
                            {
                                FileList.Add(file.cFileName);
                            }
                            else if (file.dwFileAttributes == FileAttributes.Directory)
                            {
                                FolderList.Add(FolderList[(int)i] + "/" + file.cFileName);
                            }
                            else
                            {
                                FileList.Add(FolderList[(int)i] + "/" + file.cFileName);
                            }
                        }
                    } while (FindNextFile(hSearch, out file));
                    FindClose(hSearch);
                }
                i++;
            } while (i < FolderList.Count);
        }

        string DecryptFileName(byte[] fileNameBuffer, uint[] key)
        {
            for (int y = 0; y < fileNameBuffer.Length; y = y + 8)
            {
                uint[] DataCut = new uint[8];
                Buffer.BlockCopy(fileNameBuffer, y, DataCut, 0, 8);

                XTEA.Decipher(16, ref DataCut, key);
                Buffer.BlockCopy(DataCut, 0, fileNameBuffer, y, 8);

            }
            string Return = Encoding.UTF8.GetString(fileNameBuffer.ToArray().TakeWhile(x => x != 0x00).ToArray());

            return Return;
        }

        /// <summary>
        /// returna se é arquivo 
        /// </summary>
        /// <param name="path">string com a informacao</param>
        /// <returns>true = arquivo, false = pasta</returns>
        public bool IsFile(string path)
        {
            path = GetFileNameExtension(path);
            if (path != null)
            {
                var result = path.LastIndexOf('/');
                if (result > -1)
                {
                    return true;
                }
                result = path.LastIndexOf('.');
                if (result == -1)
                {
                    return false;
                }
                return true;//sub
            }

            return false;//arquivo?
        }



        /// <summary>
        /// returna se é arquivo ou caminho 
        /// </summary>
        /// <param name="path">string com a informacao</param>
        /// <returns>true = pasta, false = arquivo</returns>
        public bool IsSubFolder(string path)
        {
            var count = 0;
            count = path.Where(c => c == '/').ToList().Count;

            return count > 1;
        }

        /// <summary>
        /// returna se é arquivo ou caminho 
        /// </summary>
        /// <param name="path">string com a informacao</param>
        /// <returns>true = pasta, false = arquivo</returns>
        public bool IsFolder(string path)
        {
            path =GetFileNameExtension(path);
            if (path != null)
            {
                var result = path.LastIndexOf('.');
                if (result >  -1)
                {
                    return false;
                }
                result = path.LastIndexOf('/');
                if (result == -1)
                {
                    return true;
                }
                return true;//sub
            }

            return false;//arquivo?
        }
        /// <summary>
        /// returna o nome sem a extensao do arquivo
        /// </summary>
        /// <param name="path">string com a informacao</param>
        /// <returns>pangya</returns>
        public string GetFileName(string path)
        {
            if (path != null)
            {
                int length;
                if ((length = path.LastIndexOf('/')) == -1)
                {
                    return path;
                }

                return path.Remove(0, length+1);
            }

            return null;
        }
        /// <summary>
        /// returna o nome sem a extensao do arquivo
        /// </summary>
        /// <param name="path">string com a informacao</param>
        /// <returns>pangya</returns>
        public string GetFileNameWithoutExtension(string path)
        {
           path = GetFileName(path);
            if (path != null)
            {
                int length;
                if ((length = path.LastIndexOf('.')) == -1)
                {
                    return path;
                }

                return path.Substring(0, length);
            }

            return null;
        }


        public string GetFullPath(string path)
        {
            if (path != null)
            {
                int arquivo_len;
                int pasta_len;
                pasta_len = path.LastIndexOf('/');
                if ((arquivo_len = path.LastIndexOf('.')) == -1)
                {
                    return path;
                }
                pasta_len += 1;
                arquivo_len = path.Length - pasta_len;
                return path.Remove(pasta_len-1, arquivo_len+1);
            }

            return null;

        }


        public string GetPath(string path)
        {
            path = GetFullPath(path);
            if (path != null)
            {
                int length;
                if ((length = path.LastIndexOf('/')) == -1)
                {
                    return path;
                }

                return path.Remove(0, length+1);
            }

            return null;

        }
        /// <summary>
        /// returna o nome com a extensao do arquivo
        /// </summary>
        /// <param name="path">string com a informacao</param>
        /// <returns>pangya.jpg</returns>
        public string GetFileNameExtension(string path)
        {
            path = GetFileName(path);
            if (path != null)
            {
                int length;
                if ((length = path.LastIndexOf('.')) == -1)
                {
                    return path;
                }

                return path;
            }

            return null;
        }
    }
}
