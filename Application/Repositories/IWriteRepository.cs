using Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        Task<bool> AddRangeAsyncDifferentForBlogPost(List<BlogPostImageFıle> datas, int id);
        Task<bool> AddRangeAsyncDifferentForCategory(List<CategoryImageFile> datas, int id);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(int id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
}
