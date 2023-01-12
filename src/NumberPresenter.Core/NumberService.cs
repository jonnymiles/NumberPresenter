using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberPresenter.Core
{
    public class NumberService : INumberService
    {
        public NumberResult ExtractNumber(string input)
        {
            return new NumberResult
            {
                Success = true,
                Result = 123456
            };
        }
    }
}
