namespace MyAcademyCQRS.Core.Application.Common.Storage;

public static class ImageStoragePathHelper
{
    public static string? GetObjectNameFromUrl(string? imageUrl)
    {
        if (string.IsNullOrWhiteSpace(imageUrl))
        {
            return null;
        }

        if (!Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri))
        {
            return null;
        }

        return uri.Segments.LastOrDefault()?.Trim('/');
    }
}