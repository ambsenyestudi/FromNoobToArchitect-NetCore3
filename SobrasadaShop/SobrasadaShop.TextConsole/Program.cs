using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                Console.WriteLine("Insert sobrasada weight:");
                float currWeight = -1f;
                while (!float.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out currWeight))
                {
                    Console.WriteLine("Weight must be a valid number");
                }
                Console.WriteLine("Insert sobrasada amout:");
                int amount = -1;
                if (!int.TryParse(Console.ReadLine(), out amount) || amount < 0)
                {
                    amount = 1;
                }
                for (int i = 0; i < amount; i++)
                {
                    basket.AddToBaquest(new Sobrasada(currWeight, currentTax));
                }
                Console.WriteLine("\nWould your like to add another item? [yes] [no]");
                var answer = Console.ReadLine();
                isEndOfSale = answer != "yes";

            }
            Console.WriteLine(basket.PrintContent());
        }

        
    }
}
