using Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface IPostService
    {
        public Task AddPost(VM_Create_Post postItem);
    }
}
