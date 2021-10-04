using System;
using System.IO;
using MyException;

namespace Exception_Example
{
    class Program
    {
        // dang ki lop exception
        static void Register(string name,int age){
            if(string.IsNullOrEmpty(name)){
              //  Exception exception = new Exception("Ten phai khac rong");
                throw new NameEx();
            }
            if(age <18 || age >100){
                throw new Exception("Tuoi phai >-18 and <=100");
            }
            Console.WriteLine("xin chao"+name);
        }
        static void Main(string[] args)
        {
            // khối try
            int a = 5 ; 
            int b = 4 ; 
            //Exception : phát sinh đối tượng exception , ke thua exception
            try
            {
                var c = a /b ; //  
                Console.WriteLine(c);
                int[] i = {1,2};
                var x = i[5];

            }
            catch(Exception e)
            {
                Console.WriteLine("Phep chia co loi"+e.Message);
                Console.WriteLine("Loi Xay ra o trong :"+e.StackTrace);
                Console.WriteLine( e.GetType().Name);
            }
            Console.WriteLine("end...");
            // Working with File
            try{
                // chmod - r 1.txt ko cho phép mở ra đọc
                string path = "1.txt"; 
                string s = File.ReadAllText(path);
                Console.WriteLine(s);
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }

            Register("DH",21);
            
            
            Register(null,21);

        }
    }
}
