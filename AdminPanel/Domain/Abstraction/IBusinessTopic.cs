using BusinessService.Contracts.Responses;

namespace AdminPanel.Domain.Abstraction
{
    public interface IBusinessTopic
    {
        Task<List<GetBusinessTopicDto>> GetBusinessTopics();
    }
}