namespace MyAcademyCQRS.Core.Application.Features.Results.SliderResults
{
    public class GetActiveSlidersQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string ProductImageUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
