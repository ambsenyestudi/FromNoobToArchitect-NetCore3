using SobrasadaShop.Application.DTO;
using SobrasadaShop.Domain.Taxes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.Application.Taxes
{
    public static class TaxesMapping
    {
        public static Tax ToTax(this TaxDTO dto)
        {
            var result = default(Tax);
            if (dto != null)
            {
                result = new Tax { Amount = dto.Amount, IsoCode = dto.IsoCode, Name = dto.Name };
            }
            return result;
        }
        public static TaxDTO ToTaxDTO(this Tax tax)
        {
            var result = default(TaxDTO);
            if (tax != null)
            {
                result = new TaxDTO { Amount = tax.Amount, IsoCode = tax.IsoCode, Name = tax.Name };
            }
            return result;
        }
    }
}
