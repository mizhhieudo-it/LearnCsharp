using System;

namespace Bai024_Static_ReadOnly
{
    // indexer : truy cập thông qua chỉ số 
    class CountNumber{
        public static int number = 0 ; 
        public  static void Info()=> Console.WriteLine("So Lan truy cap"+number);
        public void count(){
            number ++ ;
        }
    }
    class Student
    {
        public readonly string name  ; // chỉ đọc , ko đc phép ở bất kì đâu trừ ở trong hàm tao ; 
        public Student(string _name){
         name = _name ; 
        }

    }
    class Vector{
        //indexer 
        public double this[int i]
        {
            set{
                switch(i)
                {
                    case 0: // x 
                        x = value ; 
                        break;
                    case 1: // x 
                        y = value ; 
                        break;
                    default:
                    throw new Exception("Sai Chi So index");
                     
                }

            }
            get{
                switch(i)
                {
                    case 0: // x 
                        return x ;
                    case 1: // x 
                        return y ;
                    default:
                    throw new Exception("Sai Chi So index");
                     
                }

            }
        }
        double x ; 
        double y ;
        public Vector (double _x,double _y){
            x = _x ;
            y = _y ; 
        }
        public void Info()
        {
            Console.WriteLine($"x={x} , y ={y}");
        }
        public static Vector operator+(Vector v1 , Vector v2){
            return new Vector(v1.x+v2.x , v1.y + v2.y);

        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            CountNumber lan1 = new CountNumber();
            lan1.count();
            CountNumber lan2 = new CountNumber();
            lan2.count();
            CountNumber lan3 = new CountNumber();
            lan3.count();
            CountNumber.Info();
            Student s = new Student("Do Minh A");
            Console.WriteLine(s.name);
            Vector a = new Vector(2,3);
            Vector a1 = new Vector(2,3);
            Console.WriteLine(a[1]);
            
            
        }
    }
}
