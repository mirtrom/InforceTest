using InforceData.Models;

namespace InforceData.Repositories.Interfaces {
    public interface IAlbumRepository : IRepository<Album> {

        Task<IEnumerable<Album>> GetPageAsync(int page);
        Task<Album> GetByIdWithDetailsAsync(Guid id);
        Task<IEnumerable<Album>> GetUsersAlbumsAsync(string userId);
    }
}
