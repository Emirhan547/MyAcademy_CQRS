using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryImages;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryCategoryResults;

using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class GalleryImageMapping:Profile
    {
        public GalleryImageMapping()
        {
            CreateMap<GalleryImage, GetAllGalleryImageQueryResult>();

            CreateMap<GalleryCategory, GetActiveGalleryImageQueryResult>()
                .ForMember(dest => dest.Images,
                    opt => opt.MapFrom(src => src.Images.Where(x => x.IsActive)));

          

            CreateMap<GalleryImage, GetGalleryImageByIdQueryResult>();
        }
    }
}
