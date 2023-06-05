using Newtonsoft.Json;

namespace DOTNET_IBE_1.Models.GraphQLResponseModels
{
    public class GraphQlResponseModel<T>
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        public GraphQlResponseModel(T data)
        {
            Data = data;
        }
    }
}
