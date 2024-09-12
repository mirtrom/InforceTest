using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InforceData.Models.Inputs
{
    public class GetReactionInput
    {
        public string UserEmail { get; set; }
        public Guid PictureId { get; set; }
    }
}
