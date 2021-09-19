using System;

namespace Bai010_OOP
{
    // quản lý quá trình thu hồi ( kế thừa từ giao diện IDispoable)
    class Program
    {
        static void Main(string[] args)
        {
            // phương thức khởi tạo : khởi tạo các giá trị 
            VuKhi sungluc ; // null 
            sungluc = new VuKhi() ;
           // VuKhi sungtruong = new VuKhi("Khởi tạo có tham sô");
           sungluc.name = "Sung Luc";
           sungluc.ThietlapSatthuong(5); 
           Console.WriteLine(sungluc.Satthuong);
           sungluc.noisanxuat = "My";  
           Console.WriteLine(sungluc.noisanxuat);
           sungluc.TanCong();

           VuKhi sungmay = new VuKhi("Sung May",15);
           sungmay.TanCong();
           // 
           sinhvien x = new sinhvien("Nguyễn Văn a");
           x = null ; // thu hồi sinh viên x nhưng lúc nào thu hồi thì ko biết
        //    trên donet framework thì sử dụng
           //GC.Collect(); 
           // hàm hủy khi ko đủ bộ nhớ thì nó tự động thu hồi 
           //vd:
            //  
           // sử dụng hàm huy dispo 
           using (sinhvien s = new sinhvien("Tensv")){
           }

        }
    }
}
