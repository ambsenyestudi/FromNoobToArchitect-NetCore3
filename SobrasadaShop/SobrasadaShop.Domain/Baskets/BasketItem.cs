using SobrasadaShop.Domain.Taxes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.Domain.Baskets
{
    public class BasketItem
    {
        private readonly float weight;
        private readonly Tax tax;
        private readonly float pricePerUnit;
        public string Name { get; private set; }

        public BasketItem(string name, float pricePerUnit, float kilos, Tax tax)
        {
            this.weight = kilos;
            this.tax = tax;
            this.pricePerUnit = pricePerUnit;
            this.Name = name;
        }
        public float BasePrice { get => pricePerUnit * weight; }

        public float FigurePrice()
        {
            return BasePrice * tax.Amount;
        }

        public override string ToString()
        {
            return string.Format("Sobrasada: {0}Kg before taxes {1} price {2}",
                weight, BasePrice, FigurePrice()
                );
        }
    }
}
