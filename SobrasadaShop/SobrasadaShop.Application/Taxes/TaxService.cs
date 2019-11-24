using SobrasadaShop.Application.DTO;
using SobrasadaShop.Application.Rules;
using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.Application.Taxes
{
    public class TaxService
    {
        private readonly EmptyStringRule emptyTaxRule;
        private readonly GreaterThanZeroRule greaterThanZeroRule;

        public TaxService()
        {
            this.emptyTaxRule = new EmptyStringRule();
            this.greaterThanZeroRule = new GreaterThanZeroRule();
        }
        public bool isValidTaxAmount(string taxAmount) =>
            greaterThanZeroRule.IsValid(taxAmount);
        public bool isValidTax(string input, IEnumerable<TaxDTO> validTaxes)
        {
            var validInput = emptyTaxRule.IsValid(input);
            if(!validInput)
            {
                var inListRule = new ValidIsoRule(validTaxes);
                inListRule.IsValid(input);
            }
            return validInput;
        }

        public IEnumerable<string> GetIsoList(IEnumerable<TaxDTO> taxes) =>
            taxes.Where(tx => !string.IsNullOrWhiteSpace(tx.IsoCode))
            .Select(tx => tx.IsoCode);

        public string Pritify(string item, string format)
            => string.Format(format, item);
    }
}
