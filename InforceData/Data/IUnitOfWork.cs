using InforceData.Repositories.Interfaces;
namespace InforceData.Data {
    public interface IUnitOfWork {
        Task SaveAsync();
        public IAlbumRepository AlbumRepository { get; }
        public IPictureRepository PictureRepository { get; }
        public IReactionRepository ReactionRepository { get; }
    }
}
