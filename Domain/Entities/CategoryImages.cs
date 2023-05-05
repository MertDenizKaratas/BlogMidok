using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryImages : BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        public int CategoryImageId { get; set; }
        public CategoryImageFile CategoryImageFiles { get; set; }
    }
}
