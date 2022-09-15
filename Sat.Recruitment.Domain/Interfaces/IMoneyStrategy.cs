using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Domain.Interfaces
{
    internal interface IMoneyStrategy
    {
        decimal Calculate(decimal money);
    }
}
