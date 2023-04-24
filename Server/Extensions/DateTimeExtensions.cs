using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Woolworths.FoodISO.WebClient
{
    public static class DateTimeExtensions
    {

        /// <summary>
        /// Get the date of the start of the week for a date time.
        /// </summary>
        /// <param name="dt">The date time.</param>
        /// <param name="startOfWeek">The weekday that represents the start of the week.</param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Get the date of the end of the week for a date time.
        /// </summary>
        /// <param name="dt">The date time.</param>
        /// <param name="startOfWeek">The weekday that represents the end of the week.</param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek)
        {
            int diff = (7 - (dt.DayOfWeek - endOfWeek)) % 7;
            return dt.AddDays(1 * diff).Date;
        }

        static GregorianCalendar _gc = new GregorianCalendar();

        /// <summary>
        /// Gets the week number in the month of the date.
        /// </summary>
        /// <param name="dt">The date time.</param>
        /// <returns></returns>
        public static int GetWeekNumberOfMonth(this DateTime dt)
        {
            DateTime first = new DateTime(dt.Year, dt.Month, 1);
            return dt.GetWeekNumberOfYear() - first.GetWeekNumberOfYear() + 1;
        }

        /// <summary>
        /// Gets the week number in the year of the date.
        /// </summary>
        /// <param name="dt">The date time.</param>
        /// <returns></returns>
        public static int GetWeekNumberOfYear(this DateTime dt)
        {
            return _gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        /// <summary>
        /// Converts a UTC date and time to SAST.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns></returns>
        public static DateTime ToSAST(this DateTime value)
        {
            var offset = new TimeSpan(2, 0, 0);
            var sastZone = TimeZoneInfo.CreateCustomTimeZone("SAST", offset, "South Africa Standard Time", "South Africa Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(value, sastZone);
        }

    }
}
