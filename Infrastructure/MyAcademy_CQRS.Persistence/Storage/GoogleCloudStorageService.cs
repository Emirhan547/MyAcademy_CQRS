using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using MyAcademyCQRS.Core.Application;
using System.Text.Json;

namespace MyAcademyCQRS.Infrastructure.Storage
{
    public class GoogleCloudStorageService : IImageStorageService
    {
        private readonly StorageClient _storageClient;
        private readonly string _bucketName;

        public GoogleCloudStorageService(IConfiguration configuration)
        {
            _bucketName = configuration["GoogleCloud:BucketName"]
                ?? throw new ArgumentNullException("BucketName not found.");

            // secrets.json içindeki nested json'u alıyoruz
            var section = configuration.GetSection("GoogleCloud:ServiceAccountJson");

            var serviceAccountDict = section.Get<Dictionary<string, object>>()
                ?? throw new ArgumentNullException("ServiceAccountJson not found.");

            var credentialsJson = JsonSerializer.Serialize(serviceAccountDict);

            var credential = GoogleCredential
     .FromJson(credentialsJson)
     .CreateScoped("https://www.googleapis.com/auth/devstorage.full_control");


            _storageClient = StorageClient.Create(credential);
        }

        public async Task<string> UploadAsync(
            Stream fileStream,
            string fileName,
            string contentType)
        {
            await _storageClient.UploadObjectAsync(
                bucket: _bucketName,
                objectName: fileName,
                contentType: contentType,
                source: fileStream);

            return $"https://storage.googleapis.com/{_bucketName}/{fileName}";
        }

        public async Task DeleteAsync(string fileName)
        {
            await _storageClient.DeleteObjectAsync(_bucketName, fileName);
        }
    }
}