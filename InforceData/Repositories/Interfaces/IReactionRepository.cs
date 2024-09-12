using InforceData.Models;
namespace InforceData.Repositories.Interfaces
{
    public interface IReactionRepository: IRepository<Reaction> {
        Task<Reaction> GetByUserEmailAsync(string userEmail, Guid pictureId);
        Task<IEnumerable<Reaction>> GetByPictureIdAsync(Guid pictureId);
    }
}
