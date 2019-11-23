using System;
using System.Globalization;
using System.Linq;

namespace SobrasadaShop.TextConsole
{
    public class TaxAditionManager
    {
        private readonly TaxManager taxManager;

        public TaxAditionManager()
        {
            this.taxManager = new TaxManager();
        }
        public Tax AcquireTax()
        {
            string isoOptionsMsg = string.Format("Insert iso code: {0} or press enter to insert custom tax",
                taxManager.GetAllowedIsos());
            Console.WriteLine(isoOptionsMsg);
            bool isValidIso = false;
            while (!isValidIso)
            {
                var currentIso = Console.ReadLine();
                var isEmptyInput = string.IsNullOrWhiteSpace(currentIso);
                if(isEmptyInput)
                {
                    return GetCustomTax();
                }
                else
                {
                    var result = GetIsoTax(currentIso);
                    if(result != null)
                    {
                        return result;
                    }

                }
            }
            return null;

        }

        private Tax GetIsoTax(string iso)
        {
            var result = taxManager.Taxes.Where(tx => tx.IsoCode == iso.ToUpper());
            return result.FirstOrDefault();
        }

        private Tax GetCustomTax()
        {
            float amount = GetUserInputFloat("Invalid tax, try again");
            //Multiple formats 0.04 or 1.04f
            if(amount<1f)
            {
                amount += 1;
            }
            return Tax.Create("Custom",amount);
        }

        private float GetUserInputFloat(string errorMessage)
        {
            float result = -1f;
            Console.WriteLine("Insert custom tax: ");
            while (!float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture,out result))
            {
                Console.WriteLine("Invalid task, try again");
            }
            return result;
        }
    }
}
