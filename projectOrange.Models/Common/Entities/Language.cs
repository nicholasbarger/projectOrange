using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOrange.Models.Common.Entities
{
    public class Language : SimpleDescriptor
    {
        #region Properties

        public string Name { get; set; }

        #endregion

        #region Constructors

        public Language(int id) : base(id) { }
        public Language(string code) : base(code) { }
        public Language(int id, string code) : base(id, code) { }

        #endregion
    }
}