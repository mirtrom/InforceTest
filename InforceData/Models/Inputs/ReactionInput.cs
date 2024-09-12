namespace InforceData.Models.Inputs {
    public class ReactionInput {
        public ReactionType ReactionType { get; set; }
        public Guid PictureId { get; set; }
        public string UserEmail { get; set; }
    }
}
