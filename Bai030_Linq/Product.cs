using System ; 
namespace Products {
    public class Product{
        public int ID {set; get;}
        public string Name {set; get;}         // tên
        public double Price {set; get;}        // giá
        public string[] Colors {set; get;}     // cá màu
        public int Brand {set; get;}           // ID brand
        public Product(int id, string name, double price, string[] colors, int brand) 
        {
            ID = id; Name = name; Price = price; Colors = colors; Brand = brand;
        }
        // get info  ID, Name, Price
        override public string ToString() 
           => $"{ID,3} {Name, 12} {Price, 5} {Brand, 2} {string.Join(",", Colors)}";

    }

};