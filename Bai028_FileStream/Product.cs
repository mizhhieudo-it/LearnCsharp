using System;
using System.IO;
using System.Text;

namespace Product
{
   class Products
    {
        public int ID { get; set; }
        public double Price { set; get; }
        public string Name { get; set; }
        public void Save(Stream stream)
        {
            // int -> 4byte
            var bytes_id = BitConverter.GetBytes(ID);
            stream.Write(bytes_id, 0, 4);
            //doule -> 8byte
            var bytes_price = BitConverter.GetBytes(Price);
            stream.Write(bytes_price, 0, 8);
            //chuoi name
            var bytes_name = Encoding.UTF8.GetBytes(Name);
            var bytes_length = BitConverter.GetBytes(bytes_name.Length); // để tí phục hồi 
            stream.Write(bytes_length, 0, 4);
            stream.Write(bytes_name, 0, bytes_name.Length);
        }
    }
}