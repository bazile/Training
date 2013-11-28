using System;
using System.ServiceModel;
using BelhardTraining.FamousQuote.Service;

namespace BelhardTraining.FamousQuote
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = new Uri("http://localhost:1234/SingleQuote");
            var serviceType = typeof(FamousQuoteService);
            var binding = new BasicHttpBinding();
            var host = new ServiceHost(serviceType, baseAddress);
            //host.Description.Endpoints.Clear();//This line is added for convenience (and allows you to leave the app.config as-is.
            host.AddServiceEndpoint(typeof(IFamousQuote), binding, "SingleQuote");

            host.Open();
            Console.WriteLine(baseAddress);
            Console.WriteLine("Сервис запущен: Нажмите <Ввод> для выхода");
            Console.ReadLine();
        }
    }
}
