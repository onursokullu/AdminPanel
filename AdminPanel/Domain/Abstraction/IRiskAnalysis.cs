using AdminPanel.Contracts;
using BusinessService.Contracts.Responses;

namespace AdminPanel.Domain.Abstraction
{
    public interface IRiskAnalysis
    {
        public Task<List<GetRiskAnalysisDto>> GetRiskAnalysisList(Guid businessTopicId);
        public Task<bool> CreateRiskAnalysis(CreateRiskAnalysisDto createRiskAnalysisDto);

    }
}
