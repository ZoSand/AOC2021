using System;

namespace AOC2021.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("December 1st (1):" + Day1.Resolve(1, "./data/day1.txt"));
            Console.WriteLine("December 1st (2):" + Day1.Resolve(2, "./data/day1.txt"));

            Console.WriteLine("December 2nd (1):" + Day2.Resolve(1, "./data/day2.txt"));
            Console.WriteLine("December 2nd (2):" + Day2.Resolve(2, "./data/day2.txt"));

            Console.Read();
        }
    }
}
