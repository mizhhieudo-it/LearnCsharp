using System ; 
namespace  MyException
{
    public class NameEx : Exception{
        public NameEx():base("Ten phai khac rong")
        {

        }
        public void Details(){
            Console.WriteLine("Test detail oke");
        }
    }
}