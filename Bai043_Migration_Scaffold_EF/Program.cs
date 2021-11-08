using System;

namespace Bai043_Migration_Scaffold_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            //add migration => database 
            /*
            //=========Model Frist ================
            dotnet ef migrations add MigrationName 
            show all migration 
            dotnet ef migrations list : trạng thái pending => chưa có trong db mà mới chỉ snapshort
            dotnet ef migrations remove : delete short end
            dotnet ef migrations Script : show all script ( hiện truy vất all)
            dotnet ef migrations Script : Name1 -> Name ( hiện truy vất all từ giao đoạn V1 = > V2)
            dotnet ef migrations Script -o filename : lưu ra file 
            dotnet ef database update [MigrationName]
            dotnet ef dabase drop -f : xóa db
            =======DB frist=====================
            dotnet ef dbcontext scaffold -o ThưMụcChứaModel -d "chuỗi connectstring" "Microsoft.EntityFrameworkCore.SqlServer"
            vd 
            dotnet ef dbcontext scaffold -o data -d "Data Source=MINHHIEUPC\SQLEXPRESS;Initial Catalog=xtlab;Trusted_Connection=True" "Microsoft.EntityFrameworkCore.SqlServer"
            
            */
        }
    }
}
