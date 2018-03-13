using DevExpress.ExpressApp.Model;
using MusicFM.Module.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFM.Module.BusinessObjects.Enum
{
    public enum Gender
    {
        [ModelDefault("Caption", Lang.ENUM_GENDER_MALE)]
        Male,

        [ModelDefault("Caption", Lang.ENUM_GENDER_FEMALE)]
        Female
    }
}
