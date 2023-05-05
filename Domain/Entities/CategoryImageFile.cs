using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoryImageFile : ETicaretAPI.Domain.Entities.File
    {
        public bool Showcase { get; set; }
        public ICollection<CategoryImages> CategoryImages { get; set; }
    }
}
