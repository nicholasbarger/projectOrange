using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

using projectOrange.BusinessDataLogic.Mappers;
using projectOrange.Models.Inventory.DTOs;

namespace projectOrange.Services.Read
{
    [ServiceContract(Namespace = "projectOrange.Services.Read.Inventory")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Inventory
    {
        [OperationContract]
        [WebGet]
        public IEnumerable<BasicItem> GetAllItems(int languageId, int currencyId)
        {
            var logic = new BusinessDataLogic.Logic.Inventory();
            var mapper = new ItemModelToBasicItemDTO();

            return mapper.Map(logic.GetAllItems(languageId, currencyId));
        }

        [OperationContract]
        [WebGet]
        public FullItem GetItem(int id, int languageId, int currencyId)
        {
            var logic = new BusinessDataLogic.Logic.Inventory();
            var mapper = new ItemModelToFullItemDTO();

            return mapper.Map(logic.GetItem(id, languageId, currencyId));
        }

        [OperationContract]
        [WebGet]
        public IEnumerable<BasicItem> SearchItems(int languageId, int currencyId, string text)
        {
            var logic = new BusinessDataLogic.Logic.Inventory();
            var mapper = new ItemModelToBasicItemDTO();

            return mapper.Map(logic.SearchItems(languageId, currencyId, text));
        }

        [OperationContract]
        [WebGet]
        public IEnumerable<BasicItem> SearchItemsComplex(
            int languageId,
            int currencyId,
            string code,
            string text,
            int categoryId,
            int catalogId)
        {
            var logic = new BusinessDataLogic.Logic.Inventory();
            var mapper = new ItemModelToBasicItemDTO();

            return mapper.Map(logic.SearchItemsComplex(languageId, currencyId, code, text, categoryId, catalogId));
        }
    }
}
