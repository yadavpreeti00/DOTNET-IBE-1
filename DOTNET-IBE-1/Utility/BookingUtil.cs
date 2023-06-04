namespace DOTNET_IBE_1.Utility
{
    public static class BookingUtil
    {
        /// <summary>
        /// To generate random booking id for booking request
        /// </summary>
        /// <returns>a random booking id of size 10</returns>
        public static string GenerateRandomBookingId()
        {
            string uuid = Guid.NewGuid().ToString();
            return uuid.Substring(0, 10);
        }
    }
}
