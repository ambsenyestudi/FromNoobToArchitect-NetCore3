using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.TextConsole
{
    public class Basket
    {
        private List<Sobrasada> items;
        
        public Basket()
        {
            this.items = new List<Sobrasada>();
        }
        public void AddToBaquest(Sobrasada sobrasada)
        {
            items.Add(sobrasada);
        }
        public string PrintContent(string isoCode, float taxPercentage)
        {
            string message = "Your basket contains:\n";
            foreach (var item in items)
            {
                message += string.Format("\n{0}", item);
            }
            if (Sobrasada.AllowedIsos.Contains(isoCode))
            {
                message += string.Format("\nTotal before taxes {0} final {1}",
                    items.Select(x => x.BasePrice).Sum(),
                    items.Select(x => x.FigurePrice(isoCode)).Sum());
            }
            else
            {
                message += string.Format("\nTotal before taxes {0} final {1}",
                    items.Select(x => x.BasePrice).Sum(),
                    items.Select(x => x.FigurePrice(taxPercentage)).Sum());
            }
            return message;
        }
    }
}
