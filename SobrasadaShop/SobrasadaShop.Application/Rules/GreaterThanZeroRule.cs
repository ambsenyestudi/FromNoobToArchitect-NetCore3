namespace SobrasadaShop.Application.Rules
{
    public class GreaterThanZeroRule : IRule
    {
        public bool IsValid(object evaluated)
        {
            var evalString = evaluated as string;
            if(evaluated !=null)
            {
                double d = 0;
                return double.TryParse(evalString, out d) && d > 0;
            }
            return false;
        }
    }
}
