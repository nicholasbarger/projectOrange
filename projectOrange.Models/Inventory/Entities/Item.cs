using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectOrange.Models.Common.Entities;
using projectOrange.Models.Sales.Entities;
using System.Globalization;

namespace projectOrange.Models.Inventory.Entities
{
    public class Item : DBPersistent
    {
        #region Properties

        //Base information
        public Status Status { get; set; }
        public UOM UOM { get; set; }
        public string Code { get; set; }
        public string Revision { get; set; }
        public bool IsPurchased { get; set; }
        public bool IsManufactured { get; set; }
        public bool IsSaleable { get; set; }
        public bool IsDigital { get; set; }
        public bool IsUnlimited { get; set; }

        //Extended information
        public Currency ActiveCurrency { get; set; }
        public Language ActiveLanguage { get; set; }

        public BasePrice BaseInUSD { get; set; }
        public BasePrice BaseInActiveCurrency
        {
            get
            {
                return BasePrices.Where(a => a.AmountPerUnit.Currency == ActiveCurrency).FirstOrDefault();
            }
        }
        public List<BasePrice> BasePrices { get; set; }

        public ItemContent ContentInActiveLanguage 
        {
            get
            {
                return Contents.Where(a => a.Language.Id == ActiveLanguage.Id).FirstOrDefault();
            }
        }
        public List<ItemContent> Contents { get; set; }

        #endregion

        #region Constructors

        public Item() : base()
        {
            this.BasePrices = new List<BasePrice>();
            this.Contents = new List<ItemContent>();
        }

        public Item(int id) : base(id)
        {
            this.Id = id;

            this.BasePrices = new List<BasePrice>();
            this.Contents = new List<ItemContent>();
        }

        #endregion

        #region Methods

        public BasePrice GetBasePrice(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public ItemContent GetContent(CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}