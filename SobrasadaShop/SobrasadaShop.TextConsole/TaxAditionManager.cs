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
                    Console.WriteLine("Insert custom tax: ");
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

        internal int AcquireAmount()
        {
            Console.WriteLine("Insert amount of sobrasadas :");
            int amount = -1;
            bool isValidInput = false;
            
            while (!isValidInput)
            {
                var amountInput = Console.ReadLine();
                isValidInput = int.TryParse(amountInput, out amount);
                //Enter means 1
                if (string.IsNullOrWhiteSpace(amountInput))
                {
                    return 1;
                }
                else if(!isValidInput)
                {
                    Console.WriteLine("Amount should be a valid number");
                }
            }
            return amount;
        }

        public float AcquireWeight()
        {
            Console.WriteLine("Insert sobrasada weight:");
            float currWeight = GetUserInputFloat("Weight must be a valid number");
            return currWeight;
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
            while (!float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture,out result))
            {
                Console.WriteLine(errorMessage);
            }
            return result;
        }
    }
}
