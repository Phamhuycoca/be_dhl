﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shop.Infrastructure.Context;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shop.Domain.Entities.CommentNews", b =>
                {
                    b.Property<int>("CommentNewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentNewsId"), 1L, 1);

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateComment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentNewsId");

                    b.HasIndex("NewsId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentNews", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.CommentPost", b =>
                {
                    b.Property<int>("CommentPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentPostId"), 1L, 1);

                    b.Property<string>("CommentContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateComment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CommentPostId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("CommentPost", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"), 1L, 1);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.ImageNews", b =>
                {
                    b.Property<int>("ImageNewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageNewsId"), 1L, 1);

                    b.Property<string>("ImageNewsUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewsContentId")
                        .HasColumnType("int");

                    b.Property<string>("UrlApi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageNewsId");

                    b.HasIndex("NewsContentId");

                    b.ToTable("ImageNews", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.ImagePost", b =>
                {
                    b.Property<int>("ImagePostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImagePostId"), 1L, 1);

                    b.Property<string>("ImagePostUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("UrlApi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImagePostId");

                    b.HasIndex("PostId");

                    b.ToTable("ImagePost", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.News", b =>
                {
                    b.Property<int>("NewsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsId"), 1L, 1);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDeTinTuc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("NewsId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("UserId");

                    b.ToTable("News", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.NewsContent", b =>
                {
                    b.Property<int>("NewsContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NewsContentId"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NewsId")
                        .HasColumnType("int");

                    b.HasKey("NewsContentId");

                    b.HasIndex("NewsId");

                    b.ToTable("NewsContent", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"), 1L, 1);

                    b.Property<int?>("NewsId")
                        .HasColumnType("int");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserIdComment")
                        .HasColumnType("int");

                    b.HasKey("NotificationId");

                    b.HasIndex("NewsId");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostId"), 1L, 1);

                    b.Property<bool?>("IsStatus")
                        .HasColumnType("bit");

                    b.Property<string>("PostContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostTittle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("Shop.Domain.Entities.CommentNews", b =>
                {
                    b.HasOne("Shop.Domain.Entities.News", "News")
                        .WithMany("CommentsNews")
                        .HasForeignKey("NewsId");

                    b.HasOne("Shop.Domain.Entities.User", "User")
                        .WithMany("CommentNews")
                        .HasForeignKey("UserId");

                    b.Navigation("News");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Domain.Entities.CommentPost", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Post", "Post")
                        .WithMany("CommentPosts")
                        .HasForeignKey("PostId");

                    b.HasOne("Shop.Domain.Entities.User", "User")
                        .WithMany("CommentPosts")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Domain.Entities.ImageNews", b =>
                {
                    b.HasOne("Shop.Domain.Entities.NewsContent", "NewsContent")
                        .WithMany("imagenews")
                        .HasForeignKey("NewsContentId")
                        .IsRequired();

                    b.Navigation("NewsContent");
                });

            modelBuilder.Entity("Shop.Domain.Entities.ImagePost", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Post", "Post")
                        .WithMany("ImagePosts")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Shop.Domain.Entities.News", b =>
                {
                    b.HasOne("Shop.Domain.Entities.Department", "Department")
                        .WithMany("News")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Domain.Entities.User", "User")
                        .WithMany("News")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Domain.Entities.NewsContent", b =>
                {
                    b.HasOne("Shop.Domain.Entities.News", "news")
                        .WithMany("newsContents")
                        .HasForeignKey("NewsId")
                        .IsRequired();

                    b.Navigation("news");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Notification", b =>
                {
                    b.HasOne("Shop.Domain.Entities.News", "News")
                        .WithMany("notifications")
                        .HasForeignKey("NewsId");

                    b.HasOne("Shop.Domain.Entities.Post", "post")
                        .WithMany("notifications")
                        .HasForeignKey("PostId");

                    b.HasOne("Shop.Domain.Entities.User", "User")
                        .WithMany("notifications")
                        .HasForeignKey("UserId");

                    b.Navigation("News");

                    b.Navigation("User");

                    b.Navigation("post");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Post", b =>
                {
                    b.HasOne("Shop.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Department", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("Shop.Domain.Entities.News", b =>
                {
                    b.Navigation("CommentsNews");

                    b.Navigation("newsContents");

                    b.Navigation("notifications");
                });

            modelBuilder.Entity("Shop.Domain.Entities.NewsContent", b =>
                {
                    b.Navigation("imagenews");
                });

            modelBuilder.Entity("Shop.Domain.Entities.Post", b =>
                {
                    b.Navigation("CommentPosts");

                    b.Navigation("ImagePosts");

                    b.Navigation("notifications");
                });

            modelBuilder.Entity("Shop.Domain.Entities.User", b =>
                {
                    b.Navigation("CommentNews");

                    b.Navigation("CommentPosts");

                    b.Navigation("News");

                    b.Navigation("Posts");

                    b.Navigation("notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
