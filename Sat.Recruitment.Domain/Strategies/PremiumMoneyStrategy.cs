using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Strategies
{
    internal class PremiumMoneyStrategy : IMoneyStrategy
    {
        public decimal Calculate(decimal money)
        {
            var result = money;
            decimal gif = 0;

            if (money > 100)
            {
                gif = money * 2;
            }

            return result + gif;
        }
    }
}
