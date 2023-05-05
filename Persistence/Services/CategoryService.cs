using Application.Abstraction.Services;
using Application.DTOs.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class CategoryService : ICategoryService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        public CategoryService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<SingleUser> GetCurrentUser()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (username != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new()
                {
                    NameSurname = user.NameSurname,
                    Email = user.Email,
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            else
            {
                throw new NotFoundUserException();
            }
        }
        public async Task<AppUser> GetCurrentUserType()
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (username != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                return new()
                {
                    NameSurname = user.NameSurname,
                    Email = user.Email,
                    Id = user.Id,
                    UserName = user.UserName
                };
            }
            else
            {
                throw new NotFoundUserException();
            }
        }
    }
}
