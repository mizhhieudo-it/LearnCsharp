using System;
using System.Collections.Generic;
using System.Linq;

namespace Bai030_linq
{
    // Linq (Language Intergrated Query) : Ngon ngu truy van tich hop 
    // sql 
    // Nguon du lieu: IEnumrable , arr ,list , 
    // xml . sql 
    public class Product
    {
        public int ID { set; get; }
        public string Name { set; get; }         // tên
        public double Price { set; get; }        // giá
        public string[] Colors { set; get; }     // các màu
        public int Brand { set; get; }           // ID Nhãn hiệu, hãng
        public Product(int id, string name, double price, string[] colors, int brand)
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // Lấy chuỗi thông tin sản phẳm gồm ID, Name, Price
        override public string ToString()
           => $"{ID,3} {Name,12} {Price,5} {Brand,2} {string.Join(",", Colors)}";

    }
    public class Brand
    {
        public string Name { set; get; }
        public int ID { set; get; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var brands = new List<Brand>()
            {
                new Brand{ID = 1, Name = "Công ty AAA"},
                new Brand{ID = 2, Name = "Công ty BBB"},
                new Brand{ID = 4, Name = "Công ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1, "Bàn trà",    400, new string[] {"Xám", "Xanh"},         2),
                new Product(2, "Tranh treo", 400, new string[] {"Vàng", "Xanh"},        1),
                new Product(3, "Đèn trùm",   500, new string[] {"Trắng"},               3),
                new Product(4, "Bàn học",    200, new string[] {"Trắng", "Xanh"},       1),
                new Product(5, "Túi da",     300, new string[] {"Đỏ", "Đen", "Vàng"},   2),
                new Product(6, "Giường ngủ", 500, new string[] {"Trắng"},               2),
                new Product(7, "Tủ áo",      600, new string[] {"Trắng"},               3),
            };
            // var GetPrince400 = from sp in products
            //                    where sp.Price == 400
            //                    select sp;
            // foreach (var item in GetPrince400)
            // {
            //     Console.WriteLine(item);
            // }
            // select retrun 1 obj
            // ====================== API LINQ ====================================
            var kq = products.Select(
                (p) =>
                {
                    return new
                    {
                        ten = p.Name,
                        Gia = p.Price
                    };
                }
            );
            foreach (var item in kq)
            {
                Console.WriteLine(item);
            }
            // where return true false => true thi dc lay ra con flase thi ko 

            var kqcontain = products.Where(
                (p) =>
                {
                    return p.Name.Contains("tr");
                }
            );
            foreach (var item in kqcontain)
            {
                Console.WriteLine(item);
            }
            // selectMany : select đến hết phần tử trong mảng
            var kqselectMany = products.SelectMany(
                (p) =>
                {
                    return p.Colors;
                }
            );
            foreach (var item in kqselectMany)
            {
                Console.WriteLine(item);
            }
            // Min , Max , Sum . Average(giá trị trung bình)
            var kqsum = products.Where(
                p =>
                {
                    return (p.Price % 2 == 0);
                }
            );
            foreach (var item in kqsum)
            {
                Console.WriteLine(item);
            }
            // join : kết hợp các nguồn dữ liệu 
            /*
            tên bảng1.join(tên bảng2,tên đại hiện => nối bằng một bằng trường gì , nối bằng 2 bằng trường gì , kết quả lấy ra đưa vào 1 delegate )
            */
            var kqjon = products.Join(brands, p => p.Brand, b => b.ID, (p, b) =>
              {
                  return new
                  {
                      Ten = p.Name,
                      ThuongHieu = b.Name
                  };

              });
            foreach (var item in kqjon)
            {
                Console.WriteLine(item);
            }
            // Group Join : Nhóm lại như ban đầu
            var kqGROUPJOIN = brands.GroupJoin(products, b => b.ID, p => p.ID, (bra, pro) =>
            {
                return new
                {
                    thuonghieu = bra.Name,
                    cacsp = pro
                };
            });
            foreach (var item in kqGROUPJOIN)
            {
                Console.WriteLine(item.thuonghieu);
                foreach (var item1 in item.cacsp)
                {
                    Console.WriteLine(item1);

                }
            }
            //Take : lấy số lượng sản phẩm 
            products.Take(4).ToList().ForEach(p => Console.WriteLine(p));
            // Skip () : Bỏ qua các phần tử tính tử đầu 
            products.Skip(2).ToList().ForEach(p => Console.WriteLine(p));
            //OrderBy(tang dang) . OrderByDescending(giam dan )
            products.OrderBy(p => p.Price).ToList().ForEach(p => Console.WriteLine(p));
            //Reverse : đảo ngược bảng
            products.ToArray().Reverse().ToList().ForEach(p => Console.WriteLine(p));
            // groupBy: nhóm theo giá 
            var kqGr = products.GroupBy(p => p.Price);
            foreach (var item1 in kqGr)
            {
                Console.WriteLine(item1.Key);
                foreach (var item in item1)
                {
                    Console.WriteLine(item);
                }

            }
            //Distin : Loại bỏ cùng giá trí 
            products.SelectMany(p => p.Colors).Distinct().ToList().ForEach(products=>Console.WriteLine(products));
            //Single : chỉ tìm 1 phần tử => nếu nhiều hơn sẽ phát sinh lỗi
            var pSingle = products.Single(p => p.Price == 600); 
            Console.WriteLine(pSingle);
            // SingleOrDefault 
            products.SingleOrDefault(products=>products.Price == 11) ; // ko tìm thấy return null nhưng tìm kiểu hơn vẫn phát sinh lỗi
            // Any : return true - false : tìm thấy 1 vào thoải mãn theo điều kiện => true / false 
            var pAny = products.Any(Product=>Product.Price == 700);
            Console.WriteLine(pAny);
            // ALL : như Any nhưng thỏa mãn tất cả 
            var pCount = products.Count(p => p.Price >= 300);
            Console.WriteLine(pCount);
            Console.WriteLine("==================thuchanh=======================");
            // In tra ten san pham , ten thuong hieu co gia tu khoang (300-400)
            // in giam dan 
            var kqbt = products.Where(p => p.Price <= 400 && p.Price >= 300)
            .OrderByDescending(p => p.Price)
            .Join(brands,pro => pro.Brand , bra => bra.ID,(pro,bra)=>{
                return new {
                    TensP = pro.Name,
                    TenTH = bra.Name,
                    PrinceSP = pro.Price
                };
            }).ToList();
            foreach (var item in kqbt)
            {
                Console.WriteLine(item);
            }
            // ====================== Truy Vấn Với Lin Q====================
            /*
            1) Xác định nguồn dữ liệu : form item in  IE
            ... where, orderby ....
            2) chỉ thị cho biết : slecet , groupby  

            */
            // 1) lấy tên sp  
            var LinQ_NameProduct = from item in products  
                                select item.Name ; 
            LinQ_NameProduct.ToList().ForEach(x => Console.WriteLine(x));
            // 1) Lấy thế và giá 
            var LinQ_Name_PriceProduct = from item in products  
                                select $"{item.Name}:{item.Price}" ; // trả về chuỗi 
            LinQ_Name_PriceProduct.ToList().ForEach(x => Console.WriteLine(x));
            // 2 ) lấy tên và giá khởi tạo ra 1 anonymous 
            var LinQ_Name_PriceProduct1 = from item in products
                                            select new {
                                                Ten = item.Name,
                                                Gia = item.Price
                                            };
            // 3) lấy giá <400
            var LinQ_Name_PriceProduct400 = from item in products
                                            where item.Price <= 400 
                                            select new {
                                                Ten = item.Name,
                                                Gia = item.Price
                                            };
            // Gia < 500 , màu xanh 
            Console.WriteLine("500-Xanh");
            var linq500xanh = from item in products
                                from color in item.Colors
                                where item.Price <= 500 && color == "xanh"
                                orderby item.Price // lớn đến nhỏ <==> nhỏ đến lớn
                                select new {
                                                Ten = item.Name,
                                                Gia = item.Price
                                            };
            linq500xanh.ToList().ForEach(x => Console.WriteLine(x));
            // Group by 
            /// nhom san phẩm theo giá
            var qr = from p in products
                    group p by p.Price into gr  
                    orderby gr.Key
                    select gr;
            qr.ToList().ForEach(GR =>{
                Console.WriteLine(GR.Key);
                GR.ToList().ForEach(p => Console.WriteLine(p));
            });
            // sử dụng biến trong linq : let 
            var qr1 = from p in products
                    group p by p.Price into gr  
                    orderby gr.Key
                    let sl = gr.Count()
                    select gr;
            qr.ToList().ForEach(GR =>{
                Console.WriteLine(GR.Key);
                GR.ToList().ForEach(p => Console.WriteLine(p));
            });
            // joinnnnnnnnnnnnnnnnn
            var linq_join = from pro in products
                            join b in brands on pro.Price equals b.ID into t
                            from b in t.DefaultIfEmpty()
                            select new {
                                ten = pro.Name , 
                                th = (b !=null) ? b.Name : "No brand"
                            };
            






        }
    }
}
