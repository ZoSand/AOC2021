using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2021.cs
{
    internal class Day3
    {
        public static int Resolve(int _part, string _filename)
        {
            string[] data = File.ReadAllText(_filename)
                                .Split('\n')
                                .ToArray();

            switch (_part)
            {
                case 1: return Day3_1(data);
                case 2: return Day3_2(data);
                default: return -1;
            }
        }

        static int Day3_1(string[] _input)
        {
            int[][] data = _input.Select(s => s.ToCharArray()
                                               .Select(c => c - 48)
                                               .ToArray())
                                 .ToArray();
            char[] gammaDigits = new char[data.Last().Length];
            char[] epsilonDigits = new char[data.Last().Length];
            int gamma = 0;
            int epsilon = 0;
            for (int digit = 0; digit < data.Last().Length; digit++)
            {
                int d = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    d += data[i][digit];
                }
                gammaDigits[digit] = d > data.Length / 2 ? '1' : '0';
                epsilonDigits[digit] = d < data.Length / 2 ? '1' : '0';
            }
            gamma = Convert.ToInt32(new string(gammaDigits), 2);
            epsilon = Convert.ToInt32(new string(epsilonDigits), 2);
            return gamma * epsilon;
        }
        static int Day3_2(string[] _input)
        {
            int[][] data = _input.Select(s => s.ToCharArray()
                                               .Select(c => c - 48)
                                               .ToArray())
                                 .ToArray();

            int oxygenRate = FindCriteria(data, true);
            int co2Rate = FindCriteria(data, false);

            return oxygenRate * co2Rate;
        }

        static int FindCriteria(int[][] _data, bool _criteria)
        {
            List<int[]> temp = _data.ToList();
            int currentDigit = 0;
            do
            {
                int bit1count = temp.Sum(l => l[currentDigit]);
                int currentBit = 0;
                if (temp.Count % 2 == 0 && bit1count == temp.Count / 2)
                {
                    currentBit = _criteria ? 1 : 0;
                }
                else if ((bit1count > temp.Count / 2))//&& criteria)
                {
                    currentBit = _criteria ? 1 : 0;
                }
                else currentBit = _criteria ? 0 : 1;

                temp = temp.Where(l => l[currentDigit] == currentBit).ToList();

                currentDigit++;
            } while (temp.Count > 1);
            if (temp.Last().Length > _data.Last().Length)
            {
                temp[0] = temp.Last()
                              .Take(temp.Last().Length - (temp.Last().Length - _data.Last().Length))
                              .ToArray();
            }
            return Convert.ToInt32(
                new string(
                    temp.First()
                    .Select(
                        d => (char)((d == 1 || d == 0) ? d + 48 : 0)
                        )
                    .ToArray()), 2);
        }
    }
}
