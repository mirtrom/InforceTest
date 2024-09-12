using InforceData.Models;
using Microsoft.AspNetCore.Http;

namespace InforceData.Repositories.Interfaces
{
    public interface IPictureRepository: IRepository<Picture> {
        Task<Picture> Upload(IFormFile file, Picture picture);
        Task<IEnumerable<Picture>> GetAllFromAlbum(Guid albumId);
        Task<IEnumerable<Picture>> GetAllFromUser(string userEmail);
        Task<IEnumerable<Picture>> GetPaginated(int page);
    }
}
