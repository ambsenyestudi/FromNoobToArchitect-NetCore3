using SobrasadaShop.Domain.Taxes;
using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.TextConsole
{
    public class TaxManager
    {
        private readonly TaxService taxService;

        public List<Tax> Taxes { get; private set; }
        public TaxManager()
        {
            taxService = new TaxService();
            this.Taxes = new List<Tax> { TaxConfiguration.ESP, TaxConfiguration.DEU, TaxConfiguration.FR };  
        }
        public void AddCustomTax(float amount)
        {
            Taxes.Add(Tax.Create("Custom", amount));
        }
        public string GetAllowedIsos() 
        {
            var optionColleciton = taxService.GetIsoList(Taxes)
                .Select(iso=>taxService.Pritify(iso, "[{0}]"));
            return string.Join(',',optionColleciton);
        }

    }
}
