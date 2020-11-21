using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class CompanyDto
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal? Length { get; set; }
        public decimal StateId { get; set; }
        public string PostalCode { get; set; }
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string ProvinceName { get; set; }
        public decimal IsSupplier { get; set; }
        public decimal IsPos { get; set; }
    }
}
