using AdminPanel.Contracts;
using AdminPanel.Domain.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers
{
    public class RiskAnalysisController : Controller
    {
        private readonly IRiskAnalysis _riskAnalysis;

        public RiskAnalysisController(IRiskAnalysis riskAnalysis)
        {
            _riskAnalysis = riskAnalysis;
        }

        public async Task<IActionResult> List(Guid businessTopicId)
        {
            return View(await _riskAnalysis.GetRiskAnalysisList(businessTopicId));
        }

        [HttpGet]
        public IActionResult Create(Guid businessTopicId)
        {
            return View(businessTopicId);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRiskAnalysisDto createRiskAnalysisDto)
        {
            var result = await _riskAnalysis.CreateRiskAnalysis(createRiskAnalysisDto);

            if (result != true)
            {

                throw (new Exception());
            }


            return View();
        }
    }
}
