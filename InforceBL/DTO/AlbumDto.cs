using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InforceBL.DTO
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<PictureDto> Pictures { get; set; }
        public Guid UserId { get; set; }
        public string UserEmail { get; set; }
    }
}
