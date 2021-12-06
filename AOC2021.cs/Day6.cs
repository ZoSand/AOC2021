using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AOC2021.cs
{
    class Day6
    {
        public static long Resolve(int _part, string _filename)
        {
            int[] data;
            try
            {
                data = File.ReadAllText(_filename)
                    .Split(',')
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
                    return Day6_1(data);
                case 2:
                    return Day6_2(data);
                default:
                    return -1;
            }
        }

        static long Day6_1(int[] _dayData)
        {
            return NumberOfFishesAfter(80, _dayData);
        }

        static long Day6_2(int[] _dayData)
        {
            return NumberOfFishesAfter(256, _dayData);
        }

        static long NumberOfFishesAfter(long _numberOfDays, int[] _dayData)
        {
            const long maxage = 8;
            long[] age = new long[maxage + 1];
            foreach (long i in _dayData)
            {
                age[i]++;
            }

            for (long i = 0; i < _numberOfDays; i++)
            {
                long a0 = age[0];
                for (long j = 1; j <= maxage; j++)
                {
                    age[j - 1] = age[j];
                    age[j] = 0;
                }
                age[8] += a0;
                age[6] += a0;
            }

            long e = 0;
            for (long j = 0; j <= maxage; j++) e += age[j];
            return e;
        }
    }
}
