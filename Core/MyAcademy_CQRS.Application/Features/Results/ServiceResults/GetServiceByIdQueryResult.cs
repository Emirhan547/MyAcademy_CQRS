namespace MyAcademyCQRS.Core.Application.Features.Results.ServiceResults
{
    public class GetServiceByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
    }
}