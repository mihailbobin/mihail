using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam1project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetRepresentations = 3;
            long limit = 100000000;
            var cubeSums = new Dictionary<long, List<Tuple<long, long>>>();
            for (long a = 1; a * a * a < limit; a++)
            {
                for (long b = a; a * a * a + b * b * b < limit; b++)
                {
                    long sum = a * a * a + b * b * b;
                    if (!cubeSums.ContainsKey(sum))
                    {
                        cubeSums[sum] = new List<Tuple<long, long>>();
                    }
                    cubeSums[sum].Add(Tuple.Create(a, b));
                }
            }
            bool found = false;
            foreach (var entry in cubeSums)
            {
                if (entry.Value.Count == targetRepresentations)
                {
                    Console.WriteLine($"T(3) = {entry.Key}");
                    Console.WriteLine("Представления:");
                    foreach (var pair in entry.Value)
                    {
                        Console.WriteLine($"{entry.Key} = {pair.Item1}^3 + {pair.Item2}^3");
                    }
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("Не найдено число с указанным количеством представлений.");
            }
            Console.ReadKey();
        }
    }
}