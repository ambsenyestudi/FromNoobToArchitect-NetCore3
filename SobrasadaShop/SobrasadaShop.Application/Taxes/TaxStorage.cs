using SobrasadaShop.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SobrasadaShop.Application.Taxes
{
    public class TaxStorage
    {
        IList<TaxDTO> taxes;
        public IEnumerable<TaxDTO> Taxes { get=>taxes; }
        public TaxStorage()
        {
            taxes = new List<TaxDTO>();
        }
        public Guid Create(TaxDTO tax)
        {
            taxes.Add(tax);
            return tax.Id;
        }
        public IEnumerable<TaxDTO> FilterByIso(string isoCode) =>
            Taxes.Where(tx => tx.IsoCode == isoCode.ToUpper());

        public TaxDTO Read(Guid id) =>
            Taxes.Where(tx => tx.Id == id).FirstOrDefault();
    }
}
