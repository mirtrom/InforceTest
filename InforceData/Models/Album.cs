using Microsoft.AspNetCore.Identity;

namespace InforceData.Models {
    public class Album {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Picture> Pictures { get; set; }
        public Guid UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
