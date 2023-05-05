using Application.Repositories.PostImage;
using Domain.Entities;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly BlogMidokDBContext _context;

        public ReadRepository(BlogMidokDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));
        {

            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
           
        }
        public async Task<BlogPost> GetByIdAsyncDifferent(int id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));
        {

            return await _context.Posts
                .Where(p => p.Id == id)
                .Include(p => p.BlogImages)
                .ThenInclude(p => p.BlogPostImageFile)
                .Include(p=>p.User)
                .FirstOrDefaultAsync();
            
        }
        public async Task<List<BlogPost>> Trying(string id, bool tracking = true)
        {
            
            var posts = await _context.Posts.Include(p => p.Likes).Include(p=>p.BlogImages).ThenInclude(p=>p.BlogPostImageFile).ToListAsync();
            try
            {
                foreach (var post in posts)
                {
                    post.IsLikedByCurrentUser = post.Likes.Any(like => like.UserId == id);
                }
                return posts;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        

           
        }



    }
}
