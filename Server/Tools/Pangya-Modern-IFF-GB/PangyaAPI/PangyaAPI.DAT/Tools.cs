using PangyaAPI.IFF.Definitions;
using System;
using System.IO;
using System.Text;
namespace PangyaAPI.DAT
{
    public static class Tools
    {
        public static LanguageRegion GetEncoding(IFF_REGION region, ref Encoding FileEncoding)
        {
            IFF_REGION iff_region = region;
            switch (iff_region)
            {
                case IFF_REGION.Japan:
                    FileEncoding =  Encoding.GetEncoding(932);
                    return LanguageRegion.JP;

                case IFF_REGION.Korea:
                    FileEncoding =  Encoding.GetEncoding(51949);
                    return LanguageRegion.KR;

                case IFF_REGION.Default:
                case IFF_REGION.Usa:
                    FileEncoding =  Encoding.GetEncoding(874);
                    return LanguageRegion.GB;
            }

            //unknow so encoding UTF8
            FileEncoding =  Encoding.UTF8;
            return LanguageRegion.GB;
        }
        /// <summary>
        /// obtem o tipo codificação/decodificação usada no arquivo
        /// </summary>
        /// <returns>retorna o encoding usado</returns>
        public static LanguageRegion GetEncoding(string filePath, ref Encoding FileEncoding)
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
