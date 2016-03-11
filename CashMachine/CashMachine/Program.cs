using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashMachine
{
    class CashMachine
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Write sum of coins:");
            int sum = 0;
            while (sum <= 0)
            {
                try
                {
                    sum = Convert.ToInt32(Console.ReadLine());
                    if (sum <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Sum must be positive integer number");
                    Console.WriteLine("Try again:");
                }
            }
            Console.WriteLine("Write coins (must be positive integer, separator = space)");
            string[] coinsArr;
            List<int> coins = new List<int>();
            bool inputOk = false;
            while (!inputOk)
            {
                try
                {
                    coinsArr = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    coins = new List<int>();
                    foreach (string s in coinsArr)
                    {
                        int coin = Convert.ToInt32(s);
                        if (coin <= 0)
                        {
                            throw new Exception();
                        }
                        coins.Add(coin);
                    }
                    inputOk = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong input format");
                    Console.WriteLine("Try again:");
                }
            }
            

            List<int[]> options = getOptionsToChange(sum, coins);

            Console.WriteLine("Changes for {0} :", sum);
            foreach (int[] change in options) {
                for (int i = 0; i < change.Length; i++) {
                    Console.Write(coins.ElementAt(i) + "x" + change[i] + "  ");
                }
                Console.WriteLine();
            }
        
        }

        public static List<int[]> getOptionsToChange(int sum, List<int> coins)
        {
            List<int[]> options = new List<int[]>();
            int[] countOfEach = new int[coins.Count];
            coins.Sort(new Comparison<int>((i1, i2) => i2.CompareTo(i1))); //reverse sort with lambda
            getOptionsToChange(sum, options, countOfEach, coins, 1);
            return options;
        }

        private static void getOptionsToChange(int sum, List<int[]> options, int[] countOfEach, List<int> coins, int numOfCurrentCoin)
        {
            if ((numOfCurrentCoin <= coins.Count) && (sum > 0))
            {
                getOptionsToChange(sum, options, countOfEach, coins, numOfCurrentCoin + 1);
                while (sum >= coins.ElementAt(numOfCurrentCoin - 1))
                {
                    sum -= coins.ElementAt(numOfCurrentCoin - 1);
                    countOfEach[numOfCurrentCoin - 1]++;
                    getOptionsToChange(sum, options, countOfEach, coins, numOfCurrentCoin + 1);
                }
                if (sum == 0)
                {
                    options.Add((int[]) countOfEach.Clone());
                }
                countOfEach[numOfCurrentCoin - 1] = 0;
            }
        }
    }
}