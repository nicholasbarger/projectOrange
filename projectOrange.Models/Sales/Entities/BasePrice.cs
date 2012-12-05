using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectOrange.Models.Common.Entities;
using System.Globalization;

namespace projectOrange.Models.Sales.Entities
{
    public class BasePrice
    {
        #region Properties

        public Money AmountPerUnit { get; set; }

        #endregion

        #region Constructors
        
        public BasePrice(decimal amount)
        {
            this.AmountPerUnit = new Money(amount);
        }

        public BasePrice(decimal amount, Currency currency)
        {
            this.AmountPerUnit = new Money(amount, currency);
        }

        #endregion
        
    }
}