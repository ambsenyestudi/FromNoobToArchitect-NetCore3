using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.TextConsole
{
    public class Tax
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public float Amount { get; set; }
        public static Tax Create(string name, string isoCode, float amount)
        {
            return new Tax { Name = name, IsoCode = isoCode, Amount = amount };
        }
        public static Tax Create(string name, float amount)
        {
            return new Tax { Name = name, Amount = amount };
        }
    }
    
}
