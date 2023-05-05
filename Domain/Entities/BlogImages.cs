using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BlogImages
    {
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public int BlogPostImageId { get; set; }
        public BlogPostImageFıle BlogPostImageFile { get; set; }
    }
}
