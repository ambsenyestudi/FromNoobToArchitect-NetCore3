using SobrasadaShop.Application.Rules;
using System;

namespace SobrasadaShop.Application.Amount
{
    public class AmountService
    {
        private readonly IRule emptyAmountRule;
        private readonly IRule greaterThanZeroRule;
        public AmountService()
        {
            emptyAmountRule = new EmptyStringRule();
            greaterThanZeroRule = new GreaterThanZeroRule();
        }
        public int ProcessAmount(string amount)
        {
            if (emptyAmountRule.IsValid(amount))
            {
                return 1;
            }
            if(greaterThanZeroRule.IsValid(amount))
            {
                return int.Parse(amount);
            }
            throw new ArgumentException(InvalidAmountMessage(amount));
        }
        public bool isValidAmount(string amount) =>
            emptyAmountRule.IsValid(amount) || greaterThanZeroRule.IsValid(amount);
        public string InvalidAmountMessage(string amount) =>
            string.Format("Invalid amount {0}", amount);


    }
}
