using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogPostCategories : BaseEntity
    {
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
