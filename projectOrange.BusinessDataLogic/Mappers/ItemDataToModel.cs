using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entities = projectOrange.Models.Inventory.Entities;
using Data = projectOrange.BusinessDataLogic;

namespace projectOrange.BusinessDataLogic.Mappers
{
    public class ItemDataToModel : Mapper<Data.Item, Entities.Item>
    {
        public override Entities.Item Map(Data.Item d)
        {
            var itemContentMapper = new ItemContentDataToModel();

            var e = new Entities.Item()
            {
                BaseInUSD = new Models.Sales.Entities.BasePrice(d.ItemBasePricings.Where(a => a.Currency.Code == Constants.CurrencyCodeForDollar).FirstOrDefault().PerUnitPrice),
                Code = d.Code,
                Contents = itemContentMapper.Map(d.ItemContents).ToList(),
                Created = d.Created,
                Id = d.Id,
                IsDigital = d.IsDigital,
                IsManufactured = d.IsManufactured,
                IsPurchased = d.IsPurchased,
                IsSaleable = d.IsSaleable,
                IsUnlimited = d.IsUnlimitedQuantity,
                Modified = d.Modified,
                Revision = d.Revision,
                Status = new Models.Common.Entities.Status(d.Status.Id, d.Status.Code),
                UOM = new Models.Common.Entities.UOM(d.UOM.Id, d.UOM.Code)
            };

            return e;
        }

        public Entities.Item Map(Data.Item d, int languageId, int currencyId)
        {
            var e = Map(d);
            e.ActiveCurrency = new Models.Common.Entities.Currency(currencyId);
            e.ActiveLanguage = new Models.Common.Entities.Language(languageId);

            foreach (var price in d.ItemBasePricings)
            {
                e.BasePrices.Add(new Models.Sales.Entities.BasePrice(price.PerUnitPrice, new Models.Common.Entities.Currency(currencyId)));
            }

            foreach (var content in d.ItemContents)
            {
                //Todo: check if appropriate to make this a singleton
                var mapper = new ItemContentDataToModel();
                e.Contents.Add(mapper.Map(content, languageId));
            }

            return e;
        }

        public IEnumerable<Entities.Item> Map(IEnumerable<Data.Item> coll, int languageId, int currencyId)
        {
            var list = new List<Entities.Item>();

            foreach (var d in coll)
            {
                list.Add(Map(d, languageId, currencyId));
            }

            return list;
        }
    }
}
