using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Models.RequestModels;
using DOTNET_IBE_1.Models.ResponseModels;

namespace DOTNET_IBE_1.Utility
{
    public static class FilterSortUtil
    {
        /// <summary>
        /// Sort function for price ( low to high and high to low)
        /// </summary>
        /// <param name="sortType"></param>
        /// <param name="rooms"></param>
        public static void ApplySort(SortTypeRequestModel sortType, 
            List<AvailableRoomResponseModel> rooms)
        {
            if (sortType != null)
            {
                string attribute = sortType.Attribute;
                string order = sortType.Order;

                switch (attribute)
                {
                    case CommonConstants.PRICE_SORT:
                        if (order ==CommonConstants.ASCENDING)
                        {
                            rooms.Sort((room1, room2) => room1.Rate.CompareTo(room2.Rate));
                        }
                        else if (order == CommonConstants.DESCENDING)
                        {
                            rooms.Sort((room1, room2) => room2.Rate.CompareTo(room1.Rate));
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Filter function for search room results , filters of room type and bed type
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="rooms"></param>
        public static void ApplyFilter(FilterTypeRequestModel filterType, 
            List<AvailableRoomResponseModel> rooms)
        {
            if (filterType != null)
            {
                string attribute = filterType.Attribute;
                string[] values = filterType.Values;

                switch (attribute)
                {
                    
                    case CommonConstants.BED_FILTER:
                        rooms.RemoveAll(room => !values.Any(value => value.Equals(CommonConstants.SINGLE_BED) 
                        && room.SingleBed > 0) &&
                            !values.Any(value => value.Equals(CommonConstants.DOUBLE_BED) && room.DoubleBed > 0));
                        break;
                    case CommonConstants.ROOM_TYPE_FILTER:
                        rooms.RemoveAll(room => !values.Any(value => room.RoomTypeName.Contains(value)));
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// iterated through each filter type of the filter array from request body
        /// </summary>
        /// <param name="filterOptions"></param>
        /// <param name="rooms"></param>
        public static void ApplyFilterOptions
            (FilterTypeRequestModel[] filterOptions, List<AvailableRoomResponseModel> rooms)
        {
            if (filterOptions != null && filterOptions.Length > 0)
            {
                foreach (var filterType in filterOptions)
                {
                    ApplyFilter(filterType, rooms);
                }
            }
        }


    }
}
