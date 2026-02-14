namespace MyAcademyCQRS.Core.Application.Features.Results.OurStoryResults
{
    public class GetOurStoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}