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
            //var list = new MyList();
            //var list = new MyList() { "aaa" };
            var list = new MyList() { "aaa", "bbb", "ccc" };
            foreach (string item in list)
            {
                Console.WriteLine(item.ToUpper());
            }
            Console.WriteLine();

            // Класс MyList реализует необобщенный вариант IEnumerable
            // Значит свойство Current имеет тип object и значит цикл foreach будет использовать его
            // Обратите внимание что в предыдущем foreach тип указан явно. В этом случае foreach выполняет приведение типа
            foreach (var item in list)
            {
                //Console.WriteLine(item.ToUpper()); // Ошибка компиляции т.к. item имеет тип object
                Console.WriteLine(((string)item).ToUpper());
            }
        }
    }
}
