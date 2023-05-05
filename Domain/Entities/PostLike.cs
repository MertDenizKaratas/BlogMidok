using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostLike : BaseEntity
    {
        public int PostId { get; set; }
        public BlogPost Post { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
