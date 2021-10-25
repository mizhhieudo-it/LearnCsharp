using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace BAI037_ADO_NET_SQL_SEVER_MYSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // khai báo chuỗi kết nối
            string sqlStringConnection = "Data Source = localhost,1433;Database=xtlab;User ID =sa;Password = Password123;"; 
            // sử dụng 1 thư viện bên ngoài support việc tạo ra 1 đối tượng
            var stringBuiller = new SqlConnectionStringBuilder();
            stringBuiller["Server"] = "localhost,1433";
            stringBuiller["Database"] = "xtlab";
            stringBuiller["User ID"] = "sa";
            stringBuiller["Password"] = "Password123";
            // tạo xong thì chuyển về tostring
            // để mở cổng dữ liệu liệu
            using var Connect = new SqlConnection(stringBuiller.ToString()); // tạo ra 1 đối tượng sqlconnction để đọc chuỗi kết nối ( truyền vào chuỗi kết nối)
            // show trạng thái hiện tại 
           // var state = Connect.State;
            Console.WriteLine(Connect.State);
            // để mở cổng sử dụng 
            Connect.Open();
            Console.WriteLine(Connect.State);
            //truy vấn 
            // tạo ra 1 đối tượng đẻ truy vấn 
            using DbCommand commad = new SqlCommand();
            // khai báo chuỗi kết nối
            commad.Connection = Connect;
            // viết lệnh sql để kết nối
            commad.CommandText = "Select top(5) * FROM Sanpham";
            // thực hiện truy vấn và đọc dữ liệu 
            var datareader = commad.ExecuteReader();
            // vòng lặp sẽ lặp đến khi nào bằng trạng thái đổi từ true thành false thì thui
            while(datareader.Read()){
                Console.WriteLine($"{datareader["TenSanpham"]} - giá {datareader["Gia"]}");
            }
            // sủ dụng xong thì phải đóng lại
            Connect.Close();
        }
    }
}
