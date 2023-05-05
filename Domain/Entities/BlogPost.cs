using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogPost : BaseEntity
    {

        public string Title { get; set; }
        public string Header { get; set; }
        public string Text { get; set; }
        public AppUser? User { get; set; }
        public ICollection<BlogImages> BlogImages { get; set; }
        public ICollection<BlogPostCategories>? BlogPostCategories { get; set; }

        public ICollection<PostLike> Likes { get; set; }
        [NotMapped]
        public bool IsLikedByCurrentUser { get; set; }

    }
}
