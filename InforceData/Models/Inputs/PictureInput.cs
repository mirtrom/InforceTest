using Microsoft.AspNetCore.Http;

namespace InforceData.Models.Inputs {
    public class PictureInput {
        public string Title { get; set; }
        public IFormFile File { get; set; }
        public Guid AlbumId { get; set; }
    }
}
