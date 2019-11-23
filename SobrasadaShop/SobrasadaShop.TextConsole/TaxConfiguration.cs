using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.TextConsole
{
    public static class TaxConfiguration
    {
        private static Tax espTax = Tax.Create("Spain", "ESP", 1.04f);
        public static Tax ESP { get => espTax; }

        private static Tax efrTax = Tax.Create("France", "FR", 1.055f);
        public static Tax FR { get => efrTax; }

        private static Tax deuTax = Tax.Create("Germany", "DEU", 1.07f);
        public static Tax DEU { get => deuTax; }
    }
}
