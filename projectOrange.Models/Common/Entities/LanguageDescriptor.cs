using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectOrange.Models.Common.Entities
{
    public class LanguageDescriptor : DBPersistent
    {
        public string BriefDescription { get; set; }
        public Descriptor Descriptor { get; set; }
        public Language Language { get; set; }
        public string LongDescription { get; set; }
        public string Name { get; set; }        
    }
}