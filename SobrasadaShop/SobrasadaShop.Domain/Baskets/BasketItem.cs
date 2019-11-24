using SobrasadaShop.Domain.Taxes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.Domain.Baskets
{
    public class BasketItem
    {
        public float Mesure { get; private set; }
        private readonly float pricePerUnitOfMesure;

        public string Name { get; private set; }

        public BasketItem(string name, float pricePerUnit, float mesure)
        {
            this.Mesure = mesure;
            this.pricePerUnitOfMesure = pricePerUnit;
            this.Name = name;
        }

        public float BasePrice { get => pricePerUnitOfMesure * Mesure; }

        
    }
}
