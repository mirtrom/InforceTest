using InforceData.Data;
using InforceData.Models;
using InforceData.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace InforceData.Repositories.Implementations {
    public class PictureRepository : Repository<Picture>, IPictureRepository {
        public PictureRepository(InforceDbContext context) : base(context) { }

        public async Task<IEnumerable<Picture>> GetAllFromAlbum(Guid albumId){
            return await dbSet.Where(p => p.AlbumId == albumId).ToListAsync();
        }

        public async Task<IEnumerable<Picture>> GetAllFromUser(string userEmail)
        {
            return await dbSet.Where(p => p.UserEmail == userEmail).ToListAsync();
        }

        public async Task<IEnumerable<Picture>> GetPaginated(int page)
        {
            var pageSize = 5;
            return await dbSet
                .Include(a => a.Reactions)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Picture> Upload(IFormFile file, Picture picture) {
            string wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            string imagesFolder = Path.Combine(wwwRootPath, "Images");
            string localPath = Path.Combine(imagesFolder, $"{picture.Title}{picture.Extension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            string baseUrl = "/Images";
            picture.Url = $"{baseUrl}/{picture.Title}{picture.Extension}";

            await AddAsync(picture);
            return picture;
        }
    }
}
