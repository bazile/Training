using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCenter.EnumerableDemo
{
    class Program
    {
        static void Main()
        {
            var list = new MyList<string>() { "aaa", "bbb", "ccc" };
            foreach (var item in list)
            {
                Console.WriteLine(item.ToUpper());
            }
        }
    }
}
