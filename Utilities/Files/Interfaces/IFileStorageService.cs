using Microsoft.AspNetCore.Http;

public interface IFileStorageService
{
    /// <summary>
    /// Guarda un archivo en la carpeta especificada y devuelve la ruta relativa
    /// </summary>
    /// <param name="file">Archivo a guardar (IFormFile)</param>
    /// <param name="folder">Carpeta dentro de wwwroot donde se guardará</param>
    /// <returns>Ruta relativa del archivo guardado</returns>
    Task<string> SaveFileAsync(IFormFile file, string folder);
}

