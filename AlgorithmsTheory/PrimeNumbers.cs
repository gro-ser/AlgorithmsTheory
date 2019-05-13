using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace AlgorithmTheory
{
    public static class PrimeNumbers
    {
        static List<Num> primes = new List<Num>() { 2u, 3u, 5u, 7u };

        static public Num GetPrimeNumber(Num index)
            => GetPrimeNumber((int)index);

        static public Num GetPrimeNumber(int index) // TODO REDO algorithm
        {
            int count = primes.Count;
            while (index >= count)
            {
                Num last = primes[count - 1];
                bool exit;
                do
                {
                    exit = false;
                    last += Num.Two;
                    for (int i = 0; i < count; i++)
                        if ((last % primes[i]).IsZero)
                        { exit = true; break; }
                }
                while (exit);
                primes.Add(last);
                ++count;
            }
            return primes[index];
        }
    }
}
