namespace Tournonamemt.Services.Interface
{
    public interface IFileService
    {
        public Task<string?> UploadTournamentImage(IFormFile tournamentImage);
        Task<string?> UploadUserAvatar(IFormFile avatar);
    }
}
