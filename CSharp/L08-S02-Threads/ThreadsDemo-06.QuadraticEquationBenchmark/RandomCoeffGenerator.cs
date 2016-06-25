using System;
using System.Collections;
using System.Collections.Generic;

namespace BelhardTraining.QuadraticEquationBenchmark
{
    class RandomCoeffEnumerator : IEnumerable<Equation>
    {
        public IEnumerator<Equation> GetEnumerator()
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            for (; ; )
            {
                Equation eq = new Equation();
                eq.A = rnd.Next(1, 65000);
                eq.B = rnd.Next(1, 65000);
                yield return eq;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
