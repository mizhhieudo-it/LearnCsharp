using System;
using System.Data;
using System.Data.SqlClient;

namespace Bai038_ADO.NET2_SQLCOMMAND
{
    class Program
    {
        static void Main(string[] args)
        {
            var StringConnect = new SqlConnectionStringBuilder();
            StringConnect["Server"] = "MINHHIEUPC\\SQLEXPRESS";
            StringConnect["Database"] = "xtlab";
            StringConnect["Trusted_Connection"] = "True";
             using var connect = new SqlConnection(StringConnect.ToString());
             connect.Open();
             using var cmd = new SqlCommand();
             cmd.Connection = connect ;
             //cmd.CommandText = "select DanhmucID,TenDanhMuc,Mota FROM Danhmuc where DanhmucID >= @DanhMucID";
             // query example Scalar;
             //cmd.CommandText = "select count(1) from Sanpham";
             // query example NonQuery
             cmd.CommandText = "insert into Shippers (Hoten,Sodienthoai) values(@Ht,@sdt)";
            // cmd.CommandText = "select DanhmucID,TenDanhMuc,Mota FROM Danhmuc where DanhmucID >= @DanhMucID";
            // thực thi cho Procedute 
            cmd.CommandText = "GetProductInfo";
            cmd.CommandType = CommandType.StoredProcedure;
            var id1 = new SqlParameter("@id","1");
            cmd.Parameters.Add(id1);
            //  var ht = new SqlParameter("@Ht","");
            //  var sdt = new SqlParameter("@sdt",""); 
            //  ht.Value = "Nguyễn Văn A";
            //  sdt.Value = "0000";
            //  cmd.Parameters.Add(ht);
            //  cmd.Parameters.Add(sdt);
             //var danhmucid = new SqlParameter("@DanhMucID",5);
             // changed iddanhmuc equals danhmucid.value ;
            // danhmucid.Value = 1;
            // cmd.Parameters.Add(danhmucid);
             // thực thi câu lệnh cmd;
            //  cmd.ExecuteReader(); // dùng khi kết quả trả về nhiều dòng
            //  cmd.ExecuteScalar(); // chỉ lấy đc dùng dòng 1 cột 1
            // cmd.ExecuteNonQuery(); trả về tổng số dòng bị tác động bảo câu lệnh đó
            var returnValue = cmd.ExecuteNonQuery();
            Console.WriteLine(returnValue);
            // dùng khai nào => dùng khi câu lệnh sql chỉ trả về 1 sản phẩm : example 
            

             using var sqlreader = cmd.ExecuteReader();
             // sqlreader.HasRows = true => có dữ liệu
             if(sqlreader.HasRows)
             {
                while (sqlreader.Read())
                {
                     var id = sqlreader.GetInt32(0);// 0 <=> cột DanhMucID
                     var ten = sqlreader["TenDanhMuc"]; // <=> lấy dữ liệu cột tên dm 
                     var Mota = sqlreader["Mota"]; // <=> lấy dữ liệu cột tên mota 
                     Console.WriteLine($"{id}-{ten}-{Mota}");
                } // => còn true còn đọc
             }
             else{
                 Console.WriteLine("Không có dữ liệu trả về");
             }
            // ta có thể đổi dữ liệu ra đối tượng data table
            var data_table = new DataTable();
            // đổ dữ liệu vào table 
            data_table.Load(sqlreader);

             connect.Close();

        }
    }
}
