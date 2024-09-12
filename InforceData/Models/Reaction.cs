using Microsoft.AspNetCore.Identity;

namespace InforceData.Models {
    public class Reaction {
        public Guid Id { get; set; }
        public Guid PictureId { get; set; }
        public Picture Picture { get; set; }
        public ReactionType ReactionType { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
