namespace MyAcademyCQRS.Core.Application.Features.Results.CategoryResults
{
    public class GetAllCategoriesQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
