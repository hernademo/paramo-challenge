using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Strategies
{
    internal class SuperUserMoneyStrategy : IMoneyStrategy
    {
        public decimal Calculate(decimal money)
        {
            var result = money;
            decimal gif = 0;

            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.20);
                gif = money * percentage;
            }

            return result + gif;
        }
    }
}
