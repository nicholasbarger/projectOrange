using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using projectOrange.Models.Common.Entities;

namespace projectOrange.Models
{
    public class SimpleDescriptor : DBPersistent
    {
        #region Properties

        public string Code { get; set; }
        public Descriptor Descriptor { get; set; }
        public Status Status { get; set; }

        #endregion

        #region Constructors

        public SimpleDescriptor(int id) : base(id)
        {
            this.Id = id;
        }

        public SimpleDescriptor(string code)
        {
            this.Code = code;
        }

        public SimpleDescriptor(int id, string code)
        {
            this.Id = id;
            this.Code = code;
        }

        #endregion
    }
}