﻿using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<BlogPostCategories>? BlogPostCategories { get; set; }
        public ICollection<CategoryImages> CategoryImages { get; set; }
    }
}
