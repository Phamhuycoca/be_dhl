using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Context
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsContent> newsContents { get; set; }
        public DbSet<ImageNews> ImageNews { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ImagePost> ImagePosts { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(e =>
            {
                e.ToTable("Department");
                e.HasKey(e => e.DepartmentId);
                e.Property(e => e.DepartmentName).IsRequired();
            });
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(x => x.UserId);
            });
            modelBuilder.Entity<News>(e =>
            {
                e.ToTable("News");
                e.HasKey(e => e.NewsId);
                e.HasOne(e => e.User).WithMany(e => e.News).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<NewsContent>(e =>
            {
                e.ToTable("NewsContent");
                e.HasKey(e => e.NewsContentId);
                e.HasOne(e => e.news).WithMany(e => e.newsContents).HasForeignKey(e => e.NewsId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<ImageNews>(e =>
            {
                e.ToTable("ImageNews");
                e.HasKey(e => e.ImageNewsId);
                e.HasOne(e => e.NewsContent).WithMany(e => e.imagenews).HasForeignKey(e => e.NewsContentId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Post>(e =>
            {
                e.ToTable("Post");
                e.HasKey(e => e.PostId);
                e.HasOne(e => e.User).WithMany(e => e.Posts).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<ImagePost>(e =>
            {
                e.ToTable("ImagePost");
                e.HasOne(e => e.Post).WithMany(e => e.ImagePosts).HasForeignKey(e => e.PostId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            modelBuilder.Entity<Notification>(e =>
            {
                e.ToTable("Notification");
                e.HasKey(e => e.NotificationId);
                e.HasOne(e => e.User).WithMany(e => e.notifications).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.News).WithMany(e => e.notifications).HasForeignKey(e => e.NewsId).OnDelete(DeleteBehavior.ClientSetNull);
                e.HasOne(e => e.post).WithMany(e => e.notifications).HasForeignKey(e => e.PostId).OnDelete(DeleteBehavior.ClientSetNull);
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
