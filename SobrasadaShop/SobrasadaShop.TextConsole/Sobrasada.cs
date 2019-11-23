namespace SobrasadaShop.TextConsole
{
    public class Sobrasada
    {
        public static string[] AllowedIsos = new string[] { "ESP", "DEU", "FR" };
        private const float SOBRASADA_PRICE = 6.0f;
        private readonly float weight;
        private readonly string isoCode;

        public Sobrasada(float kilos, string isoCode)
        {
            this.weight = kilos;
            this.isoCode = isoCode;
        }
        public float BasePrice { get => SOBRASADA_PRICE * weight; }

        public float FigurePrice(float tax)
        {
            return BasePrice * tax;
        }
        public float FigurePrice(string isoCode)
        {
            var result = 0.0f;
            switch (isoCode)
            {
                case "ESP":
                    result = FigurePrice(1.04f);
                    break;
                case "FR":
                    result = FigurePrice(1.055f);
                    break;
                case "DEU":
                    result = FigurePrice(1.07f);
                    break;
                default:
                    break;
            }
            return result;
        }
        public override string ToString()
        {
            return string.Format("Sobrasada: {0}Kg before taxes {1} price {2}",
                weight, BasePrice, FigurePrice(isoCode)
                );
        }

    }
}
