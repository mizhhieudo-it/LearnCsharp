using System;

namespace bai12_Struct
{
    public class Productclass{
            //du lieu
            public string name ; 
            public double price ;
            // phuong thuc 
            public string info{
                get {
                    return $"{name} - {price}";
                }
            }
            public string GetInfo(){
                return $"ten san phan{name},gia:{price}" ; 
            }
            // constructor
            public Productclass(string _name,double _price){
                name = _name ; 
                price = _price;
            }
        }
    class Program
    {
        //struct : kiểu dữ liệu mà ta tự định nghĩa 
        public struct Product{
            //du lieu
            public string name ; 
            public double price ;
            // phuong thuc 
            public string info{
                get {
                    return $"{name} - {price}";
                }
            }
            public string GetInfo(){
                return $"ten san phan{name},gia:{price}" ; 
            }
            // constructor
            public Product(string _name,double _price){
                name = _name ; 
                price = _price;
            }
        }
        //======================Emun===========================
            // giải quyết cấu trúc dữ liệu kiệt kê :
            // khai báo : 
            enum HocLuc
            {
                Kem = 1 , // 0
                TrungBinh = 2, //1 
                Kha =3 , // 2
                Gioi = 4 //3
                // cho phép ép kiểu số <=> enum 
                // các kiểu liệt kê 
                // FileAccess 
                // FileAttribute 
                // File Mode 
                // Date Format
                // DateTimeKind
            }
        static void Main(string[] args)
        {
            Product sanpham1 ; 
            sanpham1.name =  "Iphone";
            sanpham1.price = 1000 ; 
            Product sanpham2 = new Product("Nokia",800);
            sanpham2 = sanpham1 ;
            Console.WriteLine(sanpham1.info);
            Console.WriteLine(sanpham2.info);
            sanpham2.name = "iphone 10";
            Console.WriteLine(sanpham1.info);
            Console.WriteLine(sanpham2.info);
            // => sau khi gán lại tên thì ta thấy sản phẩm 2 đã bị thay đổi 
            // struct là kiểu tham trị vd 
            // nếu là lớp thì nó sẽ tham chiếu cùng 1 đối tượng nghĩa là
            Productclass sp1 = new Productclass("lumia1",2000);
            Productclass sp2 = new Productclass("lumia2",1000);
            Console.WriteLine(sp1.info);
            Console.WriteLine(sp2.info);
            sp1 = sp2 ; 
            Console.WriteLine(sp1.info);
            Console.WriteLine(sp2.info);
            sp1.name = "lumia3";
            Console.WriteLine(sp1.info);
            Console.WriteLine(sp2.info);
            // => cả sản phẩm 1 và 2 sẽ cùng bị thay đổi vị nó đang tham chiếu tới cùng 1 đối tượng
            

            
            
        }
    }
}
