using System;
using System.Linq;

namespace Bai21_Lamda
{
    /*
    Lamda - Anonymous function
    1) 
    (tham_so) => bieu_thieu

    2)
    (tham_so) =>{
        cac bieu_thuc;
        return bieu_thuc_tra_ve;
    }

    */
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> thongbao ;
            thongbao = (string s)=> Console.WriteLine(s); // ~ tương đương với delegate void Kieu(String ) 
            Action thongbao1 = ()=>Console.WriteLine("hello");
            // short hand 
            Action<string,string> ShortHand =(s,x)=>Console.WriteLine(s+" "+x);
            Action<string,string> welcome ;
            welcome = (mgs,name) =>{
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(mgs +" "+name);
            };
            // short hand => return 
            Func<int,int,int> total ; 
            total = (a,b) =>{
                return a+b;
            };
            int[] arr = {2,3,4,12,3,32,123,321,55};
            var kq = arr.Select((int x) => {
                return Math.Sqrt(x);
            });
            arr.ToList().ForEach(
                (x)=> {
                    if(x % 2 !=0 )
                        Console.WriteLine(x);
                }
            );
            var kq1 = arr.Where(
                (int x) => {
                    return x % 4 == 0 ; 
                }
            );

            // lamda đc sử dụng như thế nào ????????
            thongbao?.Invoke("xin chao");
            thongbao?.Invoke("xin chao");
            thongbao?.Invoke("xin chao");
            thongbao?.Invoke("xin chao");
            thongbao1?.Invoke();
            ShortHand?.Invoke("test short hand => oke","tham chieu 2");
            welcome("xin chao","H");
            Console.WriteLine(total(1,2));
            //duyet 
            foreach(var x in kq){
                Console.WriteLine(x);
            }
            foreach(var x in kq1){
                Console.WriteLine(x);
            }
        }
    }
}
