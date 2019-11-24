using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SobrasadaShop.Application.Rules
{
    public class ItemInListRule : IRule
    {
        private readonly IEnumerable<object> list;

        public ItemInListRule(IEnumerable<object> list)
        {
            this.list = list;
        }
        public bool IsValid(object evaluated)=>
            list.Contains(evaluated);
    }
}
