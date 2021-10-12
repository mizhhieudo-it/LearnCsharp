using System;
using Newtonsoft.Json;
using HITLAB.Utils;

namespace Bai031_NuGetPackage
{
    // add 1 package with name  : dot net add package _ten_package_version 
    // remove 1 packet : dotnet remove package Newtonsoft.Json
    // Err Packget : dotnet restore
    // dotnet add tenduan.csproj thu vien can tham chieu(thuvien.csproj)
    // G:\Project\LearnCsharpWithXT\Theory\Bai031_NuGetPackage\Bai031_NuGetPackage.csproj reference (.. thư viện cần tham chiếu) G:\Project\LearnCsharpWithXT\Theory\Bai31_Utils\Bai31_Utils.csproj
    class Product{
        public string Name {get;set;}
        public DateTime Expiry {get ;set;}
        public string[] Sizes {get ;set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Name = "Apple";
            product.Expiry = new DateTime(2008, 12, 28);
            product.Sizes = new string[] { "Small" };
            // convert to json
            string json = JsonConvert.SerializeObject(product);
            Console.WriteLine(json);
            // ======== json========
            string json1 =@"
            {
                ""Name"":""IPHONE"",
                ""Expiry"":""2021-01-30T00:00:00"",
                ""Sizes"":[""MINI"",""SX"",""SXMAX""]
            }
            ";
            // convert to product ;
            var product1 =  JsonConvert.DeserializeObject<Product>(json1);
            Console.WriteLine(product1.Name);
            // {
            //   "Name": "Apple",
            //   "Expiry": "2008-12-28T00:00:00",
            //   "Sizes": [
            //     "Small"
            //   ]
            // 
            double a = 3123123;
            var kq = CovertMoneytoText.NumberToText(a);
            Console.WriteLine(kq);
        }
    }
}
