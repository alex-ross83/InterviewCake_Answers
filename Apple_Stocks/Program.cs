using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple_Stocks
{
    class Program
    {
        static void Main(string[] args)
        {

            var stock_price_yesterday = InitializeRegularDay();
            //var stock_price_yesterday = InitializeDownDay();
            
            //get_max_profit_brute_force(stock_price_yesterday);//Run time = O(n^2)

            //get_max_profit_next_higher(stock_price_yesterday);

            get_max_profit_O_n_time(stock_price_yesterday);

            Console.ReadLine();
        }

        private static void get_max_profit_O_n_time(int[] stock_price_yesterday)
        {
            var minPrice = 0;
            var maxProfit = 0;
            for (int i = 0; i < stock_price_yesterday.Length; i++)
            {
                if (i == 0)
                {
                    minPrice = stock_price_yesterday[0];
                    maxProfit = stock_price_yesterday[1] - stock_price_yesterday[0];
                    continue;
                }
                if (stock_price_yesterday[i] == 0)
                {
                    continue;
                }
                if (stock_price_yesterday[i] < minPrice)
                {
                    minPrice = stock_price_yesterday[i];
                }
                
                if ((stock_price_yesterday[i] - minPrice) > maxProfit)
                {
                    maxProfit = stock_price_yesterday[i] - minPrice;
                }
            }
            Console.WriteLine("O(n) time: \tBest Profit was:{0}", maxProfit);
        }

        private static void get_max_profit_next_higher(int[] stock_price_yesterday)
        {
            var max = 0;
            for(int i = 0; i < stock_price_yesterday.Length; i++)
            {
                //check we don't overflow
                if (i + 1 < stock_price_yesterday.Length)
                {
                    for (int j = i + 1; j < stock_price_yesterday.Length; j++)
                    {
                        if (stock_price_yesterday[j] == 0 || stock_price_yesterday[i] == 0) //no record at these times
                        {
                            continue;
                        }
                        var profit = stock_price_yesterday[j] - stock_price_yesterday[i];
                        if (profit > max)
                        {
                            max = profit;
                        }
                    }
                }
            }
            Console.WriteLine("Next Higher: \tBest Profit was:{0}", max);
        }

        

        public static void get_max_profit_brute_force(int[] stock_price_yesterday)
        {
            var max = 0;
            var minTime = 0;
            var maxTime = 0;
            for (int i = 0; i < stock_price_yesterday.Length; i++)
            {
                for (int j = 0; j < stock_price_yesterday.Length; j++)
                {
                    if (i>j)
                    {
                        minTime = j;
                        maxTime = i;
                    }
                    else
                    {
                        minTime = i;
                        maxTime = j;
                    }
                    var buyStock = stock_price_yesterday[minTime];
                    var sellStock = stock_price_yesterday[maxTime];
                    if (buyStock == 0 || sellStock == 0) //no record at this times
                    {
                        continue;
                    }
                    var profit = sellStock - buyStock;
                    if (profit > max)
                    {
                        max = profit;
                    }
                }
            }
            Console.WriteLine("Brute Force: \tBest Profit was:{0}", max);
        }

        public static int[] InitializeRegularDay()
        {
            var result = new int[100];
            result[0] = 100;
            result[10] = 450;
            result[60] = 500;
            result[70] = 550;
            result[80] = 450;
            result[90] = 450;
            result[99] = 550;
            return result;
        }

        public static int[] InitializeDownDay()
        {
            var result = new int[100];
            result[0] = 1000;
            result[10] = 900;
            result[60] = 800;
            result[70] = 700;
            result[80] = 500;
            result[90] = 450;
            result[99] = 250;
            return result;
        }
    }
}
