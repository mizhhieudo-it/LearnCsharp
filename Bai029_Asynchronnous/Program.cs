using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Bai029_Asynchronnous
{
    // Synchronous : lập trình đơn luồng => task 1 => done => task2 => done => task 3 
    class Program
    {
        // get 1 website 
        static async Task<string> GetWeb(string url){
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage kq =  await httpClient.GetAsync(url);
            return await kq.Content.ReadAsStringAsync(); // đọc nội dung trang web
        }
        
        //asynchronous (multi thread) // đa luồng
        static void DoSomeThing(int seconds, string mgs, ConsoleColor color)
        {

            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} -.. Start");
                Console.ResetColor();


            }
            // thực hiện xong lock a xong các luồng khác mới đc sử dụng
            for (int i = 0; i < seconds; i++)
            {
                lock (Console.Out)
                {
                    Console.ForegroundColor = color;
                    Console.WriteLine($"{mgs,10} - {i,2} "); // 10-2 là khoảng không gian
                    Console.ResetColor();
                    Thread.Sleep(1000);

                }

            }
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{mgs,10} -... End");
                Console.ResetColor();
            }



        }
        static async Task Task2()
        {
            Task t2 = new Task(
                () =>
                {
                    DoSomeThing(5, "TASK2", ConsoleColor.DarkCyan);
                }
            ); // TƯƠNG ỨNG VỚI DELEGET KHÔNG THAM SỐ () => {}
            t2.Start();
            await t2 ; // tại thời điểm awat => trả về task2 luôn
            t2.Wait(); // chờ hoàn thành thì mới làm 1 việc gì đó 
            Console.WriteLine("Task2 done");
            //return t2;

        }
        static async Task Task3()
        {
            //Task t3 = new Task(Action<Object>,Object); // (Object obj) =>{} , tham số thứ 2 là để truyền vào 
            Task t3 = new Task((object obj) =>
            {
                string nametask = (string)obj;
                DoSomeThing(5, nametask, ConsoleColor.Green);

            }, "Task3");
            t3.Start();
            t3.Wait(); // chờ hoàn thành thì mới làm 1 việc gì đó 
            Console.WriteLine("Task3 done");
            await t3;
            //return t3;

        }
        // void ko trả về với asyn/await 
        // static async Task ABC(){
        //     // do some thing 
        //     Task task = new Task(delegate); 
        //     task.Start();
        //     await task ; 
        // }
        static async Task<String> TASK4(){
            // Task<string> t4 = new Task<string>(Func<string>);// () => {return string } 
            // triển khai 
            Task<string> t4 = new Task<string>(()=>{
                DoSomeThing(10,"task 4",ConsoleColor.DarkBlue);
                return "Return Form T4";
            });
            t4.Start();
            var kq = await t4 ;
            return kq ;
            //return t4;
        }
        static async Task<String> TASK5(){
            Task<string> t5 = new Task<string>(
                (object ob)=>{
                    string t = (string)ob ; // convert
                    DoSomeThing(10,t,ConsoleColor.DarkRed);
                    return "Return Form T5";
                },"Task5"
            );
            t5.Start();
            var kq = await t5 ;
            //return t5;
            return kq ;
            
        }
        static void Main(string[] args)
        { 
            var taske = GetWeb("https://xuanthulab.net"); 
            DoSomeThing(6,"t1",ConsoleColor.Blue);
            var content = await taske ; 
            Console.WriteLine(content);

            //  Task t5 = TASK4();
            //  Task t4 = TASK5();
             //Task t2 = Task2();
            // DoSomeThing(5, "Task1", ConsoleColor.Yellow);
            // Task t3 = Task3();
             
            //Task.WaitAll(t3,t2);
            // Console.WriteLine("============");
            // Lập trình đồng bộ => khóa luồng
            // lock (Console.Out)
            //     DoSomeThing(3, "Task1", ConsoleColor.DarkRed);
            //     DoSomeThing(3, "Task2", ConsoleColor.Magenta);
            //     DoSomeThing(3, "Task3", ConsoleColor.Yellow);
            // Console.WriteLine("Hello World!");
            // Task

            

            // khởi chạy task vị t2 => t2.start();

            // Task t2 = new Task2();
            //Task.WaitAll(t2,t3);//chờ tất cả tác vụ hoàng thành
            //t2.Wait(); phải chờ luồng khác với end 
            //t3.Wait(); phải chờ luồng khác với end 
            // /DoSomeThing(5, "Task1", ConsoleColor.Yellow);
            // Console.WriteLine("Press Any Key......");
            // Console.ReadKey();
            
            // Task<string> t5 = new Task<string>(Func<object,string>,object);// () => {return string } object là tham số 1 , object lần 2 là tham số 2 
            // triển khai 
            
            //DoSomeThing(3,"task1",ConsoleColor.DarkCyan);
            // Task t4 = new TASK4();
            // Task t5 = new TASK5();
            // var t2 = new Task2();
        
            // Task.WaitAll(t4,t5);
            // Console.WriteLine(t4.Result);
            // Console.WriteLine(t5.Result);
            // với cách khai báo như trên thì ta sẽ đọc đc kq 

        }
    }
}
