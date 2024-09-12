using InforceData.Repositories.Implementations;
using InforceData.Repositories.Interfaces;

namespace InforceData.Data {
    public class UnitOfWork : IUnitOfWork {
        public IAlbumRepository AlbumRepository { get; }
        public IPictureRepository PictureRepository { get; }
        public IReactionRepository ReactionRepository { get; }
        private readonly InforceDbContext _context;
        public UnitOfWork(InforceDbContext context) {
            AlbumRepository = new AlbumRepository(context);
            PictureRepository = new PictureRepository(context);
            ReactionRepository = new ReactionRepository(context);
            _context = context;
        }
        public async Task SaveAsync() {
            await _context.SaveChangesAsync();
        }
    }
}
