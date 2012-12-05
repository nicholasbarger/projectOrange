using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projectOrange.Models.Inventory.DTOs
{
    public class FullItem
    {
        //Base information
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public int UOMId { get; set; }
        public string UOMName { get; set; }
        public string Code { get; set; }
        public string Revision { get; set; }
        public bool IsPurchased { get; set; }
        public bool IsManufactured { get; set; }
        public bool IsSaleable { get; set; }
        public bool IsDigital { get; set; }
        public bool IsUnlimited { get; set; }

        //Extended information
        public int ActiveCurrencyId { get; set; }
        public string ActiveCurrencyCode { get; set; }
        public string ActiveCurrencyName { get; set; }

        public int ActiveLanguageId { get; set; }
        public string ActiveLanguageCode { get; set; }
        public string ActiveLanguageName { get; set; }

        public string BaseInUSDAmountPerUnitCurrencyAbbreviation { get; set; }
        public decimal BaseInUSDAmountPerUnitValue { get; set; }
        public string BaseInActiveCurrencyAmountPerUnitCurrencyAbbreviation { get; set; }
        public decimal BaseInActiveCurrencyAmountPerUnitValue { get; set; }

        //public int ContentInActiveLanguageLanguageCode { get; set; }
        //public string ContentInActiveLanguageLanguageName { get; set; }

        public string ContentInActiveLanguageName { get; set; }
        public string ContentInActiveLanguageBriefDescription { get; set; }
        public string ContentInActiveLanguageLongDescription { get; set; }
        public string ContentInActiveLanguageHtmlDescription { get; set; }
    }
}
