using System;
using System.Collections.Generic;
using System.Text;

namespace CoinChangeCalculator
{
    public class ChangeCalculatorSimple : IChangeCalculator
    {
        //This version uses simpler algortim but it also uses pre-set denominations so it does not fullfill the requirements of the task however it can work with any money amount.

        public List<int> denominations = new List<int>()
        {
            50,
            20,
            10,
            5,
            2,
            1
        };

        List<int> resultCoins = new List<int>();

        public int Calculate(int moneyAmount)
        {
            resultCoins = new List<int>();

            int result = 0;
            
            int rest = moneyAmount;
            foreach (var den in denominations)
            {
                if (den > rest)
                {
                    continue;
                }

                int coins = rest / den;
                rest = rest % den;

                result += coins;

                for (int i = 0; i < coins; i++)
                {
                    resultCoins.Add(den);
                }

                if (rest == 0)
                {
                    break;
                }
            }

            if (rest > 0)
            {
                return -1;
            }
            else
            {
                return result;
            }
        }

        public List<int> GetResultCoins()
        {
            return resultCoins;
        }

        public void SetDenominations(List<int> _denominations)
        {
            //this.denominations = _denominations;
        }
    }
}
