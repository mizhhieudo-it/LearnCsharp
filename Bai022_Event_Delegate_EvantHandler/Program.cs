using System;

namespace Bai022_Event_Delegate_EvantHandler
{
    /*
    publicsher -> class - phát đi sự kiện 
    subsriber -> class -> nhận sự kiện 
    */
    // publisher
    //step 1 : tao 1 Delegate  
    public delegate void Event_Input(int x);
    class DuLieuNhap : EventArgs
    {
        public int data {get ;set;}
        public DuLieuNhap(int _x) => data = _x ;
    }
    class UserInput
    {
        // tu khoa event : chi cho phep += hoa -= ;
        // step 2 : tao 1 thuoc tinh kieu delegate 
        public event Event_Input SuKienNhapSo ;
        // deleget cung cap san 
        public event EventHandler sukien ; // ~ delegate void kieu(obj? sender,EventArgs arg)
        public void Input(){
            do{
                Console.WriteLine("Nhap vao 1 so");
                int x = int.Parse(Console.ReadLine());
                 // phat su kien cua delegate di
                SuKienNhapSo?.Invoke(x);
                sukien?.Invoke(this,new DuLieuNhap(x)); // dung tu khoa this de cho biet day noi publisher
            }while(true);
        }


    }
    class BinhPhuong{
        public void Sub(UserInput x){
            // gan delegate = 1 su kien
            x.SuKienNhapSo += tinhbinhphuong;
        }
        private void tinhbinhphuong(int x){
            Console.WriteLine($"Binh Phuong cua {x}  ket qua :{Math.Pow(x,2)}");
        }
        private void tinhbinhphuong_event(object? sender,EventArgs e){
            DuLieuNhap x = (DuLieuNhap)e ;
            int i = x.data;
            Console.WriteLine($"Binh Phuong cua {i}  ket qua :{Math.Pow(i,2)}");
        }
    }
    class Can{
        public void Sub(UserInput x){
            // gan delegate = 1 su kien
            x.SuKienNhapSo += tinhcan;
        }
        private void tinhcan(int x){
            Console.WriteLine($"can bac 2 cua {x}  ket qua :{Math.Sqrt(x)}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //publisher 
            UserInput us =new UserInput();
            us.SuKienNhapSo += x =>{
                Console.WriteLine($"Ban vua nhap vao so {x}");
            };
            us.sukien += (sender,e)=>{
                DuLieuNhap x = (DuLieuNhap)e; 
                Console.WriteLine(x.data);
            };
            BinhPhuong x1 = new BinhPhuong();
            Can x2 = new Can();
            x1.Sub (us);
            x2.Sub (us);
            us.Input();

        }

      
    }
}

