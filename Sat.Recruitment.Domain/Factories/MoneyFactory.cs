using Sat.Recruitment.Domain.Interfaces;
using Sat.Recruitment.Domain.Strategies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Factories
{
    internal static class MoneyFactory
    {
        private static Dictionary<string, IMoneyStrategy> _strategies = new Dictionary<string, IMoneyStrategy>
        {
            { "Super", new SuperUserMoneyStrategy() },
            { "Premium", new PremiumMoneyStrategy() },
            { "Normal", new NormalMoneyStrategy() },
        };

        public static IMoneyStrategy Get(string key)
        {
            if (key != String.Empty && _strategies.ContainsKey(key))
            {
                return _strategies[key];
            }

            throw new Exception("key not found");            
        }
    }
}
