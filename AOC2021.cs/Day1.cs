using System;
using System.IO;
using System.Linq;

namespace AOC2021.cs
{
    internal class Day1
    {
        public static int Resolve(int _part, string _filename)
        {
            int[] data;
            try
            {
                data = File.ReadAllText(_filename)
                    .Split('\n')
                    .Select(s =>
                    {
                        int n;
                        return int.TryParse(s, out n) ? n : 0;
                    })
                    .ToArray();
            }
            catch (Exception)
            {

                return -1;
            }

            switch (_part)
            {
                case 1:
                    return Day1_1(data);
                case 2:
                    return Day1_2(data);
                default:
                    return -1;
            }
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
