using System;
using System.Collections.Generic;
using System.Linq;

namespace CarnegieBraveheart
{
    class Program
    {
        static void Main(string[] args)
        {
            string CMU = "Carnegie Mellon University".Replace(" ", "").ToLower();
            string BH = "Braveheart".Replace(" ", "").ToLower();

            string letters = "abcdefghijklmnopqrstuvwxyz";

            List<(char, int, int)> results = new List<(char l, int c, int b)>();

            foreach(char l in letters)
            {
                int CMU_Count = CMU.Count(x => x == l);
                int BH_Count = BH.Count(x => x == l);

                results.Add((l, CMU_Count, BH_Count));
            }

            var Equal = results.Where(x => x.Item2 == x.Item3);
            var Contain = results.Where(x => x.Item2 > 0 && x.Item3 > 0);
            var EqualMinOne = Equal.Where(x => x.Item2 > 0);
            var NotContain = Equal.Where(x => x.Item2 == 0);

            Console.WriteLine($"Both contain the letters {string.Join(", ", Contain.Select(x => x.Item1))}");
            Console.WriteLine($"Both contain the same number of the letters {string.Join(", ", EqualMinOne.Select(x => x.Item1))}");
            Console.WriteLine($"Both contain no copies of the letters {string.Join(", ", NotContain.Select(x => x.Item1))}");
        }
    }
}

