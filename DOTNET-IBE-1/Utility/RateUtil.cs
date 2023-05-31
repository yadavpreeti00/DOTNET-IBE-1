using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse;

namespace DOTNET_IBE_1.Utility
{
    public class RateUtil
    {
        /// <summary>
        ///  Process the roomTypesList to get minimum rate against each date in from of dictionary                        
        /// </summary>
        /// <param name="roomTypesList"></param>
        /// <returns></returns>
        /// <exception cref="InvalidRoomTypesListException"></exception>
        public static Dictionary<string,double> GetDateToRateMappingFromRoomTypesList(List<MinimumNightlyRateRoomType> roomTypesList)
        {
            if(roomTypesList == null)
            {
                throw new InvalidRoomTypesListException(ExceptionMessages.NULL_LIST_ROOM_TYPES);
            }
            Dictionary<string, double> minimumNightlyRateDictionary = roomTypesList
                //flatten the response
                .SelectMany(roomType => roomType.RoomRates)
                .Select(roomRate => roomRate.RoomRate)
                .Select(rate => new
                {
                    BasicNightlyRate = rate.BasicNightlyRate,
                    Date = rate.Date,
                })
                //group by date
                .GroupBy(x => x.Date)
                //key is the key of group , and value is the min of basic rate of that grp
                .ToDictionary(g => g.Key, g => g.Min(x => x.BasicNightlyRate));
            return minimumNightlyRateDictionary;
        }
    }
}
