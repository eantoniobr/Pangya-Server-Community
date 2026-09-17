using System;
using System.Runtime.InteropServices;
namespace PangyaAPI.IFF.StructModels
{
    /// <summary>
    /// System time structure based on Windows internal SYSTEMTIME struct
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public class IFFTime
    {
        /// <summary>
        /// Year
        /// </summary>
        public ushort Year { get; set; }

        /// <summary>
        /// Month
        /// </summary>
        public ushort Month { get; set; }

        /// <summary>
        /// Day of Week
        /// </summary>
        public ushort DayOfWeek { get; set; }

        /// <summary>
        /// Day
        /// </summary>
        public ushort Day { get; set; }

        /// <summary>
        /// Hour
        /// </summary>
        public ushort Hour { get; set; }

        /// <summary>
        /// Minute
        /// </summary>
        public ushort Minute { get; set; }

        /// <summary>
        /// Second
        /// </summary>
        public ushort Second { get; set; }

        /// <summary>
        /// Millisecond
        /// </summary>
        public ushort MilliSecond { get; set; }

        public bool TimeActive
        {
            get
            {
                return Year > 0 && Month > 0 && DayOfWeek > 0 && Day > 0 && Hour > 0 && Minute > 0 && Second > 0 && MilliSecond > 0;
            }
        }

        public DateTime ConvertIFFToDateTime()
        {
            return new DateTime(Year,Month, Day, Hour, Minute, Second, MilliSecond);
        }

        public IFFTime ConvertDateTimeToIFF(DateTime date)
        {
            Year = (ushort)date.Year;
            Month = (ushort)date.Month;
            DayOfWeek = (ushort)date.DayOfWeek;
            Day = (ushort)date.Day;
            Hour = (ushort)date.Hour;
            Minute = (ushort)date.Minute;
            Second = (ushort)date.Second;
            return this;
        }
    }
}
