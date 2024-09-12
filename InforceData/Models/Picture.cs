using InforceData.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace InforceData.Models {
    public class Picture {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedAt { get; set; }
        [AllowNull]
        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
        public List<Reaction> Reactions { get; set; }
        public int Likes() => Reactions.Count(r => r.ReactionType == ReactionType.Like);
        public int Dislikes() => Reactions.Count(r => r.ReactionType == ReactionType.Dislike);
        public string UserEmail { get; set; }
    }
}
