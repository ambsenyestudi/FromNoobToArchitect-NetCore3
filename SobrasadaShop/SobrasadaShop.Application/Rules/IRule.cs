using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.Application.Rules
{
    public interface IRule
    {
        
        bool IsValid(object evaluated);
    }
}
