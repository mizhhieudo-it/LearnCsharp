using System;

namespace Bai11_String_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            string loichao; // mặc định null 
            loichao =  "Xin Chào" ;
            string name ="NguyenVanA"; 
            string thongbao = loichao +" "+name ; 
            thongbao += "!";
            // chèn kí tự đặt biệt \"
            thongbao +="hoc ve \"chuoi string\"";
            // dữ nguyên format 
            thongbao = @"du     nguyen gia tri cua
            
            chuoi";
            thongbao = $"xin chao{name} , 2021";
            //de khoang chong
            thongbao = $"xin chao{name,100},2021";
            // có thể kết hợp dấu $ và @ vd $@""
            // thao tac doc chuoi 
            int dodai = thongbao.Length ; // tra ve do dai cua chuoi - tuong tu nhu mang thi chuoi cung co vi tri  index
            // cat bo khoang trang trong chuoi o dau và cuoi. vd. loai  bỏ nguyên ở đầu dùng trimstart , cuối là trimend 
            string vd = "       cat chuoi           "; 
            // in hoa : upper - in thường lower 
            //replace ("chuỗi cần thay thế", chuỗi thay thế)
            //insert("vị trí chèn(index),"giá trị chèn ""); 
            //substring("vị trí index","số kí tự cần lấy"): trả về 1 chuỗi con 
            //xóa chuỗi con ở trong chuỗi ban đầu 
            //remove("loai bo ki tu tu vi tri index ( sau vi tri index","so ki tu xoa")
            // split("kí tự chia") : chia chuỗi con thành những chuỗi nhỏ
            // gộp chuỗi con : string.join("nối bằng",tên mảng );
            //StringBuilder:
            // phương thức như append : thêm vào - replace : thây thế 
            // waring : string Builer làm việc ko tốn bộ nhớ => hiệu năng ko tốt ( stringbuiler chỉ làm 1 trên một bộ nhớ duy nhất )


            Console.WriteLine(vd.Trim());

        }
    }
}
