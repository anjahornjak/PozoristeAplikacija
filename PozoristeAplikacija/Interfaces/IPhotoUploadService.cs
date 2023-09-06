using CloudinaryDotNet.Actions;

namespace PozoristeAplikacija.Interfaces
{
    public interface IPhotoUploadService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoASync(string publicId); 
         
    }
}
