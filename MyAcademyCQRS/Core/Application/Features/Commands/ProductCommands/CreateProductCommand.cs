using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands
{
    public record CreateProductCommand(string Name, string Description, decimal Price, string ImageUrl, int CategoryId);

}
