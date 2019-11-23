using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.Application.Rules
{
    public class EmptyStringRule : IRule
    {
        
        public bool IsValid(object evaluated)
        {
            if(evaluated!=null)
            {
                var evalString = evaluated as string;
                return string.IsNullOrEmpty(evalString);
            }
            return true;
        }
    }
}
