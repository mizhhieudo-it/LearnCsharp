using System ;
namespace Bai010_OOP
{
    /*
    phạm vi truy cập : 
    public : truy cập từ bất cứ đầu
    internal : truy cập trong chương trình ( mặc định)
    */
    class VuKhi{
        //DU LIEU 
        // nếu ko chỉ rõ mặc định là private , truy cập từ bên ngoài 
        public string name = "Ten Vu Khi";
        int  dosatthuong = 0 ;
        //THUOC TINH
        public int Satthuong{
            //== thực hiện khi truy cập.get trả về giá trị cùng với hàm 
            get{
                return dosatthuong ;
            }
            //== được thi hành khi thực hiện phép gán
            set{
                dosatthuong = value ;
            }
        }
        public string noisanxuat{get ;set;}
        // Phương thức khở tạo
        public VuKhi(){
            Console.WriteLine("Khoi tao") ; 
            dosatthuong = 1 ;
            // mục đích khởi tọa trường dữ liệu , các biến ;
        }
        public VuKhi(string name,int _stt){
            this.name = name ; 
            dosatthuong = _stt;
            // mục đích khởi tọa trường dữ liệu , các biến ;
        }
        public VuKhi(string A){
            Console.WriteLine(A) ; 
            // mục đích khởi tọa trường dữ liệu , các biến ;
        }
        // Khai Bao Phuong Thuc 
        public void ThietlapSatthuong(int st){
            this.dosatthuong =st ; 
            // this -> tham chiếu của lớp hiện tại
          //  VuKhi abc = this; 
            
        }
        public void TanCong(){
            Console.Write("\n"+this.name+"\t");
            for (int i = 0; i < dosatthuong; i++)
            {
                Console.Write(" * ");
            } 
        }

    }
}