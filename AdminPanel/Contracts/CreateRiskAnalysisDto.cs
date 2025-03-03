namespace AdminPanel.Contracts
{
    public class CreateRiskAnalysisDto
    {
        public string RiskRuleName { get; set; }
        public Dictionary<string, decimal> RiskParameters { get; set; }
        public string Name { get; set; }
        public Guid BusinessTopicId { get; set; }
        public string RiskDetails { get; set; }
        public string RiskCategory { get; set; }
        public string? MitigationPlan { get; set; }
    }
}
