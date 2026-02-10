using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;
using MyAcademyCQRS.Core.Domain.Entities;


namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<UpdateCategoryCommand, Category>();

            CreateMap<Category, GetAllCategoriesQueryResult>();
            CreateMap<Category, GetActiveCategoriesQueryResult>();
        }
    }
}
