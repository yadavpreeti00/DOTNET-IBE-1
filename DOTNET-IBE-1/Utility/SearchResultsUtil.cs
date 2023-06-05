using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using DOTNET_IBE_1.Models.GraphQLResponseModels.SearchResultsResponses;
using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Utility
{
    public class SearchResultsUtil
    {
        /// <summary>
        /// Processes the graph ql available room results response and forms the search results respones DTO
        /// </summary>
        /// <param name="roomRatesResult"></param>
        /// <param name="response"></param>
        /// <param name="stayRange"></param>
        /// <param name="roomCount"></param>
        /// <param name="availableRoomResult"></param>
        /// <exception cref="NotFoundException"></exception>
        public static void FormAvailableRoomResultsResponse(Dictionary<string, double> roomRatesResult,
            SearchResultsQueryResponse response, long stayRange, int roomCount,
            List<AvailableRoomResponseModel> availableRoomResult)
        {

            Dictionary<string, Dictionary<long, long>> roomTypeToRoomIds
                = new Dictionary<string, Dictionary<long, long>>();
            List<SearchListRoomAvailabilitiesResponse> listRoomAvailabilities = response.ListRoomAvailabilities;

            foreach (SearchListRoomAvailabilitiesResponse availability in listRoomAvailabilities)
            {
                

                string roomTypeName = availability.Room.RoomType.RoomTypeName;
                long roomId = availability.RoomId;

                if (!roomTypeToRoomIds.ContainsKey(roomTypeName))
                {
                    roomTypeToRoomIds[roomTypeName] = new Dictionary<long, long>();
                }

                Dictionary<long, long> roomCountMap = roomTypeToRoomIds[roomTypeName];

                if (roomCountMap.ContainsKey(roomId))
                {
                    roomCountMap[roomId]++;
                }
                else
                {
                    roomCountMap[roomId] = 1;
                }
            }

            foreach (string roomTypeName in roomTypeToRoomIds.Keys.ToList())
            {
                Dictionary<long, long> roomIds = roomTypeToRoomIds[roomTypeName];
                long roomsAvailableBetweenDateRange = roomIds.Values.Count(value => value >= stayRange);

                if (roomsAvailableBetweenDateRange < roomCount)
                {
                    roomTypeToRoomIds.Remove(roomTypeName);
                }
                else
                {
                    SearchResultRoomType? roomType = response.ListRoomAvailabilities
                        .Select(availability => availability.Room.RoomType)
                        .FirstOrDefault(rt => rt.RoomTypeName == roomTypeName);
                    if (roomType == null)
                    {
                        throw new NotFoundException(ExceptionMessages.SEARCH_RESULTS_ROOM_TYPE_NOT_FOUND);
                    }

                    double roomRate = roomRatesResult.GetValueOrDefault(roomTypeName, 0);

                    AvailableRoomResponseModel roomModel = new AvailableRoomResponseModel(roomType, roomRate);

                    availableRoomResult.Add(roomModel);
                }
            }
        }
    }
}