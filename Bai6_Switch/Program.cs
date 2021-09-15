using System;

namespace Bai6_Switch
{

    class Program
    {
        static void Main(string[] args)
        {
            // int a ; 
            // a = 1 ; 
            // if(a == 1 ){
            //     Console.Write("Value is one");
            // }
            // else if ( a == 2)
            // {
            //     Console.Write("Value is two");
            // }
            // else if ( a == 3)
            // {
            //     Console.Write("Value is two");
            // }
            // else{
            //     Console.Write("Hãy Kiểm Tra Số Khác");
            // }
            // switch(a){
                // case 1:
                //     Console.WriteLine("a ==1");
                //     break;
                // case 2:
                //     Console.WriteLine("a ==2");
                //     break;
                // case 3:
                //     Console.WriteLine("a ==3");
                //     break;
                // case 4:
                //     Console.WriteLine("a ==4");
                //     break;
                // case 1:
                // case 3:
                //     Console.WriteLine("a la so le");
                //     break;
                // case 2:
                // case 4:
                //     Console.WriteLine("a la so chan");
                //     break;
                // default:
                //     Console.WriteLine("Kiem tra so khac");
                //     break;
                int a , b ;
                Console.WriteLine("Input is  value :") ; 
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Input is  value :") ; 
                b = int.Parse(Console.ReadLine());
                char c  = '1'; 
                // doc 1 ki tu 
               L1:
                Console.WriteLine("Nhap 1 ki tu");
                c = Console.ReadKey().KeyChar ;
                Console.WriteLine(); 
                switch(c){
                    case '1':
                        Console.WriteLine($"Tong la {a +b}");
                        break;
                    case '2':
                        Console.WriteLine($"Hieu la {a  - b}");
                        break;
                    case '3':
                        Console.WriteLine($"Tich la {a  * b}");
                        break;
                    case '4':
                        Console.WriteLine($"Thuong la {a  / b}");
                        break;
                    default:
                        Console.WriteLine("Vui long chon lenh khac");
                        goto L1 ;// điều hướng sang nhánh ngoài vòng lặp(L1 " nhãn")
                    break;
                }

            //}
            
        }
    }
}
