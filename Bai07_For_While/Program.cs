using System;

namespace Bai07_For_While
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            for(Khởi tạo ; điều kiện ; cập nhật){
                khởi tạo1 : chỉ thị lệnh ( khởi tạo bộ đếm số lần) - cách chỉ thị cách nhau bởi dấu phẩy
                điều kiện : biểu thức logic 
                cập nhật2 : chỉ thị lệnh  (thay đổi bộ đếm)
                step1 : khởi tạo 1 :
                step2: điều kiện => true => tiếp tục 
                step3: chỉ thị lệnh 2 :   
                // khối lệnh
            }
            */
            // for(int i= 1;i<=10;i++){
            //     Console.WriteLine("Hello C sharp");
            // }
            // for
            int i;
            // for( i =1 , Console.WriteLine("Start") ; i<10;i++, Console.WriteLine("end")){
            //     Console.WriteLine("Oke");
            // }
            // while 
            /*
            while( điều kiện đúng đề tiếp tục vòng lặp ){
                .. khối lệnh ; 
                biểu thức logic
            }

            */
            // i = 1;
            // while(i <= 3){
            //     Console.WriteLine("oke");
            //     i++;
            // }
            // # khác với while for thì sẽ làm trước mới kiểm tra điều kiện
            int j = 1;
            do{
                Console.WriteLine("flase");
                j++;
            }while(j <= 3);
            //nếu trong vòng lặp gặp break thì dừng ngay ; continue : bỏ quâ 
        // int a = 0 ; 
        // while(a <10){
        //     Console.WriteLine(a);
        //     a++ ; 
        //     break;

        // }
        }
    }
}
