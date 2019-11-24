using System;
using System.Collections.Generic;
using System.Text;

namespace SobrasadaShop.Application.DTO
{
    public class TaxDTO
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public float Amount { get; set; }
        public TaxDTO()
        {
            Id = Guid.NewGuid();
        }
    }
}
