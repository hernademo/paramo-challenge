using Sat.Recruitment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Strategies
{
    internal class NormalMoneyStrategy : IMoneyStrategy
    {
        public decimal Calculate(decimal money)
        {
            var result = money;
            decimal gif = 0;

            if (money > 100)
            {
                var percentage = Convert.ToDecimal(0.12);
                //If new user is normal and has more than USD100
                gif = money * percentage;
            }
            else
            {
                if (money > 10)
                {
                    var percentage = Convert.ToDecimal(0.8);
                    gif = money * percentage;
                }
            }

            return result + gif;
        }
    }
}
