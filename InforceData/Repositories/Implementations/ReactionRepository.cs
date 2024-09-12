using InforceData.Data;
using InforceData.Models;
using InforceData.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InforceData.Repositories.Implementations {
    public class ReactionRepository: Repository<Reaction>, IReactionRepository {
        public ReactionRepository(InforceDbContext context) : base(context) { }


        public async Task<Reaction> GetByUserEmailAsync(string userEmail, Guid pictureId) {
            return await dbSet.SingleOrDefaultAsync(r => r.User.Email == userEmail && r.PictureId == pictureId);
        }

        public async Task<IEnumerable<Reaction>> GetByPictureIdAsync(Guid pictureId)
        {
            return await dbSet.Where(r => r.PictureId == pictureId).ToListAsync();
        }
    }
}
