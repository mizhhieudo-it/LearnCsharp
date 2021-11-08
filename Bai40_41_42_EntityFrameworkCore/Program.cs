using System;
using System.Linq;
using ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bai40_EntityFrameworkCore
{
    class Program
    {
        static void CreateDatabase()
        {
            using var Dbcontext = new ShopDbContext();
            string dbname = Dbcontext.Database.GetDbConnection().Database; // => trả về tên cơ sở dữ liệu
            Console.WriteLine(dbname);
            // tạo ra cơ sở dữ liệu
            var kq = Dbcontext.Database.EnsureCreated();// nếu không có db thì sẽ tạo ra , nếu trong db ko có các bảng do dbcontext biểu diễn thì nó sẽ tạo ra // return true 
            if (kq)
            {
                Console.WriteLine("Tạo Database thành công");
            }
            else
            {
                Console.WriteLine("Tạo Db thất bại");
            }
        }
        static void DropDatabase()
        {
            using var Dbcontext = new ShopDbContext();
            string dbname = Dbcontext.Database.GetDbConnection().Database; // => trả về tên cơ sở dữ liệu
            Console.WriteLine(dbname);
            // tạo ra cơ sở dữ liệu
            var kq = Dbcontext.Database.EnsureDeleted();// nếu không có db thì sẽ tạo ra , nếu trong db ko có các bảng do dbcontext biểu diễn thì nó sẽ tạo ra // return true 
            if (kq)
            {
                Console.WriteLine("Xóa Database thành công");
            }
            else
            {
                Console.WriteLine("Xóa Db thất bại");
            }
        }
        //     static void InsertProduct()
        //     {
        //         using var dbcontext = new ShopDbContext();
        //         /*
        //         -Model (Product)
        //         -Add.AddAsync 
        //         -SaveChange // => lưu khi có sự thay đổi
        //         */
        //         var p1 = new Product();
        //         p1.ProductName = "San Pham 1";
        //         p1.Provider = "Cong Ty 1";
        //         // hoặc có thể định nghĩa nhưu thế này 
        //         var p2 = new Product()
        //         {
        //             ProductName = "San Pham 2",
        //             Provider = "Cong Ty2"
        //         };
        //         // Chèn nhiều dòng dữ liệu
        //         var ListProduct = new object[]{
        //             new Product(){ProductName="san pham 3",Provider="cty 3"},
        //             new Product(){ProductName="san pham 4",Provider="cty 4"},
        //             new Product(){ProductName="san pham 5",Provider="cty 5"},
        //         };
        //         // Add Nhiều Dòng Dữ Liệu ta sử dụng AddRange
        //         //dbcontext.Add(p2);
        //         dbcontext.AddRange(ListProduct);
        //         int number_rows = dbcontext.SaveChanges(); // trả về số dòng bị tắc động 
        //         Console.WriteLine($"Đã  chèn {number_rows} dữ liệu");
        //     }
        //     static void ReadProduct()
        //     {
        //         using var dbcontext = new ShopDbContext();
        //         // lấy tất cả sản phẩm => linq API
        //         // dbcontext.products.ToList().ForEach
        //         // (
        //         //     x =>
        //         //     {
        //         //         x.PrintInfo();
        //         //     }
        //         //     );
        //         var kq = from product in dbcontext.products
        //                  where product.Provider.Contains("cty")
        //                  orderby product.ProductId descending
        //                  select product;
        //         kq.ToList().ForEach(x => x.PrintInfo());
        //     }
        //     static string RenameProduct(int id, string newName)
        //     {
        //         // db context sẽ giám sát các model luôn
        //         using var dbcontext = new ShopDbContext();
        //         var kq = (from product in dbcontext.products
        //                  where product.ProductId == id
        //                  select product).FirstOrDefault();
        //         if(kq != null){
        //             EntityEntry<Product> entry = dbcontext.Entry(kq); // đối tượng này được dùng để theo dỗi model 
        //             entry.State = EntityState.Detached ;  // đối tượng kq sẽ ko bị theo dõi nữa
        //             kq.ProductName = newName ;
        //             dbcontext.SaveChanges();
        //             return "Name Product Changed !";
        //         }else{
        //             return "Not found product in Database";
        //         }

        //     }
        //    static string RemoveProduct(int id)
        // {
        //     // db context sẽ giám sát các model luôn
        //     using var dbcontext = new ShopDbContext();
        //     var kq = (from product in dbcontext.products
        //              where product.ProductId == id
        //              select product).FirstOrDefault();
        //     if(kq != null){
        //         dbcontext.Remove(kq);
        //         dbcontext.SaveChanges();
        //         return "Name Product delete !";
        //     }else{
        //         return "Not found product in Database";
        //     }

        // }
        static void InsertDataCate()
        {
            ShopDbContext context = new ShopDbContext();
            Category c1 = new Category() { Name = " Điện Thoại", description = " Các Loại Điện Thoại" };
            Category c2 = new Category() { Name = " Đồ uống", description = " Các Loại Đồ Uống" };
            context.categories.Add(c1);
            context.categories.Add(c2);
            context.SaveChanges();
        }
        static void InsertDataProduct()
        {
            ShopDbContext context = new ShopDbContext();
            Product p1 = new Product() { ProductName = "Iphone 8", Prince = 1000, CateId = 1 };
            Product p2 = new Product() { ProductName = "SamSung", Prince = 800, CateId = 1 };
            Product p4 = new Product() { ProductName = "Rượu Vang", Prince = 800, CateId = 2 };
            Product p3 = new Product() { ProductName = "Cà Phê", Prince = 100, CateId = 2 };
            context.products.Add(p1);
            context.products.Add(p2);
            context.products.Add(p3);
            context.products.Add(p4);
            context.SaveChanges();
        }
        static void Main(string[] args)
        {
            // Entity -> Database -> table 
            // Datavase - SQL Sever : data 01 -> trong EF biểu diễn 1 cơ sở dữ liệu là data01->Dbcontext
            // -- product 
            //var Dbcontext = new ShopDbContext();
             DropDatabase();
             CreateDatabase();
            //InsertDataCate();
            //InsertDataProduct();
            //ReadProduct();
            //RemoveProduct(14);
            // ShopDbContext context = new ShopDbContext();
            //var category = (from p in Dbcontext.categories
                        //   where p.CategoryId == 1
                        //   select p).FirstOrDefault();
            // var e = context.Entry(product); // dám sát đối tượng 
            // e.Reference(p => p.Category).Load();//// lấy thông tin đối tượng truyền tải
            // product.PrintInfo();
            //============navigation collect
            //var nave = Dbcontext.Entry(category);
            //nave.Collection(c => c.Products).Load();
            // if(category.Products != null){
            //     Console.WriteLine($"So San Pham cua Product la:{category.Products.Count()}");
            //      category.Products.ForEach(p => p.PrintInfo());
            //  }
            //  else{ Console.WriteLine("catelogy == null");}
            // var sql = (from dm in context.categories 
            //             where dm.CategoryId == 1 
            //             select dm ).FirstOrDefault();
            // context.Remove(sql);
            // context.SaveChanges();
        }
    }
}
