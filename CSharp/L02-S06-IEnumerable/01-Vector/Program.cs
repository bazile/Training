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
            Vector x = new Vector(3);
            x[0] = 1.1; x[1] = 1.2; x[2] = 1.3;
            Vector y = new Vector(3);
            y[0] = 10.1; y[1] = 10.2; y[2] = 10.3;
            Vector z = x + y;
            foreach (double num in z)
            {
                Console.WriteLine(num);
            }
        }
    }
}
