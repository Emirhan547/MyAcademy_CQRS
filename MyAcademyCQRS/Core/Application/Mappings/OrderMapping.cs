using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Results.OrderItems;
using MyAcademyCQRS.Core.Application.Features.Results.OrderResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class OrderMapping:Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, GetAllOrdersQueryResult>();

            CreateMap<OrderItem, GetOrderDetailItemQueryResult>()
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.Name));

            CreateMap<Order, GetOrderDetailQueryResult>()
                .ForMember(d => d.Items, o => o.MapFrom(s => s.OrderItems));
        }
    }
}
