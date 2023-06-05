using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.RequestModels
{
    public class SortTypeRequestModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("attribute")]
        public string Attribute { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }
    }
}
