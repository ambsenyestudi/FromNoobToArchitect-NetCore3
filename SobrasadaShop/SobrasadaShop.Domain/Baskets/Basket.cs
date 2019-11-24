using SobrasadaShop.Domain.Taxes;
using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.Domain.Baskets
{
    public class Basket
    {
        private List<BasketItem> items;
        public Tax Tax { get; set; }

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
            var groupedLines = items.GroupBy(it => it.Mesure);
            foreach (var item in groupedLines)
            {
                message += PrintLine(item.ToList(),Tax);
            }
            message += PrintSummaryLine(Tax);
            return message;
        }
        public string PrintLine(IEnumerable<BasketItem> itemGroups, Tax tax)
        {
            var result = string.Empty;
            var nameGrouped = itemGroups.GroupBy(g=>g.Name);
            foreach (var group in nameGrouped)
            {
                var items = group.ToList();
                var firstItem = items.First();
                result = string.Format("\n{0} berfore taxes {1} price {2} x {3} units = {4}",
                    firstItem.Name,
                    firstItem.BasePrice,
                    firstItem.BasePrice * tax.Amount,
                    items.Count,
                    firstItem.BasePrice * tax.Amount * items.Count);
            }
            return result;
        }
        public string PrintSummaryLine(Tax tax)
        {
            return string.Format("\nTotal before taxes {0} final {1}",
                    items.Select(x => x.BasePrice).Sum(),
                    items.Select(x => x.BasePrice * Tax.Amount).Sum());
        }
    }
}
