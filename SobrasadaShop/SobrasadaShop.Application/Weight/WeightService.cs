using SobrasadaShop.Application.Rules;
using System;
using System.Globalization;

namespace SobrasadaShop.Application.Weight
{
    public class WeightService
    {
        private readonly IRule greaterThanZeroRule;
        public WeightService()
        {
            greaterThanZeroRule = new GreaterThanZeroRule();
        }
        public float ProcessWeight(string weight)
        {
            if(greaterThanZeroRule.IsValid(weight))
            {
                //Unify this
                return float.Parse(weight, NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            throw new ArgumentException(InvalidWeightMessage(weight));
        }
        public string InvalidWeightMessage(string weight) =>
            string.Format("Invalid weight {0}", weight);

        public bool IsValidWeight(string weight) => 
            greaterThanZeroRule.IsValid(weight);
    }
}
