namespace MyAcademyCQRS.Core.Application.Features.Results.FeatureResults
{
    public class GetAllFeaturesQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StepNumber { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
