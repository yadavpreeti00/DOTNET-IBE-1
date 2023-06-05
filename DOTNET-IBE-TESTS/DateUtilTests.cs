using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOTNET_IBE_TESTS
{
    /// <summary>
    /// tests for DateUtil static class
    /// </summary>
    public class DateUtilTests
    {
        [Fact]
        public void GetStayRangeStartDateLessThanEndDateUTCFormat()
        {
            string selectedStartDate = "2023-04-01T14:00:50.000Z";
            string selectedEndDate = "2023-04-06T14:00:50.000Z";
            long expected = 6;
            long actual = DateUtil.GetStayRange(selectedStartDate, selectedEndDate);
            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetStayRangeStartDateLessThanEndDate()
        {
            string selectedStartDate = "2023-04-01";
            string selectedEndDate = "2023-04-06";
            long expected = 6;
            long actual = DateUtil.GetStayRange(selectedStartDate, selectedEndDate);
            // Assert
            Assert.Equal(expected, actual);
        }



        [Fact]
        public void GetStayRangeStartDateGreaterThanEndDate()
        {
            string selectedStartDate = "2023-04-11T14:00:50.000Z";
            string selectedEndDate = "2023-04-06T14:00:50.000Z";
            Assert.Throws<BadRequestException>(() => DateUtil.GetStayRange(selectedStartDate, selectedEndDate));
        }

        /// <summary>
        /// To check whether the date range includes both saturday and sunday
        /// </summary>
        [Fact]
        public void CheckWeekendForAllWeekendForDatesIncludingSaturdaySunday()
        {
            // Arrange
            string startDate = "2023-06-02T00:00:00"; // Friday
            string endDate = "2023-06-04T00:00:00"; // Sunday
            string weekendCheckType = CommonConstants.ALL_WEEKEND;
            bool expectedResult = true;

            // Act
            bool actualResult = DateUtil.CheckWeekend(startDate, endDate, weekendCheckType);

            // Assert
            Assert.Equal(expectedResult,actualResult);
        }

        [Fact]
        public void CheckWeekendForAllWeekendForDatesIncludingSaturdayForAnyWeekEnd()
        {
            // Arrange
            string startDate = "2023-06-02T00:00:00"; // Friday
            string endDate = "2023-06-03T00:00:00"; // Saturday
            string weekendCheckType = CommonConstants.ANY_WEEKEND;
            bool expectedResult = true;

            // Act
            bool actualResult = DateUtil.CheckWeekend(startDate, endDate, weekendCheckType);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void CheckWeekendForAllWeekendForDatesIncludingSaturdayForAllWeekend()
        {
            // Arrange
            string startDate = "2023-06-02T00:00:00"; // Friday
            string endDate = "2023-06-03T00:00:00"; // Saturday
            string weekendCheckType = CommonConstants.ALL_WEEKEND;
            bool expectedResult = false;

            // Act
            bool actualResult = DateUtil.CheckWeekend(startDate, endDate, weekendCheckType);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void CheckWeekendForAllWeekendForDatesIncludingSaturdaySundayForAnyWeekend()
        {
            // Arrange
            string startDate = "2023-06-02T00:00:00"; // Friday
            string endDate = "2023-06-04T00:00:00"; // Sunday
            string weekendCheckType = CommonConstants.ALL_WEEKEND;
            bool expectedResult = true;

            // Act
            bool actualResult = DateUtil.CheckWeekend(startDate, endDate, weekendCheckType);

            // Assert
            Assert.Equal(expectedResult, actualResult);

        }

        [Fact]
        public void ConvertToDateWithValidDateStringGivenUTCFormat()
        {
            // Arrange
            string dateString = "2023-06-02T14:35:13";
            DateTime expectedDate = new DateTime(2023, 6, 2);

            // Act
            DateTime actualDate = DateUtil.ConvertToDate(dateString);

            // Assert
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void ConvertToDateWithValidDateStringGiven()
        {
            // Arrange
            string dateString = "2023-06-02";
            DateTime expectedDate = new DateTime(2023, 6, 2);

            // Act
            DateTime actualDate = DateUtil.ConvertToDate(dateString);

            // Assert
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void ConvertToDateWithInvalidDateStringGiven()
        {
            // Arrange
            string dateString = "invalid date";

            // Act and Assert
            Assert.Throws<ParsingException>(() => DateUtil.ConvertToDate(dateString));
        }

        [Fact]
        public void ConvertUTCStringToDateWithValidUTCStringGiven()
        {
            // Arrange
            string stringDate = "2023-06-02T14:35:13";
            DateTime expectedDate = new DateTime(2023, 6, 2, 14, 35, 13);

            // Act
            DateTime actualDate = DateUtil.ConvertUTCStringToDate(stringDate);

            // Assert
            Assert.Equal(expectedDate, actualDate);
        }

        [Fact]
        public void ConvertUTCStringToDateWithInvalidUTCStringGiven()
        {
            // Arrange
            string stringDate = "invalid date";
            // Act and Assert
            Assert.Throws<ParsingException>(() => DateUtil.ConvertUTCStringToDate(stringDate));
        }


    }
}
