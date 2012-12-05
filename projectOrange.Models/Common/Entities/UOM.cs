using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOrange.Models.Common.Entities
{
    public class UOM : SimpleDescriptor
    {
        #region Constructors

        public UOM(int id) : base(id) { }
        public UOM(string code) : base(code) { }
        public UOM(int id, string code) : base(id, code) { }

        #endregion
    }
}