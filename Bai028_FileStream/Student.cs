using System;
using System.IO;
using System.Text;

namespace Students {
    class student{
        public int IDstudent {get;set;}
        public string Namestudent{get;set;}
        public double Pointstudent{get;set;}
        public void SaveWithFile(Stream stream){
            // int sử dụng 4 byte
            var bytes_ID = BitConverter.GetBytes(IDstudent);// Convert sang kiểu bytes
            stream.Write(bytes_ID,0,4);// dùng stream viết vào arr bytes_ID từ vị trí 0 , sử dụng 4 bytes để viết
            // double sử 8 byte 
            var bytes_PointStudent = BitConverter.GetBytes(Pointstudent);
            stream.Write(bytes_PointStudent,0,8);
            // 
            var bytes_name = Encoding.UTF8.GetBytes(Namestudent);// covert sang arr byte ;
            var bytes_leng = BitConverter.GetBytes(bytes_name.Length);
            stream.Write(bytes_leng,0,4);
            stream.Write(bytes_name,0,bytes_name.Length);
        }
        public void ReadFile(Stream stream){
            var bytes_id = new byte[4];
            stream.Read(bytes_id,0,4);
            IDstudent = BitConverter.ToInt32(bytes_id);
            var bytes_PointStudent = new byte[8];
            stream.Read(bytes_PointStudent,0,8);
            Pointstudent = BitConverter.ToDouble(bytes_PointStudent);
            // doc chuoi
            var bytes_leng = new byte[4];
            stream.Read(bytes_leng,0,4);
            int leng = BitConverter.ToInt32(bytes_leng,0); // chieu dai cua chuoi
            var bytes_name =new byte[leng];
            stream.Read(bytes_name,0,leng);
            Namestudent = Encoding.UTF8.GetString(bytes_name,0,leng);
            
        }
    }
}
