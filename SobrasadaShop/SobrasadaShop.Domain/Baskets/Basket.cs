using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.Domain.Baskets
{
    public class Basket
    {
        private List<BasketItem> items;

        public Basket()
        {
            this.items = new List<BasketItem>();
        }
        public void AddToBaquest(BasketItem item)
        {
            items.Add(item);
        }
        public string PrintContent()
        {
            string message = "Your basket contains:\n";
            foreach (var item in items)
            {
                message += string.Format("\n{0}", item);
            }
            message += string.Format("\nTotal before taxes {0} final {1}",
                    items.Select(x => x.BasePrice).Sum(),
                    items.Select(x => x.FigurePrice()).Sum());
            return message;
        }
    }
}
