using System.Text.Json;
using AdminPanel.Domain.Abstraction;
using BusinessService.Contracts.Responses;

namespace AdminPanel.Domain.Services
{
    public class BusinessTopic : IBusinessTopic
    {
        public async Task<List<GetBusinessTopicDto>> GetBusinessTopics()
        {
            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44333/api/v1/BusinessTopics");
            request.Headers.Add("accept", "*/*");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<GetBusinessTopicDto>>(responseBody, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
}
