using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighestProductOfThree
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 10, -5, 1, -100 };
            var result = get_highest_product_of_three(input);
            Console.WriteLine(result);
            Console.ReadLine();
        }

        private static int get_highest_product_of_three(int[] input)
        {
            if (input.Length < 3)
            {
                throw new Exception("Need more than 2 numbers!");
            }
            var highest_product_of_three = input[0] * input[1] * input[2];
            var highest_product_of_two = Math.Max(input[0], input[1]);
            var highest = Math.Max(input[0], Math.Max(input[1], input[2]));
            var lowest_product_of_two = Math.Min(input[0] * input[1],
                Math.Min(input[0] * input[2], input[1] * input[2]));
            var lowest = Math.Min(input[0], Math.Min(input[1], input[2]));
            var current = 0;
            for (int i = 3; i < input.Length; i++)
            {
                current = input[i];
                highest_product_of_three =
                    Math.Max(highest_product_of_three,
                                Math.Max(current * highest_product_of_two, 
                                        current * lowest_product_of_two));
                highest_product_of_two =
                    Math.Max(highest_product_of_two,
                                 Math.Max(highest * current, 
                                            lowest * current));
                lowest_product_of_two =
                    Math.Min(lowest_product_of_two,
                             Math.Min(lowest * current, 
                                      current * highest));
                if (current > highest)
                {
                    highest = current;
                }
                if (current < lowest)
                {
                    lowest = current;
                }

            }
            return highest_product_of_three;
        }
    }
}
