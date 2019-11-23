namespace SobrasadaShop.TextConsole
{
    public class Sobrasada
    {
        
        
        private readonly float weight;
        private readonly Tax tax;

        public Sobrasada(float kilos, Tax tax)
        {
            this.weight = kilos;
            this.tax = tax;
        }
        public float BasePrice { get => SobrasadaConfiguration.PRICE_PER_KILOGRAM * weight; }

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
