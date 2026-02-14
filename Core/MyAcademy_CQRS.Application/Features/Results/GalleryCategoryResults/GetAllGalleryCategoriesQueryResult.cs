namespace MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults
{
    public class GetAllGalleryCategoriesQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ImageCount { get; set; }
    }
}
