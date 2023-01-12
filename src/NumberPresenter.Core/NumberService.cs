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
            if (string.IsNullOrWhiteSpace(input))
            {
                return new NumberResult
                {
                    Success = false,
                    ErrorMessage = "Please enter a value"
                };
            }

            if (int.TryParse(input, out var number))
            {
                return new NumberResult
                {
                    Success = true,
                    Result = number
                };
            }

            return new NumberResult
            {
                Success = false,
                ErrorMessage = "Please enter a valid number"
            };
        }
    }
}
