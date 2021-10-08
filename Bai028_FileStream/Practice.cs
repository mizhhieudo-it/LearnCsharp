using System;
using System.IO;
using System.Text;

namespace Pratice
{
 class Product{
     public int ID {get;set;}
     public double Price{set;get;}
     public string Name{get;set;}
     public void Save(Stream stream){
         // int -> 4byte
         var bytes_id = BitConverter.GetBytes(ID);
         stream.Write(bytes_id,0,4);
        //doule -> 8byte
         var bytes_price = BitConverter.GetBytes(Price);
         stream.Write(bytes_price,0,8);
         //chuoi name
         var bytes_name = Encoding.UTF8.GetBytes(Name);
         var bytes_length = BitConverter.GetBytes(bytes_name.Length); // để tí phục hồi 
         stream.Write(bytes_length,0,4);
         stream.Write(bytes_name,0,bytes_name.Length);
     }
     public void Restore(Stream stream){
         // phục hồi id 
         var bytes_id = new byte[4];
         stream.Read(bytes_id,0,4);
         ID = BitConverter.ToInt32(bytes_id,0);
         // phục hồi giá
         var bytes_price = new byte[8];
         stream.Read(bytes_price,0,8);
         Price = BitConverter.ToDouble(bytes_price,0);
         // chuỗi
         var bytes_leng = new byte[4] ; 
         stream.Read(bytes_leng,0,4);
         int leng = BitConverter.ToInt32(bytes_leng,0);
         var bytes_name = new byte[leng];
         stream.Read(bytes_name,0,leng);
         Name = Encoding.UTF8.GetString(bytes_name,0,leng);

     }
     
 }   
}