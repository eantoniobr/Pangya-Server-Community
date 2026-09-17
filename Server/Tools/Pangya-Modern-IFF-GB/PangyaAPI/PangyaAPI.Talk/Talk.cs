using PangyaAPI.IFF.Definitions;
using PangyaAPI.Utilities;
using PangyaAPI.Utilities.BinaryModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PangyaAPI.Talk
{
    public class Talk : List<TalkFile>
    {
        public Encoding FileEncoding;
        public LanguageRegion Region { get; set; }

        /// <summary>
        /// ler os arquivos .dat
        /// </summary>
        private void ReadDat(byte[] data)
        {
            int id = 0;
            char[] delimiterChars = { ':' };
            List<char[]> stringCharsTemp = new List<char[]>();
            PangyaBinaryReader reader = new PangyaBinaryReader(new MemoryStream(data), FileEncoding);
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
            try
            {
                List<char> stringChars = new List<char>();

                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    if (reader.PeekChar() != 0x0A)
                    {
                        var schar = reader.ReadChar();
                        stringChars.Add(schar);
                    }
                    else
                    {
                        char[] chars = stringChars.ToArray();
                        byte[] bytes = FileEncoding.GetBytes(chars);
                        stringCharsTemp.Add(chars);

                        Add(new TalkFile(id++, FileEncoding.GetString(bytes).Split(delimiterChars)));

                        reader.BaseStream.Seek(1L, SeekOrigin.Current);
                        stringChars.Clear();
                        if (Count == 34)
                        {
                            Console.WriteLine();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
               
            }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
        }
        string ReplaceFirst(string text, string search, string replace)
        {
            for (int i = 0; i < 2; i++)
            {
                int pos = text.IndexOf(search);
                if (pos < 0)
                {
                    return text;
                }
                text = text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
            }
            return text;
        }
        /// <summary>
        /// ler os arquivos .dat
        /// </summary>
        private void ReadDat(string[] data)
        {
            char[] delimiterChars = { '*' };
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
            try
            {
                for (int i = 0; i < data.Length; i++)
                {
                    var test = ReplaceFirst(data[i], ":", "*").Split(delimiterChars);
                    Add(new TalkFile(i, ReplaceFirst(data[i], ":", "*").Split(delimiterChars)));
                    System.Diagnostics.Debug.WriteLine(this[i].EventText);
                }
            }
            catch (Exception ex)
            {

            }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
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
            GetEncoding(region, ref this.FileEncoding);
            ReadDat(File.ReadAllLines(filePath, FileEncoding));
        }

        /// <summary>
        /// Método que realiza setagens e carregamento das informações do arquivo .dat
        /// </summary>
        /// <param name="filePath"> local onde está o arquivo </param>
        public void LoadFile(string filePath)
        {
            GetEncoding(filePath, ref this.FileEncoding);
            ReadDat(File.ReadAllBytes(filePath));
        }

        public void Save(string filePath)
        {
            using (PangyaBinaryWriter writer = new PangyaBinaryWriter(File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Write), FileEncoding))
            {
                foreach (var entry in this)
                {
                    var format = entry.Create();
                    writer.WriteStr(entry.Create());
                    // writer.WriteByte(0x0A);
                    writer.WriteStr(Environment.NewLine);
                }
            }
        }

         LanguageRegion GetEncoding(IFF_REGION region, ref Encoding FileEncoding)
        {
            IFF_REGION iff_region = region;
            switch (iff_region)
            {
                case IFF_REGION.Japan:
                    FileEncoding = Encoding.GetEncoding(932);
                    return LanguageRegion.JP;

                case IFF_REGION.Korea:
                    FileEncoding = Encoding.GetEncoding(51949);
                    return LanguageRegion.KR;

                case IFF_REGION.Default:
                case IFF_REGION.Usa:
                    FileEncoding = Encoding.GetEncoding(874);
                    return LanguageRegion.GB;
            }

            //unknow so encoding UTF8
            FileEncoding = Encoding.UTF8;
            return LanguageRegion.GB;
        }
        /// <summary>
        /// obtem o tipo codificação/decodificação usada no arquivo
        /// </summary>
        /// <returns>retorna o encoding usado</returns>
         LanguageRegion GetEncoding(string filePath, ref Encoding FileEncoding)
        {
            if (filePath == null)
            {
                throw new InvalidOperationException("No file path given to get encoding from, use SetEncoding() method!");
            }

            string fileName = Path.GetFileNameWithoutExtension(filePath).ToLower();

            switch (fileName)
            {
                case "korea":
                    FileEncoding = Encoding.GetEncoding(51949);
                    return LanguageRegion.KR;
                case "japan":
                    FileEncoding = Encoding.GetEncoding(932);
                    return LanguageRegion.JP;
                case "english":
                    {
                        FileEncoding = Encoding.GetEncoding(874);
                        return LanguageRegion.GB;
                    }

                case "thailand":
                    FileEncoding = Encoding.GetEncoding(874);
                    return LanguageRegion.ID;

                case "indonesia":

                    FileEncoding = Encoding.GetEncoding(65001);
                    return LanguageRegion.ID;

                case "brasil":
                case "spanish":
                case "german":
                case "french":
                    //FileEncoding = Encoding.GetEncoding("");//1252
                    FileEncoding = Encoding.GetEncoding(932);
                    return LanguageRegion.JP;

                default:
                    FileEncoding = Encoding.GetEncoding(65001);
                    return LanguageRegion.Default;
            }
        }

    }
}
