using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Bai032_Attribute_Type
{
    /**
    tạo ra att 
    Mo ta : 
        - thông tin chi tiết 
    */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property)] // mô tả đc sửa dụng ở đâu (class , method , properties)
    class MotaAttribute : Attribute
    {
        public string Thongtinchitiet { get; set; }
        public MotaAttribute(string mess)
        {
            Thongtinchitiet = mess;
        }

    }
    [Mota("Class user describing info user ")]
    class user
    {

       // [Mota("Mo ta ten ")]
       [Required(ErrorMessage ="Name không đc để null ")]  // required : ko đc null
       [StringLength(50,MinimumLength =3, ErrorMessage ="Ten phai dai tu 3 den 100 ki tu")] // gioi han ki tu 3 -50 kí tự 
        public string Name { set; get; }
       // [Mota("Mo ta tuoi ")]
       [Range(18,80,ErrorMessage ="Tuoi phai tu 18 den 80")]
        public int Age { set; get; }
      //  [Mota("Mo ta so phone ")]
        public string PhoneNumber { get; set; }
      //  [Mota("Mo ta email ")]
        [EmailAddress(ErrorMessage ="Dia Chi sai  cau truc")]
        public string Email { get; set; }
        public user(string _name, int _age, string _numberphone, string _Email)
        {
            Name = _name;
            Age = _age;
            PhoneNumber = _numberphone;
            Email = _Email;
        }
        [Obsolete("Phuong thuc nay khong nen su dung nưa")]
        public void HelloUsers()
        {
            Console.WriteLine($"Hello {Name}");
        }

    }
    class Program
    {
        // Type 
        // Attribute 
        // Reflection // Add Atttribute(thamso)
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3 };
            var t = a.GetType();
            Type t1 = typeof(int);
            var t2 = typeof(string);
            var t3 = typeof(Array);
            // Console.WriteLine(t.FullName);// lấy tên
            t.GetProperties().ToList().ForEach
            (
                 (PropertyInfo x) =>
                 {
                     Console.WriteLine(x.Name);
                 }
            ); // get name item properties
            t.GetFields().ToList().ForEach
            (
                 (FieldInfo x) =>
                 {
                     Console.WriteLine(x.Name);
                 }
            ); // get Fields item properties
            Console.WriteLine("===========GET METHOD======");
            t.GetMethods().ToList().ForEach
            (
                 (MethodInfo x) =>
                 {
                     Console.WriteLine(x.Name);
                 }
            ); // get Method item properties
            //===================user===============================
            Console.WriteLine("=======Properties Users==========");
            user user1 = new user("MH", 31, "0123123123", "XXX@XX.COM");
            user1.GetType().GetProperties().ToList().ForEach(x => Console.WriteLine($"properties {x.Name}:{x.GetValue(user1)}"));//
            //user1.HelloUsers(); // đưa ra cảnh báo
            // check xem đúng validate 
            ValidationContext context = new ValidationContext(user1); // đối tượng cần kiểm tra là user 1 
            var result = new List<ValidationResult>(); // tạo ra 1 mảng để các lỗi sẽ trong này
            bool kq = Validator.TryValidateObject(user1,context,result,true);
            if(kq == false){
                result.ToList().ForEach((er)=>{
                    Console.WriteLine(er.ErrorMessage); // in tb lỗi 
                    Console.WriteLine(er.MemberNames.First());
                });
            }


        }
    }
}
