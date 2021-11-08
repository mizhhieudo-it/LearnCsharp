using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Bai043_Migration_Scaffold_EF{
    public class WebContext : DbContext
    {
        public DbSet<Article> articles {set; get;}        // bảng article
        public DbSet<Tag> tags {set; get;}                // bảng tag
        public DbSet<ArticleTag> articleTags {get;set;}

        // chuỗi kết nối với tên db sẽ làm  việc đặt là webdb
        public const string ConnectStrring  =  "Server=MINHHIEUPC\\SQLEXPRESS;Database=webdb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseSqlServer(ConnectStrring);
             optionsBuilder.UseLoggerFactory(GetLoggerFactory());       // bật logger
        }
        
        private ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder =>
                    builder.AddConsole()
                           .AddFilter(DbLoggerCategory.Database.Command.Name,
                                    LogLevel.Information));
            return serviceCollection.BuildServiceProvider()
                    .GetService<ILoggerFactory>();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArticleTag>(e => {
                e.HasIndex(at => new {
                    at.ActicleId,
                    at.TagId
                }).IsUnique(); // nó sẽ là duy nhất
            });
        }

    }

}