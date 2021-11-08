using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ef
{
    // DBCOntext : tượng trưng cho 1 database 
    public class ShopDbContext : DbContext
    {
        ILoggerFactory loggerFactory = LoggerFactory.Create(
            builder =>{
                builder.AddFilter(DbLoggerCategory.Query.Name , LogLevel.Information);
                builder.AddConsole();
            }
            
        );
        //Dbset <=> 1 bảng cơ sở dữ liệu
        public DbSet<Product> products {get;set;}
        public DbSet<Category> categories {get;set;}
        public DbSet<CategoryDetail> categoryDetails {get;set;}
        //config connect string
        private const string connect ="Server=MINHHIEUPC\\SQLEXPRESS;Database=ShopData;Trusted_Connection=True;";
        // Phải override ;ại cái OnConfifuring để cấu hình kết nối các thứ
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(connect); // để cho biết ta làm việc với sqlsever tương tự mysql
           //optionsBuilder.UseLazyLoadingProxies(); // không cần join mà nó sẽ lấy thông tin thông qua entry và referent
           Console.WriteLine("On Configguring....");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           Console.WriteLine(" OnModelCreating....");
           // lấy ra được cái Model các bảng
           // vd thiết lập lấy thông tin thông qua Fulent Api 
           //var entity = modelBuilder.Entity(typeof(Product));
           // sử dụng entity => gọi fluent api cho product 
            // or 
            //var entity = ModelBuilder.Entity<Product>();
            modelBuilder.Entity<Product>(ef => {
                // các fluent thông dụng 
                // 1 . ánh xạ của bảng (table mapping)
                ef.ToTable("SanPham");
                // 2. thiết lập khóa chính
                ef.HasKey(p => p.ProductId); // <=> [Key] ProductID  
                // Đánh chỉ mục Index (nhầm tăng tốc độ tìm kiếm)
                ef.HasIndex(p => p.Prince).HasDatabaseName("index-sanpham-price");
                //Mối liên hệ 
                ef.HasOne(p =>p.Category)
                .WithMany() // không có property ~ sản phẩm 
                .HasForeignKey("CateId") // đặt tên trường làm fk là Cate ID
                .OnDelete(DeleteBehavior.Cascade) // xóa phầm một thì phần nhiều xóa 
                //.OnDelete(DeleteBehavior.NoAction); // xóa phầm một thì phần nhiều ko ảnh hưởng
                .HasConstraintName("KhoaNgoai_BangSP_BangCate");
                ef.HasOne(p => p.Category2)
                .WithMany(c => c.Products)
                .HasForeignKey("CateId2")
                .OnDelete(DeleteBehavior.NoAction)
                ;
                ef.Property(p => p.ProductName)
                .HasColumnName("Title")// thiết lập tên cột 
                .HasColumnType("nvarchar")
                .HasMaxLength(60) // length
                .IsRequired(true) // not null
                .HasDefaultValue("Ten Sp Mac Dinh")
                ;

            });
            // quan hệ 1 - 1 
            modelBuilder.Entity<CategoryDetail>(ef=>{
                ef.HasOne(d => d.category)
                
                .WithOne(c => c.categoryDetail)
                .HasForeignKey<CategoryDetail>(c => c.CategoryDetailId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            
            // call Fluent Api 
        }

    }
}