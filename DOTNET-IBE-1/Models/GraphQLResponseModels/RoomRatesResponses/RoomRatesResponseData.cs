using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels.RoomRatesResponses
{
    public class RoomRatesResponseData
    {
        [JsonProperty("listRoomTypes")]
        public List<RoomType> ListRoomTypes { get; set; }

        public RoomRatesResponseData(List<RoomType> listRoomTypes)
        {
            this.ListRoomTypes = listRoomTypes;
        }
    }
}
