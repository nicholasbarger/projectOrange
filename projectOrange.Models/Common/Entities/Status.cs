using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOrange.Models.Common.Entities
{
    public class Status : DBPersistent
    {
        #region Properties

        public StatusGroup StatusGroup { get; set; }
        public string Code { get; set; }

        #endregion

        #region Constructors

        public Status(int id, string code)
        {
            this.Id = id;
            this.Code = code;
        }

        #endregion
    }
}