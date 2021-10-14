using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinChangeCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> denominations = new List<int>();

            bool stop = false;
            while (stop == false)
            {
                Console.WriteLine("Please enter coin denomination. Empty line to stop.");
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    stop = true;
                }
                else
                {
                    int value;
                    if (int.TryParse(line, out value) == false)
                    {
                        Console.WriteLine("Invalid input. Please enter an integer and press enter!");
                    }
                    else
                    {
                        denominations.Add(value);
                    }
                }
            }

            Console.Write("Coin denominations: ");
            denominations
                .OrderBy(x => x)
                .ToList()
                .ForEach(x =>
            {
                Console.Write(string.Format("{0}, ", x));
            });

            IChangeCalculator calculator = new ChangeCalculatorV2();
            calculator.SetDenominations(denominations);

            Console.WriteLine();
            Console.WriteLine("Please enter money amount! Enter Q to quit");
            bool quit = false;
            
            while (true)
            {
                int moneyAmount = 0;

                while (true)
                {
                    var line = Console.ReadLine();

                    if (line.ToLower() == "q")
                    {
                        quit = true;
                        break;
                    }

                    if (int.TryParse(line, out moneyAmount) == false)
                    {
                        Console.WriteLine("Invalid input. Please enter an integer and press enter!");
                    }
                    else
                    {
                        break;
                    }
                }

                if (quit == true)
                {
                    break;
                }

                var result = calculator.Calculate(moneyAmount);

                if (result == -1)
                {
                    Console.WriteLine(result);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    var coins = calculator.GetResultCoins();
                    coins.ForEach(x =>
                    {
                        sb.Append(string.Format("{0}+", x));
                    });
                    string coinResult = sb.ToString().TrimEnd('+');

                    Console.WriteLine(string.Format("{0} ({1})", result, coinResult));
                }
            }
        }
    }
}
