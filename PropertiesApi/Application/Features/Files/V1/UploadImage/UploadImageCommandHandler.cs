using Google.Cloud.Storage.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PropertiesApi.Application.Common.Wrappers;
using PropertiesApi.Domain.Interfaces;

namespace PropertiesApi.Application.Features.Files.V1.UploadImage
{
    public class UploadImageCommandHandler()
        : IRequestHandler<UploadImageCommand, BaseResponse<String>>
    {
      
        public async Task<BaseResponse<String>> Handle([FromForm] UploadImageCommand request, CancellationToken cancellationToken)
        {


            var credentialsPath = "Domain/Credentials/western-cascade-449020-u1-da3b3661e5f8.json";
            var response = await UploadFileToGoogleCloudAsync(request.PhotoContent!, "Owners/" + request.NamePhoto+"."+ GetImageFormat(request.PhotoContent!), credentialsPath);


            return new BaseResponse<String>(response);

        }
        public async Task<string> UploadFileToGoogleCloudAsync(byte[] fileBytes, string fileName, string credentialsFilePath)
        {
            var httpClientHandler = new HttpClientHandler();
            var httpClient = new HttpClient(httpClientHandler)
            {
                Timeout = TimeSpan.FromMinutes(10) // Ajusta el tiempo de espera aquí
            };
            // Creamos un MemoryStream para que el contenido byte[] sea tratable como un archivo
            using (var memoryStream = new MemoryStream(fileBytes))
            {
                // Especifica el nombre del archivo en Google Cloud Storage y el flujo de datos
                var objectName = fileName;
                StorageClient _storageClient;
                _storageClient = await StorageClient.CreateAsync(
                Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(credentialsFilePath)
            );
                // Subir el archivo al bucket de Google Cloud Storage
                //var storageObject = await _storageClient.UploadObjectAsync(
                //        "real_estates_bucket", objectName, null, memoryStream
                //    );
                using (var fileStream = System.IO.File.OpenRead(credentialsFilePath))
                {
                    var storageObject =  await _storageClient.UploadObjectAsync("real_estates_bucket", objectName, null, fileStream);
                }
                return $"https://storage.googleapis.com/{"real_estates_bucket"}/{fileName}";
            }
        }

        public static string GetImageFormat(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length < 4)
                throw new ArgumentException("Los datos no son válidos o están vacíos.");

            // Leer los primeros bytes
            var header = BitConverter.ToString(imageBytes.Take(4).ToArray()).Replace("-", " ").ToUpper();

            // Comparar con las firmas conocidas
            if (header.StartsWith("FF D8 FF")) return "JPEG";
            if (header.StartsWith("89 50 4E 47")) return "PNG";
            if (header.StartsWith("47 49 46")) return "GIF";
            if (header.StartsWith("42 4D")) return "BMP";
            if (header.StartsWith("52 49 46 46")) return "WEBP"; // WebP (RIFF-based)

            return "Formato desconocido";
        }



    }
}