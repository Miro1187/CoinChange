using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinChangeCalculator
{
    public class ChangeCalculatorV2 : IChangeCalculator
    {
        List<int> denominations = new List<int>();

        List<int> resultCoins = new List<int>();

        public int Calculate(int moneyAmount)
        {
            resultCoins = new List<int>();

            int result = RecursiveCalculate(moneyAmount, 0);

            return result;
        }

        private int RecursiveCalculate(int rest, int denomIndex)
        {
            var result = rest / denominations[denomIndex];//Max number of coins of current denomination that can fit into hte current money amount
            rest = rest % denominations[denomIndex];//Rest of the money that must be filled by coins of lower denominations.

            if (result > 0)
            {
                for (int i = 0; i < result; i++)
                {
                    resultCoins.Add(denominations[denomIndex]);
                }
            }

            if (rest > 0)
            {
                if (denomIndex < denominations.Count - 1)
                {
                    var recRes = RecursiveCalculate(rest, denomIndex + 1);
                    while (recRes == -1 && result > 0)
                    {
                        //If the rest can not be filled by lower denominations remove coins of current denomination one by one and try again to fill the rest with lower denominations
                        resultCoins.RemoveAt(resultCoins.Count() - 1);
                        result -= 1;
                        rest += denominations[denomIndex];

                        recRes = RecursiveCalculate(rest, denomIndex + 1);
                    }

                    result += recRes;
                }
                else
                {
                    for (int i = 0; i < result; i++)
                    {
                        resultCoins.RemoveAt(resultCoins.Count() - 1);
                    }
                    result = -1;
                }
            }

            return result;
        }

        public List<int> GetResultCoins()
        {
            return resultCoins;
        }

        public void SetDenominations(List<int> _denominations)
        {
            this.denominations = _denominations;

            this.denominations = denominations.OrderByDescending(x => x).ToList();
        }
    }
}
