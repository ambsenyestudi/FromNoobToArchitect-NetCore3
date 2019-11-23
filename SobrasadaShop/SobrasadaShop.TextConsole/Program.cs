using System;

namespace SobrasadaShop.TextConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            TaxAditionManager taxAditionManager = new TaxAditionManager();
            var currentTax = taxAditionManager.AcquireTax();

            
            var basket = new Basket();
            
            var isEndOfSale = false;

            while (!isEndOfSale)
            {
                float currWeight = taxAditionManager.AcquireWeight();
                int amount = taxAditionManager.AcquireAmount();
                
                for (int i = 0; i < amount; i++)
                {
                    basket.AddToBaquest(new Sobrasada(currWeight, currentTax));
                }
                Console.WriteLine("\nWould your like to add another item? [yes] [no]");
                var answer = Console.ReadLine();
                isEndOfSale = answer.ToLower() != "yes";

            }
            Console.WriteLine(basket.PrintContent());
        }

        
    }
}
