using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse;
using DOTNET_IBE_1.Utility;


namespace DOTNET_IBE_TESTS
{
    public class RateUtilTests
    {
        [Fact]
        public void GetDateToRateMappingFromRoomTypesList_ShouldReturnCorrectDictionary()
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

            // Act
            var actualDictionary = RateUtil.GetDateToRateMappingFromRoomTypesList(roomTypesList);

            // Assert
            Assert.Equal(expectedDictionary, actualDictionary);
        }

        [Fact]
        public void GetDateToRateMappingFromRoomTypesList_ShouldThrowException_WhenRoomTypesListIsNull()
        {
            // Arrange
            List<MinimumNightlyRateRoomType> roomTypesList = null;

            // Act and Assert
            Assert.Throws<InvalidRoomTypesListException>(() => RateUtil.GetDateToRateMappingFromRoomTypesList(roomTypesList));
        }

    }


}
