using PangyaAPI.IFF.JP.Extensions;
using PangyaAPI.IFF.JP.Models.Flags;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
namespace Pangya_Modern_Editor.Extensions
{
    public enum LanguageRegion
    {
        Default = -1,
        GB = 0,
        JP = 1,
        KR = 2,
        TH = 3,
        ID = 4      
    }
    public class DATFile
    {
        public DATFile(int value, string value2)
        {
            ID = value;
            Line = value2;
        }
        /// <summary>
        /// index line
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// texto armazenarado
        /// </summary>
        public string Line { get; set; }
    }
    public class Language : List<DATFile>
    {
        public Encoding FileEncoding;
        public LanguageRegion Region { get; set; }

        /// <summary>
        /// ler os arquivos .dat
        /// </summary>
        private void ReadDat(Stream data)
        {
            int id = 0;
            using (PangyaBinaryReader reader = new PangyaBinaryReader(data, FileEncoding))
            {
                List<char> stringChars = new List<char>();

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    if (reader.PeekChar() != 0x00)
                    {
                        var ch = (reader.ReadChar());
                        stringChars.Add(ch);
                    }
                    else
                    {
                        char[] chars = stringChars.ToArray();
                        byte[] bytes = FileEncoding.GetBytes(chars);
                        var sString = FileEncoding.GetString(bytes);
                        Add(new DATFile(id, sString));

                        reader.BaseStream.Seek(1L, SeekOrigin.Current);
                        id++;
                        stringChars.Clear();
                    }
                }
            }
        }



        /// <summary>
        /// ler os arquivos .dat
        /// </summary>
        private void ReadDat(byte[] data)
        {
            int id = 0;
            using (PangyaBinaryReader reader = new PangyaBinaryReader(new MemoryStream(data), FileEncoding))
            {
                List<char> stringChars = new List<char>();

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    if (reader.PeekChar() != 0x00)
                    {
                        var ch = (reader.ReadChar());
                        stringChars.Add(ch);
                    }
                    else
                    {
                        char[] chars = stringChars.ToArray();
                        byte[] bytes = FileEncoding.GetBytes(chars);
                        var sString = FileEncoding.GetString(bytes);
                        Add(new DATFile(id, sString));

                        reader.BaseStream.Seek(1L, SeekOrigin.Current);
                        id++;
                        stringChars.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Returns the encoding used by the DATFile instance
        /// </summary>
        public Encoding GetEncoding()
        {
            return FileEncoding;
        }

        /// <summary>
        /// Método que realiza setagens e carregamento das informações do arquivo .dat
        /// </summary>
        /// <param name="filePath"> local onde está o arquivo </param>
        public void LoadFile(string filePath, IFF_REGION region)
        {
            Util.GetEncoding(region, ref this.FileEncoding);
            ReadDat(File.ReadAllBytes(filePath));
        }

        /// <summary>
        /// Método que realiza setagens e carregamento das informações do arquivo .dat
        /// </summary>
        /// <param name="filePath"> local onde está o arquivo </param>
        public void LoadFile(string filePath)
        {
            Util.GetEncoding(filePath, ref this.FileEncoding);
            ReadDat(File.Open(filePath, FileMode.Open, FileAccess.Read));
        }

        public void Save(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                    File.Delete(filePath);

                using (PangyaBinaryWriter writer = new PangyaBinaryWriter(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write), FileEncoding))
                {
                    foreach (var entry in this)
                    {

                        var bytes = FileEncoding.GetBytes(entry.Line);
                        writer.Write(bytes, bytes.Length);
                        writer.Write((byte)0);
                    }
                }
            }
            catch (Exception ex)
            {            
                throw ex;
            }
        }
    }
}
