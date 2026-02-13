using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;

namespace MyAcademyCQRS.Models
{
    public class ShopIndexViewModel
    {
        public IList<GetActiveCategoriesQueryResult> Categories { get; set; } = [];
        public IList<ShopProductItemViewModel> Products { get; set; } = [];
        public int? SelectedCategoryId { get; set; }
    }
}
