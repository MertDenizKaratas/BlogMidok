using Application.Repositories;
using ETicaretAPI.Application.Abstractions.Services.Authentications;
using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence;
using ETicaretAPI.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories.PostImage;
using Persistence.Repositories.PostImage;
using Persistence.Repositories;
using Application.Repositories.CategoryImage;
using Persistence.Repositories.CategoryImage;
using Application.Abstraction.Services;
using Persistence.Services;
using Application.Repositories.BlogPostCategory;
using Persistence.Repositories.BlogPostCategory;
using Application.Repositories.PostLike;
using Persistence.Repositories.PostLike;

namespace Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
               services.AddDbContext<BlogMidokDBContext>(options => options.UseNpgsql(Configuration.ConnectionString));
               services.AddIdentity<AppUser, AppRole>(options =>
                    {
                        options.Password.RequiredLength = 3;
                        options.Password.RequireNonAlphanumeric = false;
                        options.Password.RequireDigit = false;
                        options.Password.RequireLowercase = false;
                        options.Password.RequireUppercase = false;
                    }).AddEntityFrameworkStores<BlogMidokDBContext>();


           services.AddScoped<IPostReadRepository, PostReadRepository>();
           services.AddScoped<IPostWriteRepository, PostWriteRepository>();
            services.AddScoped<IPostImageReadRepository, PostImageReadRepository>();
            services.AddScoped<IPostImageWriteRepository, PostImageWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryImageReadRepository, CategoryImageReadRepository>();
            services.AddScoped<ICategoryImageWriteRepository, CategoryImageWriteRepository>();
            services.AddScoped<IBlogPostCategoryReadRepository, BlogPostCategoryReadRepository>();
            services.AddScoped<IBlogPostCategoryWriteRepository, BlogPostCategoryWriteRepository>();
            services.AddScoped<IPostLikeReadRepository, PostLikeReadRepository>();
            services.AddScoped<IPostLikeWriteRepository, PostLikeWriteRepository>();



            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IExternalAuthentication, AuthService>();
            services.AddScoped<IInternalAuthentication, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
