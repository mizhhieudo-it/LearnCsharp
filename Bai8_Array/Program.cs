using System;

namespace Bai8_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            /*

            Kieu_du_lieu[] ten_mang = khởi tạo mảng 
            khởi tạo mảng = new kiểu dữ liệu [số phần tử]
            */
            // khai báo mảng 
            string[] ds ;
            ds= new string [3];
            ds[0] = "Nguyen Van A"; 
            ds[1] = "Nguyen Van B";
            ds[2] = "Nguyen Văn C" ; 
            int[] songuyen = new int[3]{1,2,3} ;
            // khở tạo mảng vào thêm value cho nó luôn 
            Console.WriteLine(ds.Rank);
            for(int i = 0 ;i < 3 ;i++){
                Console.WriteLine(ds[i]);
            }
            // truy cập vào bằng Đối tượng Array vd Array.Sort(ds) ;
            // mảng 2 chiều 
            double[,] number; 
            number = new double[2,3]{{1,2,3},{4,5,6}};
            // duyệt qua mảng 2 chiều 
            int hang = 2 ,cot =3 ;
            for(int i= 0 ; i< hang ;i++){
                for(int j=0;j<cot ;j++){
                    Console.Write(number[i,j]);
                }
            }
        }
    }
}
