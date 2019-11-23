using System;
using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.TextConsole
{
    public class TaxManager
    {
        public List<Tax> Taxes { get; private set; }
        public TaxManager()
        {
            this.Taxes = new List<Tax> { TaxConfiguration.ESP, TaxConfiguration.DEU, TaxConfiguration.FR };  
        }
        public void AddCustomTax(float amount)
        {
            Taxes.Add(Tax.Create("Custom", amount));
        }
        public string GetAllowedIsos()
        {
            var optionColleciton = Taxes.Where(tx => !string.IsNullOrWhiteSpace(tx.IsoCode)).Select(tx => ToIsoOption(tx));
            return string.Join(',',optionColleciton);
        }

        private string ToIsoOption(Tax tax) => string.Format("[{0}]", tax.IsoCode);
    }
}
