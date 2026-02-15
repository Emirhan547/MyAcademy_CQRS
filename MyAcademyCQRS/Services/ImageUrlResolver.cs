using Microsoft.Extensions.Configuration;

namespace MyAcademyCQRS.Services;

public class ImageUrlResolver(IConfiguration configuration) : IImageUrlResolver
{
    private readonly string? _bucketName = configuration["GoogleCloud:BucketName"];

    public string Resolve(string? imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            return string.Empty;
        }

        if (Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
        {
            return imageUrl;
        }

        if (imageUrl.StartsWith("~/") || imageUrl.StartsWith('/'))
        {
            return imageUrl;
        }

        if (string.IsNullOrWhiteSpace(_bucketName))
        {
            return imageUrl;
        }

        var normalizedObjectName = string.Join('/', imageUrl
            .Split('/', StringSplitOptions.RemoveEmptyEntries)
            .Select(Uri.EscapeDataString));

        return $"https://storage.googleapis.com/{_bucketName}/{normalizedObjectName}";
    }
}