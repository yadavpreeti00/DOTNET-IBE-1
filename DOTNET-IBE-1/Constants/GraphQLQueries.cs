namespace DOTNET_IBE_1.Constants
{
    public class GraphQLQueries
    {
        public static string minimumNightlyRateQuery = "query MyQuery {\n" +
                "  listRoomTypes(where: {property_id: {equals: 3}, room_rates: {some: {room_rate: {date: {gte: \"2023-03-01T00:00:00.000Z\", lte: \"2023-05-31T00:00:00.000Z\"}}}}}, take: {0}, skip: {1}) {\n" +
                "    room_rates {\n" +
                "      room_rate {\n" +
                "        basic_nightly_rate\n" +
                "        date\n" +
                "      }\n" +
                "    }\n" +
                "    property_id\n" +
                "  }\n" +
                "}\n";

    }
}
