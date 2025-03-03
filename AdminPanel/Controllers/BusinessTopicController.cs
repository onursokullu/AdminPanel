using AdminPanel.Domain.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class BusinessTopicController : Controller
    {
        private readonly IBusinessTopic _businessTopic;
        public BusinessTopicController(IBusinessTopic businessTopic)
        {
            _businessTopic = businessTopic;
        }
        public async Task<IActionResult> List()
        {
            return View( await _businessTopic.GetBusinessTopics());
        }
    }
}
