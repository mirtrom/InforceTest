using InforceData.Data;
using InforceData.Models;
using InforceData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceData.Repositories.Implementations {
    public class AlbumRepository : Repository<Album>, IAlbumRepository {
        public AlbumRepository(InforceDbContext context) : base(context) {
        }

        public async Task<Album> GetByIdWithDetailsAsync(Guid id) {
            return await dbSet
                 .Include(a => a.Pictures)
                 .Include(a => a.User)
                 .SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Album>> GetPageAsync(int page) {
            var pageSize = 5;
            return await dbSet
                .Include(a => a.Pictures)
                .Include(a => a.User)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetUsersAlbumsAsync(string user) {
            return await dbSet
                .Include(a => a.Pictures)
                .Include(a => a.User)
                .Where(a => a.User.Email == user)
                .ToListAsync();
        }
    }
}
