using DevExpress.ExpressApp.Model;
using MusicFM.Module.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFM.Module.BusinessObjects.Enum
{
    public enum AccountPlatform
    {
        [ModelDefault("Caption", Lang.ENUM_ACCOUNTPLATFORM_WECHAT)]
        Wechat,

        [ModelDefault("Caption", Lang.ENUM_ACCOUNTPLATFORM_SINAWEIBO)]
        SinaWeibo,

        [ModelDefault("Caption", Lang.ENUM_ACCOUNTPLATFORM_QQ)]
        QQ,
    }
}
