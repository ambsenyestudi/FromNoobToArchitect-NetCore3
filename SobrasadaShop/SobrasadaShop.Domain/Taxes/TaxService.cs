using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SobrasadaShop.Domain.Taxes
{
    public class TaxService
    {
        

        public string Pritify(string item, string format)
            => string.Format(format, item); 
            
    }
}
