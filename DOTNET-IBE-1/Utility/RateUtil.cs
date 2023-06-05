using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.GraphQLResponseModels.MinimumNightlyRatesResponse;
using DOTNET_IBE_1.Models.GraphQLResponseModels.RoomRatesResponses;
using DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses;
using DOTNET_IBE_1.Models.RequestModels;

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
        public static Dictionary<string, double> GetDateToRateMappingFromRoomTypesList
            (List<MinimumNightlyRateRoomType> roomTypesList)
        {
            if (roomTypesList == null)
            {
                throw new NotFoundException(ExceptionMessages.NULL_LIST_ROOM_TYPES);
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

        /// <summary>
        /// Calculates the average rate of the stay for each room type
        /// </summary>
        /// <param name="response"></param>
        /// <param name="stayRange"></param>
        /// <param name="requestPropertyId"></param>
        /// <returns>dictionary containing the roomtypename to average rate</returns>
        public static Dictionary<string, double> CalculateAverageRatePerStay
            (SearchRoomRatesQueryResponse response, long stayRange, int requestPropertyId)
        {
            var roomTypeToRateMap = new Dictionary<string, double>();
            foreach (var roomRate in response.ListRoomTypes)
            {
                double roomTypeRate = roomRate.BasicNightlyRate;
                roomRate.RoomTypes.ForEach(roomType => { Console.WriteLine(roomType.RoomType.RoomTypeName); });
                var filteredRoomTypes = roomRate.RoomTypes
                    .Where(roomType => roomType.RoomType.PropertyId == requestPropertyId)
                    .Select(roomType => roomType.RoomType.RoomTypeName).ToList();

                roomRate.RoomTypes.ForEach(roomType => { Console.WriteLine(roomType.RoomType.PropertyId); });

                foreach (var roomTypeName in filteredRoomTypes)
                {
                    if (roomTypeToRateMap.ContainsKey(roomTypeName))
                    {
                        roomTypeToRateMap[roomTypeName] += roomTypeRate;
                    }
                    else
                    {
                        roomTypeToRateMap[roomTypeName] = roomTypeRate;
                    }
                }
            }
            foreach (var roomTypeToRate in roomTypeToRateMap.ToList())
            {
                double value = roomTypeToRate.Value;
                value = value / stayRange;
                value = Math.Round(value * 100.0) / 100.0; // rounding off to 2 decimal places

                roomTypeToRateMap[roomTypeToRate.Key] = value;
            }
            return roomTypeToRateMap;
        }

        /// <summary>
        /// Makes a dictionary of date to price for that day for the entire stay
        /// </summary>
        /// <param name="roomRatesResponse"></param>
        /// <param name="priceBreakdownRequest"></param>
        /// <param name="priceBreakDownResult"></param>
        /// <returns></returns>
        public static Dictionary<string, int> GetPriceBreakdown
            (RoomRatesResponseData roomRatesResponse, PriceBreakdownRequestModel priceBreakdownRequest, 
            Dictionary<string, int> priceBreakDownResult)
        {

            List<RoomType> listRoomTypes = roomRatesResponse.ListRoomTypes;
            foreach (RoomType roomType in listRoomTypes)
            {
                if (!priceBreakdownRequest.RoomType.Equals(roomType.RoomTypeName, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                var roomRates = roomType.RoomRates;
                foreach (var roomRate in roomRates)
                {
                    DateTime startDate = DateUtil.ConvertToDate(priceBreakdownRequest.StartDate);
                    DateTime endDate = DateUtil.ConvertToDate(priceBreakdownRequest.EndDate);
                    DateTime currentDate = DateUtil.ConvertToDate(roomRate.RoomRateData.Date);
                    if ((currentDate > startDate && currentDate < endDate) || currentDate == startDate 
                        || currentDate == endDate)
                    {
                        int price = (int)roomRate.RoomRateData.BasicNightlyRate;

                        priceBreakDownResult[currentDate.ToString(CommonConstants.DATE_FORMAT)] = price;
                    }
                }
            }
            return priceBreakDownResult;
        }
    }

}