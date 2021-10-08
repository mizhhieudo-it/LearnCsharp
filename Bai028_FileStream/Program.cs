using System;
using System.IO;
using System.Text;
using Pratice;

namespace Bai028_FileStream
{
    class Program
    {
        static void Main(string[] args)
        {
        //     // Lớp DriveInfo cho biết các thông tin về ổ đĩa
        //     /*
        //     isReady : có đang sẵn sàng hoạt động ko ( boolean)
        //     DriveType : kiểu ổ đĩa 
        //     VolumLable : nhãn dánh ở đĩa
        //     DriveFormat : Chuỗi cho biết định dạng :NTFS ,FAT32,FAT,DEVFS
        //     AvailableFreeSpace: dung lượng chống theo tên ng dùng
        //     TotalFreeSpace : Số byte còn trống ; 
        //     TotalSize :tổng byte trên đãi
        //     */
        //   //  DriveInfo drive = new DriveInfo("C");
        //     //get all ds 
        //     var AllDrive = DriveInfo.GetDrives();
        //     foreach (var drive in AllDrive)
        //     {
        //         Console.WriteLine($"Drive:{drive.Name}");
        //         Console.WriteLine($"Drive Type:{drive.DriveType}");
        //         Console.WriteLine($"Drive Lable:{drive.VolumeLabel}");
        //         Console.WriteLine($"Drive Format:{drive.DriveFormat}");
        //         Console.WriteLine($"Drive Size:{drive.TotalSize}");
        //         Console.WriteLine($"Drive Size Free:{drive.TotalFreeSpace}");
        //         Console.WriteLine("=========================================");
        //     }
        //     //Lớp Directory - Lam Viec với thư mục
        //     /*
        //     Exists(path):Kiểm tra thư mục có tồn tại hay không ?
        //     CreateDirectory(path):tạo ra đối đượng theo đường dẫn path => return 1 obj Directory 
        //     Delete(path) : xóa thư mục theo đường dẫn 
        //     GetFiles(path): lấy các file trong thư mục 
        //     GetDirectories(path) : lấy các thư mục con trong thư mục 
        //     Movi(src,des):di chuyển thư mục
        //     */
        //     string path = "obj" ;
        //    // Directory.CreateDirectory(path);// tạo
        //     // check xem thư mục này có tồn tại ko 
        //    // Directory.Delete(path); //xóa 
        //     if(Directory.Exists(path)){
        //         Console.WriteLine($"{path} - ton tai");
        //     }
        //     else{
        //         Console.WriteLine($"{path} - ko ton tai");
                
        //     }
        //     // lấy ds các file trong thư mục 
        //     var files = Directory.GetFiles(path);
        //     foreach (var item in files){
        //         Console.WriteLine(item); // return path file
        //     }
        //     //Path =  Hỗ trợ làm việc với đường dẫn 
        //     /*
        //         Path.DirectorySeparatorChar	Thuộc tính chứa ký tự phân cách đường dẫn thư mục (\ trên Windows, / trên *nix)
        //         Path.PathSeparator	Thuộc tính chứa ký tự phân chia thư mục trong biến môi trường
        //         Combine	Kết hợp các chuỗi thành dường dẫn
        //         var path = Path.Combine("home", "ReadMe.txt"); //  "home/ReadMe.txt"
        //         GetDirectoryName	Lấy đường dẫn đến file (thư mục)
        //         var path = Path.GetDirectoryName("/home/abc/zyz/ReadMe.txt"); //  "/home/abc/zyz"
        //         GetExtension	Lấy phần mở rộng
        //         var path = Path.GetExtension("/home/ReadMe.txt"); //  ".txt"
        //         GetFileName	Lấy tên file
        //         var path = Path.GetFileName("/home/abc/ReadMe.txt"); //  "ReadMe.txt"
        //         GetFileNameWithoutExtension	Lấy tên file
        //         var path = Path.GetFileNameWithoutExtension("/home/ReadMe.txt"); //  "ReadMe"
        //         GetFullPath	Lấy đường dẫn đầy đủ - từ đường dẫn tương đối
        //         var path = Path.GetFullPath("ReadMe.txt");
        //         GetPathRoot	Lấy gốc của đường dẫn
        //         GetRandomFileName	Tạo tên file ngẫu nhiên
        //         var path = Path.GetRandomFileName();
        //         GetTempFileName	Tạo file duy nhất, rỗng
        //         var path = Path.GetTempFileName();
        //     */
        //     Console.WriteLine("===PATH===========");
        //     Console.WriteLine(Path.DirectorySeparatorChar);
        //     var pathlocal = Path.Combine("Dir1","Dir2","Tenfile.txt"); // =>  return duong dẫn
        //     Console.WriteLine(pathlocal);
        //     pathlocal = Path.ChangeExtension(pathlocal,"md"); // doi duoi duong dan từ txt => md => return path
        //     Console.WriteLine(pathlocal);
        //     Console.WriteLine(Path.GetDirectoryName(pathlocal));// return path chua file
        //     Console.WriteLine(Path.GetExtension(pathlocal));// return phan mo rong
        //     Console.WriteLine(Path.GetFileName(pathlocal));// return phan ten file 
        //     Console.WriteLine(Path.GetFullPath(pathlocal));// return full đường dẫn nếu để ở dạng Dir1/dir2/file => đc full pack còn /dir1/dir2/file thì ko 
        //     var FileRamdon = Path.GetRandomFileName();
        //     Console.WriteLine(FileRamdon);
        //     // tạo ra các file tạm ngẫu nhiên 
        //     //var pathTemp = Path.GetTempFileName();
        //   //  Console.WriteLine(pathTemp);
        //     //=======================FILE===============================
        //     string filename = "abc.txt"; // đường dẫn tương đối 
        //     string content = "Xin Chao CSHARP";
        //     string content1 = "Xin Chao 2022";
        //     File.WriteAllText(filename,content); // ko có file thì sẽ tạo ra // nếu file đã có nội dụng rồi thì nó clear nội dung cũ . để viết tiếp sử dụng File.AppendAllText
        //     File.AppendAllText(filename,content1);
        //     //Doc File 
        //     var DocFile = File.ReadAllText(filename);
        //     Console.WriteLine(DocFile);
        //     // đổi tên file 
        //    // File.Move(filename,"123.txt");
        //     //copy file 
        //    // File.Copy("abc.txt","34445.txt");
        //     // xóa file 
        //     //File.Delete("123.txt");
        //     //FileStream
        //     //=========================FileStream=========================================
        //     string data ="data.txt"; // tên hoặc đường dẫn đến file 
        //     using var stream = new FileStream(path:data,FileMode.OpenOrCreate); // using thì để dùng xong nó tự động giải phóng bộ nhớ mà nó chiếm dữ 
        //     // sử dụng stream lưu dữ liệu
        //     byte [] bodem = {1,2,3,4,5,6};
        //     stream.Write(bodem,0,3);// == ofet : lưu chữ ở vị trí nào trong file , lưu bao nhiêu file 
        //     //Doc du lieu 
        //     var sobytedocduoc = stream.Read(bodem,0,3);
        //     Console.WriteLine(sobytedocduoc); // so byte đọc đc = 0 => con chỏ ở cuối file 
        //     // chuyển đổi kiểu dữ liệu sang byte 
        //     int ggg = 1;  
        //     var kqcovert = BitConverter.GetBytes(ggg);
        //     Console.WriteLine(kqcovert);
        //     // => covert từ byte sang int,double 
        //     BitConverter.ToInt32(kqcovert,0);
        //     string ss = "abc" ; 
        //     var bytes_s = Encoding.UTF8.GetBytes(ss);// chuyển chuỗi sang byte
        //    // đọc byte => string 
        //    Encoding.UTF8.GetString(bytes_s,0,10);
           //===========================Practice===========================================
           string pathProdcut = "Product.txt";
           using var streamProduct = new FileStream(path:pathProdcut,FileMode.Open);
           Product product = new Product(){
            //    ID = 10,
            //    Price = 12345,
            //    Name = "San Pham Abc"
           };
         //  product.Save(streamProduct); // sản phẩm này đc luuw vào đường dẫn
           product.Restore(streamProduct);
           Console.WriteLine($"{product.Name} - {product.Price}- {product.ID}");







        }
    }
}
