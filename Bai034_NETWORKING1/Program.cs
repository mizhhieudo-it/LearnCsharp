using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
namespace Bai034_NETWORKING1
{
    // Đọc HTTP MESSAGE = curl url
    class Program
    {
        public static void ShowHeader(HttpResponseHeaders headers)
        {
            Console.WriteLine("cac header");
            foreach (var item in headers)
            {
                Console.WriteLine($"{item.Key}-{item.Value}");
            }

        }
        public static async Task<string>  GetWebContent(string url)
        {
            using var httpClinet = new HttpClient();
            try{
                // thêm header
                httpClinet.DefaultRequestHeaders.Add("User-Agent","Mozilla/5.0");// cho biết trình duyệt gửi đi 
                HttpResponseMessage httpResponseMessage = await httpClinet.GetAsync(url);// thực thiện phương thức đồng bộ 
                ShowHeader(httpResponseMessage.Headers);
                string html = await httpResponseMessage.Content.ReadAsStringAsync(); // 
                 return html;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                return "Error";
            }
            
        }
        public static async Task<byte[]>  DowloadDataBytes(string url)
        {
            using var httpClinet = new HttpClient();
            try{
                // thêm header
                httpClinet.DefaultRequestHeaders.Add("User-Agent","Mozilla/5.0");// cho biết trình duyệt gửi đi 
                HttpResponseMessage httpResponseMessage = await httpClinet.GetAsync(url);// thực thiện phương thức đồng bộ 
                ShowHeader(httpResponseMessage.Headers);
                var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync(); // 
                 return bytes;

            }
            catch(Exception e){
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
        static async Task Main(string[] args)
        {
            // string url = "https://yotube.com/";
            // var uri = new Uri(url);
            // var uritype = typeof(Uri);
            // uritype.GetProperties().ToList().ForEach(property =>
            // {
            //     Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            // });
            // Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
            // var hostname = Dns.GetHostName(); // get host name của máy đang chạy
            // // Get Host qua url 
            // Console.WriteLine(uri.Host);
            // // Get Info thông qua host
            // var iphostentry = Dns.GetHostEntry(uri.Host);
            // Console.WriteLine(iphostentry.HostName);
            // Console.WriteLine(hostname);
            // // Get List Dia Chi IP 
            // iphostentry.AddressList.ToList().ForEach(item => Console.WriteLine(item));

            // //======================== Test Xem SERVER PHẢN HỒI HAY KO =========================
            // var ping = new Ping(); // tạo ra đối tượng lớp ping để sử dụng 
            // // Gán địa chỉ muốn chỏ tới 
            // var pingReply = ping.Send("google.com.vn");
            // Console.WriteLine(pingReply.Status);// trả về trạng thái có phản hồi
            // if (pingReply.Status == IPStatus.Success)
            // {
            //     Console.WriteLine(pingReply.RoundtripTime);
            //     Console.WriteLine(pingReply.Address);
            // }
            //=============== Test Func GetContent =============
            var urlXT = "https://www.google.com/search?q=xuanthulab";
            var html = await GetWebContent(urlXT); // => Return 1 task
            //task.Wait();
            Console.WriteLine(html);
            // Http Request - HttpClient (GET/POST);
            // =========== Dowoad Get Bytes=========
            // var url1 = "https://vnn-imgs-a1.vgcloud.vn/cdn.24h.com.vn/upload/1-2020/images/2020-03-16/1584324285-90-anh-2-1584088794-width650height867.jpg";
            // var bytesImg = await DowloadDataBytes(url1);
            // string filename = "1.png" ; 
            // using var stream = new FileStream(filename,FileMode.Create,FileAccess.Write,FileShare.None);
            // stream.Write(bytesImg,0,bytesImg.Length);
            using var httpClinet  = new HttpClient();
            var httpMessageRequest = new HttpRequestMessage();
            // tạo ra request ; 
            httpMessageRequest.Method = HttpMethod.Post ; // khai báo phương thức 
            httpMessageRequest.RequestUri = new Uri("https://postman-echo.com/post"); // khai báo địa chỉ 
            httpMessageRequest.Headers.Add("User-Agent","Mozilla/5.0");
            // tạo ra đối tượng đền gửi 
            var params1 = new List<KeyValuePair<string,string>>(); 
            params1.Add(new KeyValuePair<string, string>("key1","value1"));
            params1.Add(new KeyValuePair<string, string>("key2","value2"));
            params1.Add(new KeyValuePair<string, string>("key3","value3"));
            var content = new FormUrlEncodedContent(params1);
            httpMessageRequest.Content = content;

            // đóng gói 
            var httpMessageMess = await httpClinet.SendAsync(httpMessageRequest);
            var html1 = httpMessageMess.Content.ReadAsStringAsync();
            Console.WriteLine(html1);


        

        }
    }
}
