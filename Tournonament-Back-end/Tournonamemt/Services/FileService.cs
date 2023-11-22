using Tournonamemt.Services.Interface;

namespace Tournonamemt.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _appEnvironment;
    public FileService(IWebHostEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment;
    }
    public Task<string?> UploadTournamentImage(IFormFile tournamentImage)
    {
        return UploadFile(tournamentImage, "/tournament/");
    }
    public Task<string?> UploadUserAvatar(IFormFile avatar)
    {
        return UploadFile(avatar, "/avatar/");
    }
    private async Task<string?> UploadFile(IFormFile file, string path)
    {
        if (file is null) return null;
        string filetypeImage;
        if (file.ContentType != null)
        {
            if (file.ContentType[0..6] == "image/")
            {
                filetypeImage = "." + file.ContentType[6..file.ContentType.Length];
            }
            else
            {
                return null;
            }
        }
        else
        {
            return null;
        }
        var imageNameUnique = System.Guid.NewGuid().ToString() + filetypeImage;
        if (file.Length > 0)
        {
            string imagePath = Path.Combine(_appEnvironment.WebRootPath + path, imageNameUnique);
            using (Stream fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return path + imageNameUnique;
        }
        else
        {
            return null;
        }

    }
}
