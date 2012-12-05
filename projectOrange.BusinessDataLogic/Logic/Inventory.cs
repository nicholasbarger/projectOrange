using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entities = projectOrange.Models.Inventory.Entities;
using projectOrange.BusinessDataLogic.Mappers;

namespace projectOrange.BusinessDataLogic.Logic
{
    public class Inventory
    {
        public IEnumerable<Entities.Item> GetAllItems(int languageId, int currencyId)
        {
            //Validation of params
            if (languageId <= 0)
            {
                throw new ArgumentException("Language Id is not valid", "languageId");
            }
            if (currencyId <= 0)
            {
                throw new ArgumentException("Currency Id is not valid", "currencyId");
            }

            var data = new OrangeDB();
            var coll = data.Items.ToArray();

            var mapper = new ItemDataToModel();
            var entities = mapper.Map(coll, languageId, currencyId);

            return entities;
        }

        public Entities.Item GetItem(int id, int languageId, int currencyId)
        {
            //Validation of params
            if (id <= 0)
            {
                throw new ArgumentException("Id is not valid", "id");
            }
            if (languageId <= 0)
            {
                throw new ArgumentException("Language Id is not valid", "languageId");
            }
            if (currencyId <= 0)
            {
                throw new ArgumentException("Currency Id is not valid", "currencyId");
            }

            //Business logic for getting an item
            var data = new OrangeDB();
            var rec = data.Items
                .Where(a => a.Id == id)
                .FirstOrDefault();

            var mapper = new ItemDataToModel();
            var entity = mapper.Map(rec, languageId, currencyId);

            return entity;
        }

        public IEnumerable<Entities.Item> SearchItems(int languageId, int currencyId, string text)
        {
            //Validation of params
            if (languageId <= 0)
            {
                throw new ArgumentException("Language Id is not valid", "languageId");
            }
            if (currencyId <= 0)
            {
                throw new ArgumentException("Currency Id is not valid", "currencyId");
            }

            //Business logic for searching an item by text and code only
            var data = new OrangeDB();
            var coll = data.Items
                .Where(a => a.Code.Contains(text)
                    || a.ItemContents.Any(b => b.LanguageId == languageId && (b.Name.Contains(text) || b.BriefDescription.Contains(text) || b.LongDescription.Contains(text))))
                .ToArray();

            var mapper = new ItemDataToModel();
            var entities = mapper.Map(coll, languageId, currencyId);

            return entities;
        }

        public IEnumerable<Entities.Item> SearchItemsComplex(
            int languageId,
            int currencyId,
            string code,
            string text,
            int categoryId,
            int catalogId)
        {
            //Validation of params
            if (languageId <= 0)
            {
                throw new ArgumentException("Language Id is not valid", "languageId");
            }
            if (currencyId <= 0)
            {
                throw new ArgumentException("Currency Id is not valid", "currencyId");
            }
            //Todo: come back and check if I am handling the search criteria correctly for this and validation of params

            //Business logic for searching an item by specific criteria
            var data = new OrangeDB();
            var coll = data.Items
                .Where(a => a.Code == code
                    && a.Code.Contains(text) || a.ItemContents.Any(b => b.LanguageId == languageId && (b.Name.Contains(text) || b.BriefDescription.Contains(text) || b.LongDescription.Contains(text)))
                    && a.ItemCategories.Any(b => b.Id == categoryId)
                    && a.ItemCatalogs.Any(b => b.Id == catalogId))
                .ToArray();

            var mapper = new ItemDataToModel();
            var entities = mapper.Map(coll, languageId, currencyId);

            return entities;
        }
    }
}
