using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Entities = projectOrange.Models.Inventory.Entities;
using Data = projectOrange.BusinessDataLogic;

namespace projectOrange.BusinessDataLogic.Mappers
{
    public class ItemContentDataToModel : Mapper<Data.ItemContent, Entities.ItemContent>
    {
        public override Entities.ItemContent Map(Data.ItemContent d)
        {
            var e = new Entities.ItemContent()
            {
                BriefDescription = d.BriefDescription,
                Created = d.Created,
                HtmlDescription = d.HtmlContent,
                Id = d.Id,
                LongDescription = d.LongDescription,
                Modified = d.Modified,
                Name = d.Name
            };

            return e;
        }

        public Entities.ItemContent Map(Data.ItemContent d, int languageId)
        {
            var e = Map(d);
            e.Language = new Models.Common.Entities.Language(d.Language.Id, d.Language.Code);

            return e;
        }
    }
}
