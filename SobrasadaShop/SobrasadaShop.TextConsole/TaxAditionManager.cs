using SobrasadaShop.Application.Amount;
using SobrasadaShop.Application.Weight;
using SobrasadaShop.Domain.Baskets;
using SobrasadaShop.Domain.Taxes;
using System;
using System.Globalization;
using System.Linq;

namespace SobrasadaShop.TextConsole
{
    public class TaxAditionManager
    {
        private readonly Basket basket;
        private readonly TaxManager taxManager;
        private readonly AmountService amountService;
        private readonly WeightService weightService;

        public TaxAditionManager()
        {
            this.basket = new Basket();
            this.taxManager = new TaxManager();
            this.amountService = new AmountService();
            this.weightService = new WeightService();
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

        public int AcquireAmount()
        {
            Console.WriteLine("Insert amount of sobrasadas :");
            var amountInput = RetryWhileInvalidInput(amountService.isValidAmount);
            return amountService.ProcessAmount(amountInput);
        }

        public float AcquireWeight()
        {
            Console.WriteLine("Insert sobrasada weight:");
            var weightInput = RetryWhileInvalidInput(weightService.IsValidWeight);
            return weightService.ProcessWeight(weightInput);
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
        public void Run()
        {
            var currentTax = AcquireTax();
            var isEndOfSale = false;
            while(!isEndOfSale)
            {
                float currWeight = AcquireWeight();
                
                int amount = AcquireAmount();
                for (int i = 0; i < amount; i++)
                {
                    basket.AddToBaquest(new BasketItem("Sobrasada", SobrasadaConfiguration.PRICE_PER_KILOGRAM, currWeight, currentTax));
                }
                Console.WriteLine("\nWould your like to add another item? [yes] [no]");
                var answer = Console.ReadLine();
                isEndOfSale = answer.ToLower() != "yes";
            }
            Console.WriteLine(basket.PrintContent());
        }
        private string RetryWhileInvalidInput(Func<string, bool> validationAction)
        {
            var isValid = false;
            var input = string.Empty;
            while (!isValid)
            {
                try
                {
                    input = Console.ReadLine();
                    isValid = validationAction(input);
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return input;
        }
    }
}
