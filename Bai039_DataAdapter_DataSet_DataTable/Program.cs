using System;
using System.Data;
using System.Data.SqlClient;

namespace Bai039_DataAdapter_DataSet_DataTable
{
    class Program
    {
        public static void ShowTable(DataTable x)
        {
            foreach (DataColumn col in x.Columns)
            {
                Console.Write($"{col.ColumnName,20}") ;
            }
            var Number_Col = x.Columns.Count; 
            foreach (DataRow item in x.Rows)
            {
                 Console.WriteLine("\n");
               for (int i = 0; i < Number_Col; i++)
               {
                    Console.Write($"{item[i],23}");
               }
              

            }

        }
        static void Main(string[] args)
        {
            var StringConnect = new SqlConnectionStringBuilder();
            StringConnect["Server"] = "MINHHIEUPC\\SQLEXPRESS";
            StringConnect["Database"] = "xtlab";
            StringConnect["Trusted_Connection"] = "True";
             using var connect = new SqlConnection(StringConnect.ToString());
             connect.Open();
             var Adapter = new SqlDataAdapter(); // ánh xạ vào dataset 
             Adapter.TableMappings.Add("Table","NhanVien");
             // dataset là một đối tượng để chứa bảng trong cơ sở dữ liệu
             var dataSet = new DataSet();
             //SelectCommand 
             Adapter.SelectCommand = new SqlCommand("select NhanviennID,Ten,Ho from Nhanvien",connect);
             Adapter.Fill(dataSet);
             DataTable table = dataSet.Tables["NhanVien"];
            //  var Row = table.Rows.Add();
            //  Row["Ten"] = " D";
            //  Row["Ho"] = "Nguyễn Văn ";
             // insert cmd 
             Adapter.InsertCommand = new SqlCommand("insert into NhanVien (Ho,Ten) values (@Ho,@Ten)",connect);
             Adapter.InsertCommand.Parameters.Add("@Ho",SqlDbType.NVarChar,255,"Ho"); // => add param họ , SQLTYPE.NVARCAHR <=> NVARCHAR , ĐỘ DÀI 255 , LẤY TRƯỜNG CỘT HỌ 
             Adapter.InsertCommand.Parameters.Add("@Ten",SqlDbType.NVarChar,255,"Ten");
             // cap nhat 
             Adapter.DeleteCommand = new SqlCommand("delete from Nhanvien where NhanviennID = @NVID",connect);
             var pr1 = Adapter.DeleteCommand.Parameters.Add(new SqlParameter("@NVID",SqlDbType.Int));
             // nguồn để lấy dữ liệu từ datatable ? lấy cột nào
             pr1.SourceColumn = "NVID";
             pr1.SourceVersion = DataRowVersion.Original ; 
            //  var row10 = table.Rows[10];
            //   row10.Delete(); // phải định nghĩa lại deleteCmd
                ShowTable(table);
             Adapter.Update(dataSet);


             connect.Close();

             // dataset là 1 đối tượng để chứa data table
             // data adapter có thể đổ dữ liệu vào dataset 
            //  var DataSet = new DataSet();
            //  // tạo ra bảng ánh xạ từ database 
            //  var table = new DataTable("MyTable"); //
            //  DataSet.Tables.Add(table);
            //  table.Columns.Add("STT"); 
            //  table.Columns.Add("Họ Tên"); 
            //  table.Columns.Add("Tuổi");
            //  table.Rows.Add(1,"Nguyen Van A",20); 
            //  table.Rows.Add(2,"Nguyen Van b",20); 
            //  table.Rows.Add(3,"Nguyen Van c",20);
            //   Console.WriteLine($"Tên bảng:{table.TableName}");
            //   foreach (DataColumn item in table.Columns)
            //   {
            //       Console.Write($"{item.ColumnName,20}");
            //   }
            //   var number_Col = table.Columns.Count;
            // //  Console.WriteLine("So lUONG"+number_Col);
            //   foreach (DataRow item in table.Rows)
            //   {
            //       //Console.WriteLine("oke");
            //     //   Console.WriteLine($"\n{item[0],20} - {item[1],20} - {item[2],20}");
            //     Console.WriteLine("\n");
            //     for(int i = 0 ; i<number_Col ; i++){
            //         Console.Write($"{item[i],20}");
            //     }
                
            //   }

        }
    }
}
