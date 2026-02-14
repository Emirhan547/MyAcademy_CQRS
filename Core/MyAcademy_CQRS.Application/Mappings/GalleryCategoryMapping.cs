using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class GalleryCategoryMapping:Profile
    {
        public GalleryCategoryMapping()
        {
            CreateMap<GalleryCategory, GetAllGalleryCategoriesQueryResult>()
              .ForMember(dest => dest.ImageCount,
                  opt => opt.MapFrom(src => src.Images.Count(x => x.IsActive)));

            CreateMap<GalleryCategory, GetGalleryCategoryByIdQueryResult>();
        }
    }
}
