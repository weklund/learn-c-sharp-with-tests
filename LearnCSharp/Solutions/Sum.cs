using System.Collections.Generic;

namespace LearnCSharp.Solutions
{
    public class Sum
    {
        public static int Add(IEnumerable<int> numbers)
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        public static IEnumerable<int> AddTails(params int[][] numbers)
        {
            var sums = new int[numbers.Length];

            for (var i = 0; i <= sums.Length - 1; i++)
            {
                if (numbers[i].Length == 0)
                {
                    sums[i] = Add(new[]{0});
                }
                else
                {
                    var tail = numbers[i][1..];
                    sums[i] = Add(tail);
                }
            }

            return sums;
        }
    }
}
