using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOrange.Models.Common.Entities
{
    public class StatusGroup : SimpleDescriptor
    {
        #region Properties

        new public Status Status
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        #endregion

        #region Constructors

        public StatusGroup(int id) : base(id) { }
        public StatusGroup(string code) : base(code) { }
        public StatusGroup(int id, string code) : base(id, code) { }

        #endregion
    }
}