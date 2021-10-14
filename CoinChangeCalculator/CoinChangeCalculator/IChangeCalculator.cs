using System.Collections.Generic;

namespace CoinChangeCalculator
{
    public interface IChangeCalculator
    {
        void SetDenominations(List<int> denominations);
        List<int> GetResultCoins();
        int Calculate(int moneyAmount);
    }
}