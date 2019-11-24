using SobrasadaShop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.Application.Rules
{
    public class ValidIsoRule : IRule
    {
        private readonly IEnumerable<TaxDTO> taxes;

        public ValidIsoRule(IEnumerable<TaxDTO> taxes)
        {
            this.taxes = taxes;
        }
        public bool IsValid(object evaluated)
        {
            var stringEval = evaluated as string;
            if (string.IsNullOrWhiteSpace(stringEval))
            {
                taxes.Where(tx => tx.IsoCode == stringEval.ToUpper());
            }
            return false;
        }
    }
}
