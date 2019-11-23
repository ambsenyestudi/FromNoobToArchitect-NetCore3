using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SobrasadaShop.Domain.Taxes
{
    public class TaxService
    {
        public IEnumerable<string> GetIsoList(IEnumerable<Tax> taxes) => 
            taxes.Where(tx => !string.IsNullOrWhiteSpace(tx.IsoCode))
            .Select(tx => tx.IsoCode);

        public string Pritify(string item, string format)
            => string.Format(format, item); 
            
    }
}
