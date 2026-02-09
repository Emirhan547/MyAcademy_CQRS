using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;

namespace MyAcademyCQRS.Mappings
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryMapping, GetCategoriesQueryResult>();
        }
    }
}
