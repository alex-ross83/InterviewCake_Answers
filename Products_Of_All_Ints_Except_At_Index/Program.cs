using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products_Of_All_Ints_Except_At_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[] { 1, 7, 3, 4,0 };
            var result = get_products_of_all_ints_except_at_index(input);
            for (int i = 0; i < result.Length; i++)
            {
                Console.WriteLine(result[i]);
            }
            Console.ReadLine();
        }
        public static int[] get_products_of_all_ints_except_at_index(int[] input)
        {
            var len = input.Length;
            var result = new int[len];
            int i = 0;
            int product = 1;
            while (i < len)
            {
                if (input[i] == 0)
                {
                    i += 1;
                    continue;
                }
                result[i] = product;
                product *= input[i];
                i += 1;
            }
            i = len-1;
            product = 1;
            while (i >= 0)
            {
                if (input[i] == 0)
                {
                    i -= 1;
                    continue;
                }
                result[i] *= product;
                product *= input[i];
                i--;
            }

            return result;
        }
    }
}
