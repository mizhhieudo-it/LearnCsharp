using System;
namespace Bai010_OOP
{
    class sinhvien : IDisposable {
    public string tensv{get ;set;}
    public sinhvien(string name){
        tensv = name;
        Console.WriteLine("Khoi tao"+name);
    }
    ~sinhvien(){
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hàm hủy đc khởi dộng");
        Console.ResetColor();
    }

        public void Dispose()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hàm hủy đc khởi dộng");
            Console.ResetColor();
        }
    }

 
}