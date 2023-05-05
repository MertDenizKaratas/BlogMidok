using Application.DTOs.User;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstraction.Services
{
    public interface ICategoryService
    {
        public Task<SingleUser> GetCurrentUser();
    }
}
