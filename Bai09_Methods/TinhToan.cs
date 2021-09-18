using System;
namespace CS009 {
    public class Tinhtoan{
        public static int sum(int a,int b){
            return a+b;
        }
        //overloading: cùng tên , khác kiểu tham số truyền vào
        public static float sum(float a,float b){
            return a+b;
        }
    }
}