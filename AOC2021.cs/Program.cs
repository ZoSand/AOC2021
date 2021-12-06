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

            Console.WriteLine("December 3rd (1):" + Day3.Resolve(1, "./data/day3.txt"));
            Console.WriteLine("December 3rd (2):" + Day3.Resolve(2, "./data/day3.txt"));

            /*
            Console.WriteLine("December 4th (1):" + Day4.Resolve(1, "./data/day4.txt"));
            Console.WriteLine("December 4th (2):" + Day4.Resolve(2, "./data/day4.txt"));
                                                       
            Console.WriteLine("December 5th (1):" + Day5.Resolve(1, "./data/day5.txt"));
            Console.WriteLine("December 5th (2):" + Day5.Resolve(2, "./data/day5.txt"));
            */

            Console.WriteLine("December 6th (1):" + Day6.Resolve(1, "./data/day6.txt"));
            Console.WriteLine("December 6th (2):" + Day6.Resolve(2, "./data/day6.txt"));

            Console.Read();
        }
    }
}
