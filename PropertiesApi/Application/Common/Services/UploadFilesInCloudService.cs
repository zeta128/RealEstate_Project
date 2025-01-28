using Google.Cloud.Storage.V1;

namespace PropertiesApi.Application.Common.Services
{
    public class UploadFilesInCloudService
    {
     

        public static async Task<string> SaveFileAsync(byte[] fileBytes, string fileName)
        {
            try
            {
                // Directorio donde se almacenarán los archivos (asegurándose de que exista)
                string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "UploadedFiles");

                // Verificar si el directorio existe, de lo contrario, crearlo
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                // Crear la ruta completa del archivo
                string filePath = Path.Combine(directoryPath, fileName);

                // Escribir el archivo de manera asincrónica
                await File.WriteAllBytesAsync(filePath, fileBytes);

                return filePath; // Retorna la ruta donde se almacenó el archivo
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el archivo: {ex.Message}");
                return null;
            }
        }
     

    }
}
