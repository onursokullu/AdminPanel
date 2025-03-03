using System.Text;
using System.Text.Json;
using AdminPanel.Contracts;
using AdminPanel.Domain.Abstraction;
using BusinessService.Contracts.Responses;

namespace AdminPanel.Domain.Services
{
    public class RiskAnalysis : IRiskAnalysis
    {
        public async Task<List<GetRiskAnalysisDto>> GetRiskAnalysisList(Guid businessTopicId)
        {
            var client = new HttpClient();
            List<GetRiskAnalysisDto> result = new();
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44333/api/RiskAnalysis/{businessTopicId}");
            request.Headers.Add("accept", "*/*");
            var response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<List<GetRiskAnalysisDto>>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return result;
        }

        public async Task<bool> CreateRiskAnalysis(CreateRiskAnalysisDto createRiskAnalysisDto)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44333/api/RiskAnalysis");
            var result = false;
            request.Headers.Add("accept", "*/*");
            var content = new StringContent(JsonSerializer.Serialize(createRiskAnalysisDto),
                                  Encoding.UTF8,
                                  "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                result = true;
            }

            return result;
        }
    }
}
