using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AoC2021.cs
{
    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
    }

    internal class Program
    {
        static string[] filename = new string[1] { "./data/day1.txt" };

        static void Main(string[] args)
        {
            int[] dayOneData = File.ReadAllText(filename[0])
                .Split('\n')
                .Select(s =>
                {
                    int n;
                    return int.TryParse(s, out n) ? n : 0;
                })
                .ToArray();

            Console.WriteLine("December 1st (1):" + Day1_1(dayOneData));
            Console.WriteLine("December 1st (2):" + Day1_2(dayOneData));

            Console.Read();
        }

        static int Day1_1(int[] _dayData)
        {
            int result = 0;
            int previous = _dayData[0];
            foreach (int current in _dayData)
            {
                if (current > previous)
                {
                    result++;
                }
                previous = current;
            }
            return result;
        }
        static int Day1_2(int[] _dayData)
        {
            int result = 0;
            int previous = _dayData.SubArray(0, 3).Sum();
            for (int i = 0; i < _dayData.Length; i++)
            {
                int actual = i + 3 > _dayData.Length ? 0 : _dayData.SubArray(i, 3).Sum();
                if (actual > previous)
                {
                    result++;
                }
                previous = actual;
            }
            return result;
        }
    }
}
