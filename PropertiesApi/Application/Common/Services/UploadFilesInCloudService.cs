using Google.Cloud.Storage.V1;

namespace PropertiesApi.Application.Common.Services
{
    public class UploadFilesInCloudService
    {
        public static async Task<object> GoogleCloudStorageService(string credentialsFilePath, string bucketName)
        {

            // Crear el cliente usando las credenciales de la cuenta de servicio
            return await StorageClient.CreateAsync(
                Google.Apis.Auth.OAuth2.GoogleCredential.FromFile(credentialsFilePath)
            );
        }



        internal static async Task<string> UploadFileToGoogleCloudAsync(byte[] fileBytes, string fileName, string credentialsFilePath)
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

                Console.WriteLine($"Archivo {fileName} subido a Google Cloud Storage con éxito.");
                return $"https://storage.googleapis.com/{"test_real_estate_files"}/{fileName}";
            }
        }

    }
}
