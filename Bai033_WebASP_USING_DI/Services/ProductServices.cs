using System;
using System.Collections.Generic;
using System.Linq;
public class Product{
    public string ID {set;get;}
    public string Name{get;set;}
    public double Price {get;set;}
}
public class ProductService{
    List<Product> product = new List<Product>();
    public ProductService(){
        Console.WriteLine("Start ProductService");
        product.AddRange(new Product[]{
            new Product(){ID = "Product1" , Name ="IPHONE7",Price=1000,},
            new Product(){ID = "Product2" , Name ="IPHONE8",Price=2000,},
            new Product(){ID = "Product3" , Name ="IPHONE9",Price=3000,},
            new Product(){ID = "Product4" , Name ="IPHONE11",Price=4000,},
        });
    }
    public Product FindProduct(string id){
        var qr = from x in product 
                where x.ID == id 
                select x ;
            return qr.FirstOrDefault();
    }
    
}