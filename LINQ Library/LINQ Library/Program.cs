using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Library
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> list = new List<int> { 3, 6, 7, 9, 6, 10, 2, 11 };
            ////int[] arr = { 6, 8, 4, 1, 2, 3 };
            ////list = arr.MyToList();
            ////var m = list.MyWhere(x => x==6);
            //var m = list.GroupBy(x => x * 2);

            //foreach (var item in m)
            //{
            //    list.GroupBy(x => x * 2);
            //}

           

            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("h", 5);
            dic.Add("a", 1);
            dic.Add("g", 6);
            dic.Add("l", 6);

            var x = dic.MyGroupBy(s => s.Value);
            foreach (var item in x)
            {
                Console.WriteLine(item.Key);
            }

            Console.ReadLine();
        }



        
    }

  
}
