using System;
using System.IO;
using Product;
using Students;

namespace Bai028_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            String pathFile = "Data_Student.dat";
            using var streamStudent = new FileStream(path:pathFile,FileMode.OpenOrCreate);
            student sv1 = new student()
            {
                // IDstudent = 1 ,
                // Namestudent = "Nguyen van A",
                // Pointstudent = 9.0
            } ; 
          //  sv1.SaveWithFile(streamStudent);
            sv1.ReadFile(streamStudent);
            Console.WriteLine($"ID Student :{sv1.IDstudent} - FullName Student: {sv1.Namestudent} - Point : {sv1.Pointstudent}");
        }
    }
}
