using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using projectOrange.Utilities;

namespace projectOrange.Models.Common.Entities
{
    public class Currency : DBPersistent, IComparable<Currency>, IEquatable<Currency>
    {
        #region Enums

        public enum CurrencyList
        {
            [Description("USD")]
            USD = 1,
            [Description("CAD")]
            CAD = 2,
            [Description("EUR")]
            EUR = 3,
            [Description("MXN")]
            MXN = 4
        }

        #endregion

        #region Constructors

        public Currency(int id) : base(id)
        {
            this.Id = id;
        }

        public Currency(CurrencyList currency)
        {
            this.Id = (int)currency;
            this.Abbreviation = Enum<CurrencyList>.GetDescription(currency);
        }

        public Currency(string abbreviation, string name)
        {
            this.Abbreviation = abbreviation;
            this.Name = name;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The 3-digit abbreviation of currency (i.e. USD, etc..)
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// The name of the currency.
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region IComparable<Customer> Members

        public int CompareTo(Currency other)
        {
            return this.Abbreviation.CompareTo(other.Abbreviation);
        }

        #endregion

        #region IEquatable<Customer> Members

        public bool Equals(Currency other)
        {
            if ((object)other == null)
            {
                return false;
            }

            return this.Abbreviation == other.Abbreviation || this.Id == other.Id;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Abbreviation;
        }

        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            Currency other = obj as Currency;
            if ((System.Object)other == null)
            {
                return false;
            }

            return this.Abbreviation == other.Abbreviation || this.Id == other.Id;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Currency c1, Currency c2)
        {
            if (System.Object.ReferenceEquals(c1, c2))
            {
                return true;
            }

            if (((object)c1 == null) || ((object)c2 == null))
            {
                return false;
            }

            return c1.Abbreviation == c2.Abbreviation || c1.Id == c2.Id;
        }

        public static bool operator !=(Currency c1, Currency c2)
        {
            return !(c1 == c2);
        }

        #endregion
    }
}