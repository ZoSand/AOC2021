using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AOC2021.cs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("December 1st (1):" + Day1.Resolve(1, "./data/day1.txt"));
            Console.WriteLine("December 1st (2):" + Day1.Resolve(2, "./data/day1.txt"));

            Console.Read();
        }
    }
}
