namespace DOTNET_IBE_1.Constants
{
    public class ExceptionMessages
    {
        public static readonly string GRAPH_QL_FAILED = "Failed to fetch data from graph ql.";
        public static readonly string NULL_LIST_ROOM_TYPES = "The room types list cannot be null.";
        public static readonly string NULL_GRAPHQL_QUERY = "The string to query graph ql cannot be null.";
        public static readonly string INTERNAL_SERVER_ERROR = "Something went wrong.";
        public static readonly string INVALID_CREDENTIALS = "The credentials are not valid";
        public static readonly string NULL_CREDENTIALS = "Credentails cannot be null.";
        public static readonly string UNKNOWN_EXCEPTION = "An unknown exception occurred.";
        public static readonly string STACKTRACE_UNAVAILABLE = "No stack trace available.";
        public static readonly string SQS_MESSAGE_SENT_FAILED = "Failed to send message to the SQS queue";
        public static readonly string LANDING_PAGE_CONFIGURATION_NOT_FOUND = "Could not get landing page configuration  data.";
        public static readonly string ROOM_RESULTS_PAGE_CONFIGURATION_NOT_FOUND = "Could not get room results page configuratio data.";
        public static readonly string CHECKOUT_PAGE_CONFIGURATION_NOT_FOUND = "Could not get checkout page configuration data.";
        public static readonly string QueueMessageDeletionFailed = "Failed to delete message from queue.";
        public static readonly string PROMO_CODE_EMPTY = "Promo code cannot be empty";
        public static readonly string PROMO_CODE_INVALID = "Promo code is invalid";
        public static readonly string PROMO_CONDITIONS_INVALID = "Promo conditions are not valid";
        public static readonly string DATE_RANGE_INVALID = "The date range is not valid";
        public static readonly string FAILED_TO_RETRIEVE_ROOM_RATE = "failed to retrieve room rates from API.";
        public static readonly string FAILED_TO_RETRIEVE_AVAILABLE_ROOMS = "failed to retrieve available rooms.";
        public static readonly string DATE_PARSING_FAILED = "Date parsing failed";
        public static readonly string FAILED_TO_RETRIEVE_PRICE_BREAKDOWN = "Failed to retrieve price break down from graphql.";
        public static readonly string SEARCH_RESULTS_ROOM_TYPE_NOT_FOUND = "Search results room type not found";
        public static readonly string BOOKING_STATUS_NOT_FOUND = "Booking status not found";
        public static readonly string BOOKING_DETAILS_NOT_FOUND = "Could not find booking details";
        public static readonly string FAILED_TO_PARSE_QUEUE_REQUEST = "Failed to parse queue booking request";
        public static readonly string FAILED_TO_PARSE_QUEUE_REQUEST_TOTAL_FOR_STAY = "Failed to parse queue booking request total for stay";
    }
}
