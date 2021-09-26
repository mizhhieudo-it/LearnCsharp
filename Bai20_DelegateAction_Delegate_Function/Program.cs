using System;

//delegate : (Type) : tạo ra các biến để gán bằng phương thức 
namespace Bai20_DelegateAction_Delegate_Function
{
    //Action-Func = delegate - gereric 

    public delegate void ShowLog(string message);
    class Program
    {
         static void info(string s){
             Console.ForegroundColor = ConsoleColor.Green ; 
             Console.WriteLine(s);
             Console.ResetColor();
         }
         static void Warning(string s){
             Console.ForegroundColor = ConsoleColor.Red ; 
             Console.WriteLine(s);
             Console.ResetColor();
         }
         static int tong(int a ,int b) => a + b ; 
         static void Hieu(int a,int b,ShowLog log){
             int kq = a - b ;
             log?.Invoke($"Tong is{kq}");
         }
        static void Main(string[] args)
        {
            // biến delegate có thể nhật 1 chuỗi phương thức 
            // 1 delegate có thể gọi đc nhiều lần 
           
            ShowLog Log = null ; // biến kiểu tham chiếu sử dụng toán tử += => vừa sử dụng info vừa sử dụng waring
            Log += info ; 
            Log?.Invoke("XinChoAVC");
            Log("XinChao");
            Log += Warning;
            Log += info ; 
            Log.Invoke("Xin Chao");
            // action : 
            Action action; // delegate void KIEU():
            Action<string,int> action1 ; //delegate void Kieu(string s,int i);
            Action<string> action2 = info;
            action2?.Invoke("Oke eeeeeeeeeeeee");
            // Func : vẫn như action như phải trả về 1 gì đó 
            Func<int> f1 ;  // delegate int : => return int  
            Func<string,double,string> f2 ; // => delegate string f2(string f1,double f3)
            Func<int,int,int> Total ; 
            Total = tong ; 
            Console.WriteLine($"total is {tong(3,4)}");
            ShowLog x = info; 
            Hieu(5,4,x);
        }
    }
}
