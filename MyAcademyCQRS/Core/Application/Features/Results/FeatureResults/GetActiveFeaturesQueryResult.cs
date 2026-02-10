namespace MyAcademyCQRS.Core.Application.Features.Results.FeatureResults
{
    public class GetActiveFeaturesQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StepNumber { get; set; }
    }
}
