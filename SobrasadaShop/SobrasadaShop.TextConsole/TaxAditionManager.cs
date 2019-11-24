using SobrasadaShop.Application.Amount;
using SobrasadaShop.Application.DTO;
using SobrasadaShop.Application.Taxes;
using SobrasadaShop.Application.Weight;
using SobrasadaShop.Application.Baskets;
using System;
using System.Globalization;
using System.Linq;

namespace SobrasadaShop.TextConsole
{
    public class TaxAditionManager
    {
        private readonly BasketService basketService;
        private readonly TaxService taxService;
        private readonly AmountService amountService;
        private readonly WeightService weightService;
        private readonly TaxStorage taxStorage;

        public TaxAditionManager()
        {
            this.basketService = new BasketService();
            this.taxService = new TaxService();
            this.amountService = new AmountService();
            this.weightService = new WeightService();
            this.taxStorage = new TaxStorage();
        }
        public TaxDTO AcquireTax()
        {
            //Todo fix this message generation
            string isoOptionsMsg = string.Format("Insert iso code: {0} or press enter to insert custom tax",
                taxStorage.Taxes.Select(tx=>taxService.Pritify(tx.IsoCode,"[{0}]")));
            Console.WriteLine(isoOptionsMsg);
            //ToDo
            /*
            var taxInput = RetryWhileInvalidInput(taxService.isValidTax, taxStorage.Taxes);
            if(!string.IsNullOrWhiteSpace(taxInput))
            {
                taxStorage.FilterByIso(taxInput);
            }
            else
            {
            */
                return AcquierCutomTask();
            //}
            

        }

        private TaxDTO AcquierCutomTask()
        {
            Console.WriteLine("Insert custom tax value");
            var input = RetryWhileInvalidInput(taxService.isValidTaxAmount);
            var customTax = new TaxDTO { Name = "Custom", Amount = float.Parse(input) };
            var id = taxStorage.Create(customTax);
            return taxStorage.Read(id);
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
            basketService.Tax = AcquireTax();
            var isEndOfSale = false;
            while(!isEndOfSale)
            {
                float currWeight = AcquireWeight();
                
                int amount = AcquireAmount();
                for (int i = 0; i < amount; i++)
                {
                    basketService.Add(new ShopingItemDTO { Name = "Sobrasada", PricePerUnitOfMesure = SobrasadaConfiguration.PRICE_PER_KILOGRAM, Mesure = currWeight });
                }
                Console.WriteLine("\nWould your like to add another item? [yes] [no]");
                var answer = Console.ReadLine();
                isEndOfSale = answer.ToLower() != "yes";
            }
            Console.WriteLine(basketService.PrintSummary());
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
