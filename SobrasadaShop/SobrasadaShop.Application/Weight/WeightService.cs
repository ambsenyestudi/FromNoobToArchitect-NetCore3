using SobrasadaShop.Application.Rules;
using System;

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
                return float.Parse(weight);
            }
            throw new ArgumentException(InvalidWeightMessage(weight));
        }
        public string InvalidWeightMessage(string weight) =>
            string.Format("Invalid weight {0}", weight);

        public bool IsValidWeight(string weight) => 
            greaterThanZeroRule.IsValid(weight);
    }
}
