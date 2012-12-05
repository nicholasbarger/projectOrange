using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectOrange.Models.Common.Entities;

namespace projectOrange.Models.Inventory.Entities
{
    public class ItemContent : DBPersistent
    {
        #region Properties

        public Language Language { get; set; }
        public string Name { get; set; }
        public string BriefDescription { get; set; }
        public string LongDescription { get; set; }
        public string HtmlDescription { get; set; }

        public virtual Item Item { get; set; }

        #endregion

        #region Constructors

        public ItemContent() { }

        public ItemContent(int id) : base(id)
        {
        }

        public ItemContent(int id, string name, string briefDescription, string longDescription, string htmlDescription) : base(id)
        {
            this.Name = name;
            this.BriefDescription = briefDescription;
            this.LongDescription = longDescription;
            this.HtmlDescription = htmlDescription;
        }

        #endregion
    }
}