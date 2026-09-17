using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PangyaAPI.Talk
{
    /// <summary>
    /// editor do arquivo talk,  referencia => https://github.com/retreev/Documentation/blob/master/pc/file-formats/talk.md
    /// </summary>
    public class TalkFile
    {
        /// <summary>
        /// somente um indexador para a linha ou objeto ;) não faz parte do arquivo
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// exemplo : shottime1:
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// exemplo 1:
        /// </summary>
        public uint EventValue { get; set; }
        /// <summary>
        /// exemplo 時間、なくなるわよ？
        /// </summary>
        public string EventText { get; set; }
      public  TalkFile( int id,string[] format)
        {
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
            try
            {
                ID = id;
                if (format.Length == 3)
                {
                    EventName = format[0];
                    EventValue = uint.Parse(format[1]);
                    EventText = format[2];
                }

                if (format.Length >= 4)
                {
                    EventName = format[0];
                    EventValue = uint.Parse(format[1]);
                    EventText = format[2] +":" + format[3];
                }
            }
            catch (Exception ex)
            {
            }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
        }
        public string Create()
        {
            return $"{EventName}:{EventValue}:{EventText}"; 
        }
    }

    public enum LanguageRegion
    {
        Default = -1,
        GB = 0,
        JP = 1,
        KR = 2,
        ID = 3
    }
}
