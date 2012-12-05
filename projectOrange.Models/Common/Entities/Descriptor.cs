using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace projectOrange.Models.Common.Entities
{
    public class Descriptor : DBPersistent
    {
        #region Properties
        
        public string Code { get; set; }

        public LanguageDescriptor Default { get; set; }
        public IList<LanguageDescriptor> LanguageDescriptors { get; set; }

        #endregion

        #region Methods

        public LanguageDescriptor Localized(CultureInfo culture)
        {
            return LanguageDescriptors.Where(a => a.Language.Code == culture.TwoLetterISOLanguageName).FirstOrDefault();
        }

        #endregion
    }
}