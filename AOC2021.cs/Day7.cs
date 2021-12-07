using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.cs
{
    internal class Day7
    {
        public static int Resolve(int _part, string _filename)
        {
            int[] input = File.ReadAllText(_filename)
                .Split(',')
                .Select(i => { return int.TryParse(i, out int o) ? o : 0; })
                .ToArray();
            switch (_part)
            {
                case 1: return Day7_1(input);
                case 2: return Day7_2(input);
                default:
                    return -1;
            }
        }

        static int Day7_1(int[] _input)
        {
            Array.Sort(_input);
            return _input.Sum(i => Math.Abs(i - _input[_input.Length / 2]));
        }

        static int Day7_2(int[] _input)
        {
            return _input.Min((i) => _input.Select(num => Math.Abs(num - i)).Select(dis => dis * (dis + 1) / 2).Sum());
        }
    }
}
