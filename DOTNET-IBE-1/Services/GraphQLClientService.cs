using DOTNET_IBE_1.Constants;
using DOTNET_IBE_1.Exceptions;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace DOTNET_IBE_1.Services
{

    public class GraphQLClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public GraphQLClientService(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _httpClient.DefaultRequestHeaders.Add("x-api-key", _configuration["GraphQL:ApiKey"]);
            _httpClient.DefaultRequestHeaders.Add("x-api-id", _configuration["GraphQL:ApiId"]);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Querys graphql using httpClient and returns the response
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="GraphQLException"></exception>
        public async Task<TResponse> SendQueryAsync<TResponse>(string query)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _configuration["GraphQL:Endpoint"])
            {
                Content = new StringContent(JsonSerializer.Serialize(new { query }), Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var responseJson = await response.Content.ReadAsStringAsync();
            TResponse? result = JsonConvert.DeserializeObject<TResponse>(responseJson.ToString());
            if(result==null)
            {
                throw new GraphQLException(ExceptionMessages.GRAPH_QL_FAILED);
            }
            return result;
        }
    }
}
