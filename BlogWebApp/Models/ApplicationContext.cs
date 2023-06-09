using ClassLibrary.Data.Article;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApp.Models
{
    public class ApplicationContext : IdentityDbContext<ArticleUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
    : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ArticleTag>().HasKey(i => new { i.articleID, i.tagID });
        }

    }
}
