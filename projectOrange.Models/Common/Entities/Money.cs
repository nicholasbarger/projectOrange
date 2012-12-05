using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOrange.Models.Common.Entities
{
    public class Money : IComparable
    {
        #region Properties

        public decimal Value { get; set; }
        public Currency Currency { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor for money entity - 0 amount, USD currency.
        /// </summary>
        public Money()
        {
            this.Value = 0;
            this.Currency = new Currency("USD", "US Dollars");
        }

        /// <summary>
        /// Create new money and default currency to USD.
        /// </summary>
        /// <param name="value"></param>
        public Money(decimal value)
        {
            this.Value = value;
            this.Currency = new Currency("USD", "US Dollars");
        }

        /// <summary>
        /// Optional constructor accepting value and currency.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="currency"></param>
        public Money(decimal value, Currency currency)
        {
            this.Value = value;
            this.Currency = currency;
        }

        #endregion

        #region Methods

        private static void ValidateCurrency(Money m1, Money m2)
        {
            if (m1 == null)
            {
                throw new Exception("The first argument of money is null.");
            }

            if (m2 == null)
            {
                throw new Exception("The second argument of money is null.");
            }

            if (m1.Currency != m2.Currency)
            {
                throw new Exception("Currency does not match.");
            }
        }

        public static Money operator +(Money m1, Money m2)
        {
            //Handle for +=
            if (m2 == null)
            {
                m2 = new Money(0, m1.Currency);
            }

            ValidateCurrency(m1, m2);
            return new Money(m1.Value + m2.Value, m1.Currency);
        }

        public static Money operator -(Money m1, Money m2)
        {
            //Handle for -=
            if (m2 == null)
            {
                m2 = new Money(0, m1.Currency);
            }

            ValidateCurrency(m1, m2);
            return new Money(m1.Value - m2.Value, m1.Currency);
        }

        public static Money operator *(Money m1, Money m2)
        {
            ValidateCurrency(m1, m2);
            return new Money(m1.Value * m2.Value, m1.Currency);
        }

        public static Money operator *(decimal m1, Money m2)
        {
            Money newMoney = new Money();
            decimal moneyTemp = 0;

            moneyTemp = m1 * m2.Value;
            newMoney.Value = moneyTemp;
            newMoney.Currency = m2.Currency;

            return newMoney;
        }

        public static Money operator /(Money m1, Money m2)
        {
            ValidateCurrency(m1, m2);
            return new Money(m1.Value / m2.Value, m1.Currency);
        }

        public override string ToString()
        {
            return String.Format("{0:c}", this.Value);
        }

        #endregion

        #region IComparable<Money> Members

        public int CompareTo(object obj)
        {
            Money other = (Money)obj;
            return System.Collections.Comparer.Default.Compare(this.Value, other.Value);
        }

        #endregion
    }
}