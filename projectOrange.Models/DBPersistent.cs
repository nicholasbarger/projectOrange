using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOrange.Models
{
    public class DBPersistent
    {
        #region Properties

        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }

        #endregion

        #region Constructors

        public DBPersistent() { }

        public DBPersistent(int id)
        {
            this.Id = id;
        }

        #endregion
    }
}