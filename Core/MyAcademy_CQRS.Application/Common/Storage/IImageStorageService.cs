namespace MyAcademy_CQRS.Application.Common.Storage
{
    public interface IImageStorageService
    {
        Task<string> UploadAsync(
            Stream fileStream,
            string fileName,
            string contentType);

        Task DeleteAsync(string fileName);
    }
}
