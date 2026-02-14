namespace MyAcademyCQRS.Core.Application.Features.Results.NewsResults
{
    public class GetAllNewsQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
    }
}