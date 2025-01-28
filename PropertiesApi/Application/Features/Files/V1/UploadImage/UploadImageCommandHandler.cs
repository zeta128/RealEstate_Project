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
        /// <summary>
        /// Maneja el comando para subir una imagen a Google Cloud Storage y retorna la URL generada.
        /// </summary>
        /// <param name="request">El comando que contiene los datos necesarios para la carga de la imagen, incluyendo el contenido y el nombre del archivo.</param>
        /// <param name="cancellationToken">Token de cancelación para manejar solicitudes asincrónicas.</param>
        /// <returns>
        /// Un objeto <see cref="BaseResponse{String}"/> que contiene la URL pública de la imagen subida.
        /// </returns>
        /// <remarks>
        /// La función utiliza una ruta local para las credenciales de Google Cloud Storage. 
        /// El archivo se guarda en el bucket con el prefijo "Owners/" seguido del nombre especificado en <paramref name="request.NamePhoto"/>.
        /// Asegúrate de que la ruta de las credenciales sea válida y que las configuraciones de permisos de Google Cloud permitan la carga.
        /// </remarks>        
        public async Task<BaseResponse<String>> Handle([FromForm] UploadImageCommand request, CancellationToken cancellationToken)
        {


            var credentialsPath = "Domain/Credentials/western-cascade-449020-u1-0898aeb3e68c.json";
            var response = await UploadFileToGoogleCloudAsync(request.PhotoContent!, "Owners/" + request.NamePhoto+"."+ GetImageFormat(request.PhotoContent!), credentialsPath);


            return new BaseResponse<String>(response);

        }
        public async Task<string> UploadFileToGoogleCloudAsync(byte[] fileBytes, string fileName, string credentialsFilePath)
        {

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
                var storageObject = await _storageClient.UploadObjectAsync(
                        "test_real_estate_files", objectName, null, memoryStream
                    );
    
                return $"https://storage.googleapis.com/{"test_real_estate_files"}/{fileName}";
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