using System;
using System.Collections;
using System.Collections.Generic;

namespace Bai27_Queue
{
    class Program
    {
        //Queu : vào trước ra trước
        static void Main(string[] args)
        {
            Queue<string> HoSo = new Queue<string>();
            // vào xếp hàng , đưa phần tử vào cuối hàng đợi . ai vào trc thì xử lý trc : thêm thì vào cuối , bớt thì lên làm đầu

            HoSo.Enqueue("Hồ Sơ 1");
            HoSo.Enqueue("Hồ Sơ 2");
            HoSo.Enqueue("Hồ Sơ 3");
            // trả về pt đầu
            var hs1 = HoSo.Dequeue();
            Console.WriteLine($"xử lý hồ sơ : {hs1} - {HoSo.Count}");
            //Stack : xếp đồ : vào sau ra trước ( như hành động xếp đồ vào hộp)
            Stack<String> HangHoa = new Stack<string>();
            HangHoa.Push("mat hang 1");
            HangHoa.Push("mat hang 2");
            HangHoa.Push("mat hang 3");
            var mh = HangHoa.Pop();
            Console.WriteLine("Boc do"+mh);
            mh = HangHoa.Pop();
            Console.WriteLine("Boc do"+mh);
            mh = HangHoa.Pop();
            Console.WriteLine("Boc do"+mh);
            //=> vào sau thì ra trước 
            //LinkedList 
            LinkedList<string> BaiHoc = new LinkedList<string>();
            //thêm phần tử 
            var bh1 = BaiHoc.AddFirst("Bai Hoc Dau");// THEM DAU
            var bt2 = BaiHoc.AddAfter(bh1,"BH 2"); // THEM SAU NOT BH1
            var bh5 = BaiHoc.AddLast("Bai Hoc KT"); // THEM CUOI 
            // in ra dữ liệu node 
            var node = bt2 ;
            // truy cập bài học sau 
            node = node.Next;
            foreach (var item in BaiHoc)
            {
             Console.WriteLine(item);   
            }
            // kiểu dữ liệu Dictionary 
            Dictionary<string,int> demso = new Dictionary<string, int>()
            {
                ["one"] = 1,
                ["two"] = 2 
            };
            // thêm hawojc cập nhật
            demso["three"] = 3 ;
            var keys = demso.Keys ; // return all key 
            foreach (var item in keys)
            {
                var value = demso[item];
                Console.WriteLine(value);
                
            }
            HashSet<int> set1 = new HashSet<int>(){
                1,2,4,6,7
            };
            HashSet<int> set2 = new HashSet<int>(){
                1,2,4,5,6,7
            };
            // thêm 1 phần tử 
            set1.Add(1);
            // phép hợp 
            set1.UnionWith(set2);
            foreach (var item in set1)
            {
                Console.WriteLine(item);
                
            }
            //phép giao
            set1.IntersectWith(set2);
        }
    }
}
