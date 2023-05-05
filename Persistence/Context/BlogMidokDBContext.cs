using Domain.Entities;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class BlogMidokDBContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public BlogMidokDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<BlogPostImageFıle> ImageFilesPost { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<CategoryImageFile> ImageFilesCategory { get; set; }
        public DbSet<ETicaretAPI.Domain.Entities.File> Files { get; set; }
        public DbSet<BlogImages> BlogImages { get; set; }
        public DbSet<BlogPostCategories> BlogPostCategories { get; set; }
        public DbSet<CategoryImages> CategoriesImages { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogImages>()
                .HasKey(pi => new { pi.BlogPostId, pi.BlogPostImageId });

            modelBuilder.Entity<BlogImages>()
                .HasOne(pi => pi.BlogPost)
                .WithMany(p => p.BlogImages)
                .HasForeignKey(pi => pi.BlogPostId);

            modelBuilder.Entity<BlogImages>()
                .HasOne(pi => pi.BlogPostImageFile)
                .WithMany(i => i.BlogImages)
                .HasForeignKey(pi => pi.BlogPostImageId);
            ///////////////////////////////////////////////////////////

            modelBuilder.Entity<BlogPostCategories>()
                .HasKey(pi => new { pi.BlogPostId, pi.CategoryId });

            modelBuilder.Entity<BlogPostCategories>()
                .HasOne(pi => pi.BlogPost)
                .WithMany(p => p.BlogPostCategories)
                .HasForeignKey(pi => pi.BlogPostId);

            modelBuilder.Entity<BlogPostCategories>()
                .HasOne(pi => pi.Category)
                .WithMany(i => i.BlogPostCategories)
                .HasForeignKey(pi => pi.CategoryId);

            //////////////////////////////////////////////////////////////////
            ///
            modelBuilder.Entity<CategoryImages>()
               .HasKey(pi => new { pi.CategoryImageId, pi.CategoryId });

            modelBuilder.Entity<CategoryImages>()
                .HasOne(pi => pi.Categories)
                .WithMany(p => p.CategoryImages)
                .HasForeignKey(pi => pi.CategoryId);

            modelBuilder.Entity<CategoryImages>()
                .HasOne(pi => pi.CategoryImageFiles)
                .WithMany(i => i.CategoryImages)
                .HasForeignKey(pi => pi.CategoryImageId);

            ///////////////////////////////////////////////////////////////
            ///
            modelBuilder.Entity<PostLike>()
             .HasKey(pl => new { pl.PostId, pl.UserId });

            modelBuilder.Entity<PostLike>()
                .HasOne(pl => pl.Post)
                .WithMany(p => p.Likes)
                .HasForeignKey(pl => pl.PostId);

            modelBuilder.Entity<PostLike>()
                .HasOne(pl => pl.User)
                .WithMany(u => u.LikedPosts)
                .HasForeignKey(pl => pl.UserId);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {


            var datas = ChangeTracker
                 .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
