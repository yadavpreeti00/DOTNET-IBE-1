using System.ComponentModel;

namespace DOTNET_IBE_1.Constants
{
    public static class GraphQLQueries
    {
        public static string minimumNightlyRateQuery = @"query MyQuery {
          listRoomTypes(where: {property_id: {equals: 3}, room_rates: {some: {room_rate: {date: {gte: ""2023-03-01T00:00:00.000Z"", lte: ""2023-07-31T00:00:00.000Z""}}}}}, take: {take}, skip: {skip}) {
            room_rates {
              room_rate {
                basic_nightly_rate
                date
              }
            }
            property_id
          }
        }";

        public static string defaultPromotions = @"query MyQuery {
            listPromotions {
            is_deactivated
            minimum_days_of_stay
            price_factor
            promotion_description
            promotion_id
            promotion_title
            }
            }";

        public static string searchResultsQuery = @"query MyQuery {
             listRoomAvailabilities(where: {property_id: {equals: 3}, date: {gte: ""$startDate"" , lte: ""$endDate"" }, booking_id: {equals: 0}}, take: 1000) {
             date
             room_id
             room {
             room_type {
             room_type_name
             single_bed
             room_type_id
             max_capacity
             double_bed
             area_in_square_feet
             }
             }
             }
            }"
        ;


        public static string rateBetweenDateRangeQuery = @"query MyQuery { 
                 listRoomRates(where: {date: {gte:""$startDate"", lte: ""$endDate""}, AND: {room_types: {some: {room_type: {property_id: {equals: 3}}}}}}, take: 1000) { 
                     basic_nightly_rate 
                     room_types { 
                         room_type { 
                             property_id 
                             room_type_name 
                         } 
                     } 
                 } 
             }";

        public static string roomRatesBreakDown = @"query MyQuery {
          listRoomTypes(where: { property_id: { equals: 3} }, skip:0, take: 1000) {
            room_type_name
            room_rates
                {
                    room_rate
                    {
                        basic_nightly_rate
                        date
                    }
                }
            }
        }
        ";



    }
}
