using System;

namespace TrainingCenter.ExceptionsDemo
{
    class Program
    {
        static void Main()
        {
            PrintHelp();

            Console.Write("Введите что-нибудь: ");
            string text = Console.ReadLine();
            int n = int.Parse(text);
            Console.WriteLine("Введено число: " + n);
        }

        static void PrintHelp()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("В случае возникновения необработанного исключения консольное приложение завершит свою работу.");
            Console.WriteLine("Перед этим в консоль будет напечатана информация об исключении: тип, сообщение и трассировка стека.");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Попробуйте ввести число, пустую строку, строку которую нельзя перевести в int или очень большое число.");
            Console.WriteLine();
        }
    }
}
