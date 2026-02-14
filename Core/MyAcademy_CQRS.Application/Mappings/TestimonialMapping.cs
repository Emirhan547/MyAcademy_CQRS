using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands;
using MyAcademyCQRS.Core.Application.Features.Results.TestimonialResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class TestimonialMapping:Profile
    {
        public TestimonialMapping()
        {
            CreateMap<CreateTestimonialCommand, Testimonial>();
            CreateMap<UpdateTestimonialCommand, Testimonial>();

            CreateMap<Testimonial, GetAllTestimonialsQueryResult>();
            CreateMap<Testimonial, GetActiveTestimonialsQueryResult>();
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>();
        }
    }
}
