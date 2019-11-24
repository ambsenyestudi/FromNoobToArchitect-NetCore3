using SobrasadaShop.Application.DTO;
using SobrasadaShop.Application.Taxes;
using SobrasadaShop.Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.Application.Baskets
{
    public class BasketService
    {

        public TaxDTO Tax
        {
            get { return basket.Tax.ToTaxDTO(); }
            set 
            { 
                basket.Tax = value.ToTax(); 
            }
        }

        Basket basket;
        public BasketService()
        {
            basket = new Basket();
        }
        public void Add(ShopingItemDTO shopingItem)
        {
            var basketItem = new BasketItem(shopingItem.Name, shopingItem.PricePerUnitOfMesure, shopingItem.Mesure);
            basket.AddToBaquest(basketItem);
        }
        public string PrintSummary()
        {
            return basket.PrintContent();
        }
    }
}
