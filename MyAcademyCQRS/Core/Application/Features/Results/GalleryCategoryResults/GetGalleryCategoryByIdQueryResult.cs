namespace MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults
{
    public class GetGalleryCategoryByIdQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
