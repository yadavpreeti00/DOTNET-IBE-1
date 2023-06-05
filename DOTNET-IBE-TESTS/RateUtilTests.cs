using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse;
using DOTNET_IBE_1.Utility;


namespace DOTNET_IBE_TESTS
{
    /// <summary>
    /// Tests for RateUtil static class
    /// </summary>
    public class RateUtilTests
    {

        [Theory]
        [MemberData(nameof(GetSampleDataForGetDateToRateMappingFromRoomTypesListMethod))]
        public void GetDateToRateMappingFromRoomTypesListShouldReturnCorrectDictionary
            (List<MinimumNightlyRateRoomType> roomTypesList, Dictionary<string, double> expectedDictionary)
        {
            // Act
            var actualDictionary = RateUtil.GetDateToRateMappingFromRoomTypesList(roomTypesList);
            // Assert
            Assert.Equal(expectedDictionary, actualDictionary);
        }

        [Fact]
        public void GetDateToRateMappingFromRoomTypesListShouldThrowExceptionWhenRoomTypesListIsNull()
        {
            // Arrange
            List<MinimumNightlyRateRoomType> roomTypesList = null;

            // Act and Assert
            Assert.Throws<NotFoundException>(() => RateUtil.GetDateToRateMappingFromRoomTypesList(roomTypesList));
        }


        /// <summary>
        /// Generate data for test
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GetSampleDataForGetDateToRateMappingFromRoomTypesListMethod()
        {
            //creating sample data by referencing graphql data 
            var roomTypesList = new List<MinimumNightlyRateRoomType>
            {
                new MinimumNightlyRateRoomType
                {
                    RoomRates = new List<MinimumNightlyRateRoomRate>
                    {
                        new MinimumNightlyRateRoomRate
                        {
                            RoomRate = new MinimumNightlyRateRoomRateData
                            {
                                BasicNightlyRate = 100,
                                Date = "2023-03-01T00:00:00.000Z"
                            }
                        },
                        new MinimumNightlyRateRoomRate
                        {
                            RoomRate = new MinimumNightlyRateRoomRateData
                            {
                                BasicNightlyRate = 120,
                                Date = "2023-03-02T00:00:00.000Z"
                            }
                        }
                    }
                },
                new MinimumNightlyRateRoomType
                {
                    RoomRates = new List<MinimumNightlyRateRoomRate>
                    {
                        new MinimumNightlyRateRoomRate
                        {
                            RoomRate = new MinimumNightlyRateRoomRateData
                            {
                                BasicNightlyRate = 90,
                                Date = "2023-03-01T00:00:00.000Z"
                            }
                        },
                        new MinimumNightlyRateRoomRate
                        {
                            RoomRate = new MinimumNightlyRateRoomRateData
                            {
                                BasicNightlyRate = 110,
                                Date = "2023-03-02T00:00:00.000Z"
                            }
                        }
                    }
                }
            };

            var expectedDictionary = new Dictionary<string, double>
            {
                {"2023-03-01T00:00:00.000Z", 90},
                {"2023-03-02T00:00:00.000Z", 110}
            };

            yield return new object[] { roomTypesList, expectedDictionary };

        }

    }


}
