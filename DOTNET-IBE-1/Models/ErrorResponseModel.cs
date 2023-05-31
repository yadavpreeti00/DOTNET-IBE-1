namespace DOTNET_IBE_1.Models
{
    public class ErrorResponseModel
    {
        public string Message { get; set; }
        public string Path { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeStamp { get; set; }

        public ErrorResponseModel(string message, string path, int statusCode, DateTime timeStamp)
        {
            Message = message;
            Path = path;
            StatusCode = statusCode;
            TimeStamp = timeStamp;
        }
    }
}
