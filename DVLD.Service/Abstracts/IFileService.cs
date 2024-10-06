using Microsoft.AspNetCore.Http;

namespace DVLD.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);
    }
}
