using System;

namespace ConstructorException
{
    class Program
    {
        static void Main()
        {
            Test t = null;
            try
            {
                t = new Test();
            }
            catch
            {
                Console.WriteLine("Caugth exception");
            }

            // Конструктор сгенерировал исключение поэтому переменная будет равна null
            Console.WriteLine(t == null ? "null" : "not null");

            // Память под объект уже была выделена и т.к. у класса Test есть финализатор,
            //  то CLR обязана его выполнить. Поэтому мы увидим на экране текст выводимый финализатором.
        }
    }

    class Test
    {
        public Test()
        {
            throw new Exception();
        }

        ~Test()
        {
            Console.WriteLine("Finalizer");
        }
    }
}
