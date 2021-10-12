using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Bai029_Async_Await
{
    class Program
    {
        public static void DoSomeThing(string mgs, ConsoleColor color, int redup)
        {
            Console.WriteLine("Star........");
            for (int i = 0; i < redup; i++)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs}- step {i}");
                Thread.Sleep(100);
                Console.ResetColor();
            }
            Console.WriteLine("Done........");            
        }
        public static Task Task1()
        {
            Task task1 = new Task(() =>
            {
                DoSomeThing("Task1", ConsoleColor.DarkCyan, 3);
            });
            task1.Start();
            task1.Wait(); /* Những rằng dùng từ khóa wait thì lại phá vỡ đi cấu trúc của đá luôn bởi vì 
            wait mang ý nghĩa dòng 1 done => task 2 mới đc thực thi
            đề khắc phục điều đó , ta có thể sử dụng await .........
             */
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("===Done Task 1 ======");
            return task1;
        }
        public static Task Task2()
        {
            Task task2 = new Task((object obj) =>
            {
                string nametask = (string)obj;
                DoSomeThing(nametask, ConsoleColor.DarkGreen, 3);
            }, "task2");
            task2.Start();
            task2.Wait();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("===Done Task 2 ======");
            return task2;
        }
        //Task 3 và Task4 sẽ làm rõ hơn 
        //============= use await don't break thread=================
        public static async Task Task3()
        {
            Task task3 = new Task(() =>
            {
                DoSomeThing("Task3", ConsoleColor.DarkCyan, 3);
            });
            task3.Start();
            task3.Wait(); /* Những rằng dùng từ khóa wait thì lại phá vỡ đi cấu trúc của đá luôn bởi vì 
            wait mang ý nghĩa dòng 1 done => task 2 mới đc thực thi
            đề khắc phục điều đó , ta có thể sử dụng await .........
             */
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            await task3;
            Console.WriteLine("===Done Task 3 ======");
            //return task3;
        }

        public static string DownloadWebpage (string url, bool showresult) {
            using (var client = new WebClient ()) {
                Console.Write ("Starting download ...");
                string content = client.DownloadString (url);
                Thread.Sleep (3000);
                if (showresult)
                    Console.WriteLine (content.Substring (0, 150));

                return content;
            }
        }

        static void Main(string[] args)
        {
            // Task t1 = Task1();
            // Task t2 = Task2();
            // ở đây nếu không trờ luồn thì task nào xong trc thì main sẽ out làm luôn công việc tiếp theo mà ko đợi luồng khác thật sự xong
            //============= use await don't break thread=================
          // Task t3 = Task3();
            //DoSomeThing("task1",ConsoleColor.DarkMagenta,3);
           // Task t4 = Task4();
           string url = "https://code.visualstudio.com/";
            DownloadWebpage(url, true);
            Console.WriteLine("Do somthing ...");

            Console.WriteLine("Press any Key..........");
        }
    }
}
