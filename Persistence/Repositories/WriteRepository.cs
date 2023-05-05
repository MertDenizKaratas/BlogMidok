
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using Persistence.Context;
using Domain.Entities;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        readonly private BlogMidokDBContext _context;
        public WriteRepository(BlogMidokDBContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }
        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model);
        }
        public bool Update(T model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<bool> AddRangeAsyncDifferentForBlogPost(List<BlogPostImageFıle> datas, int id)
        {
            var post = await _context.Posts.Include(p=>p.BlogImages).ThenInclude(p=>p.BlogPostImageFile).
               FirstOrDefaultAsync(p=>p.Id == id);

            var postimage = new BlogImages { BlogPost = post, BlogPostImageFile = datas[0] };

            post.BlogImages.Add(postimage);

            await _context.ImageFilesPost.AddRangeAsync(datas);
            return true;
        }
        public async Task<bool> AddRangeAsyncDifferentForCategory(List<CategoryImageFile> datas, int id)
        {
            var category = await _context.Categories.Include(p => p.CategoryImages).ThenInclude(p => p.CategoryImageFiles).
               FirstOrDefaultAsync(p => p.Id == id);

            var postimage = new CategoryImages { Categories = category, CategoryImageFiles = datas[0] };

            category.CategoryImages.Add(postimage);

            await _context.ImageFilesCategory.AddRangeAsync(datas);
            return true;
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

    }
}
