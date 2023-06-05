using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.RequestModels
{
    public class FilterTypeRequestModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("attribute")]
        public string Attribute { get; set; }
        [JsonProperty("values")]
        public string[] Values { get; set; }
    }
}
