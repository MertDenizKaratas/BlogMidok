using Domain.Entities;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
    public class VM_Create_Post
    {
        public string? Title { get; set; }
        public string? Header { get; set; }
        public long? Text { get; set; }
    }
}
