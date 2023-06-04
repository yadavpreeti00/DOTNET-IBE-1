using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using System.Globalization;
using System.IO;

namespace DOTNET_IBE_1.Utility
{
    public static class DateUtil
    {
        /// <summary>
        /// Gives the number of stay days from start date and end date 
        /// </summary>
        /// <param name="selectedStartDate"></param>
        /// <param name="selectedEndDate"></param>
        /// <returns>stay range</returns>
        /// <exception cref="BadRequestException"></exception>
        public static long GetStayRange(string selectedStartDate, string selectedEndDate)
        {
            DateTime startDate = Convert.ToDateTime(selectedStartDate);
            DateTime endDate = Convert.ToDateTime(selectedEndDate);
            if (startDate > endDate)
            {
                throw new BadRequestException(ExceptionMessages.DATE_RANGE_INVALID);
            }
            return (endDate - startDate).Days + 1;
        }


        /// <summary>
        /// Checks for the weekend type(includes both weekends or only one weekend) from start date and end date 
        /// </summary>
        /// <param name="selectedStartDate"></param>
        /// <param name="selectedEndDate"></param>
        /// <param name="weekendCheckType"></param>
        /// <returns>Boolean value</returns>
        /// <exception cref="ParsingException"></exception>
        public static bool CheckWeekend(string selectedStartDate, string selectedEndDate, string weekendCheckType)
        {
            DateTime startDate = ConvertToDate(selectedStartDate);
            DateTime endDate=ConvertToDate(selectedEndDate);
           
            bool hasSaturday = false;
            bool hasSunday = false;

            //iterating through each date from start date to end date
            for (DateTime date = startDate; date.Date.CompareTo(endDate.Date) <= 0; date = date.AddDays(1))
            {
                // Check if the current day is a Saturday or Sunday
                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    hasSaturday = true;
                }
                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    hasSunday = true;
                }

                // Exit the loop as soon as both Saturday and Sunday are found
                if (hasSaturday && hasSunday)
                {
                    break;
                }
            }
            if (CommonConstants.ALL_WEEKEND.Equals(weekendCheckType, StringComparison.OrdinalIgnoreCase))
            {
                return hasSaturday && hasSunday;
            }
            else
            {
                return hasSaturday || hasSunday;
            }
        }

        /// <summary>
        /// Converts Date string of UTC format to DateTime format 
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns>DateTime</returns>
        /// <exception cref="ParsingException"></exception>
        public static DateTime ConvertToDate(string dateString)
        {
            DateTime date;
            if (DateTime.TryParse(dateString.Split('T')[0], out date))
            {
                return date.Date;
            }
            else
            {
                throw new ParsingException(ExceptionMessages.DATE_PARSING_FAILED);
            }
        }

        /// <summary>
        /// convert string date to Date Time
        /// </summary>
        /// <param name="stringDate"></param>
        /// <returns>Date Time</returns>
        /// <exception cref="ParsingException"></exception>
        public static DateTime ConvertUTCStringToDate(string stringDate)
        {
            DateTime date;
            bool success = DateTime.TryParseExact(stringDate,CommonConstants.UTC_DATE_STRING, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (success)
            {
                return date;
            }
            else
            {
                throw new ParsingException(ExceptionMessages.DATE_PARSING_FAILED);
            }
        }
    }

    

}
