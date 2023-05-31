namespace DOTNET_IBE_1.Constants
{
    public static class GraphQLQueries
    {
        public static string minimumNightlyRateQuery = @"query MyQuery {
          listRoomTypes(where: {property_id: {equals: 3}, room_rates: {some: {room_rate: {date: {gte: ""2023-03-01T00:00:00.000Z"", lte: ""2023-05-31T00:00:00.000Z""}}}}}, take: {take}, skip: {skip}) {
            room_rates {
              room_rate {
                basic_nightly_rate
                date
              }
            }
            property_id
          }
        }";

    }
}
