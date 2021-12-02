using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AOC2021.cs
{
    internal class Day2
    {
        public static int Resolve(int _part, string _filename)
        {
            KeyValuePair<string, int>[] data;
            try
            {
                data = File.ReadAllText(_filename)
                    .Split('\n')
                    .Select(s =>
                    {
                        int n;
                        string[] parts = s.Split(' ');
                        return new KeyValuePair<string, int>(
                            parts[0], 
                            int.TryParse(
                                parts.Count() > 1 
                                ? parts[1]
                                : "0", out n) 
                            ? n 
                            : 0);
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
                    return Day2_1(data);
                case 2:
                    return Day2_2(data);
                default:
                    return -1;
            }
        }

        static int Day2_1(KeyValuePair<string, int>[] _dayData)
        {
            int depth = 0;
            int horizontalPosition = 0;
            foreach (KeyValuePair<string, int> kvp in _dayData)
            {
                switch (kvp.Key)
                {
                    case "forward":
                        horizontalPosition += kvp.Value;
                        break;
                    case "up":
                        depth -= kvp.Value;
                        break;
                    case "down":
                        depth += kvp.Value;
                        break;
                    default:
                        break;
                }
            }
            return depth * horizontalPosition;
        }

        static int Day2_2(KeyValuePair<string, int>[] _dayData)
        {
            int depth = 0;
            int horizontalPosition = 0;
            int aim = 0;
            foreach (KeyValuePair<string, int> kvp in _dayData)
            {
                switch (kvp.Key)
                {
                    case "forward":
                        horizontalPosition += kvp.Value;
                        depth += aim * kvp.Value;
                        break;
                    case "up":
                        aim -= kvp.Value;
                        break;
                    case "down":
                        aim += kvp.Value;
                        break;
                    default:
                        break;
                }
            }
            return depth * horizontalPosition;
        }
    }
}
