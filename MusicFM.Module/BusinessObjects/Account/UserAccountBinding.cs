using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using MusicFM.Module.BusinessObjects.Enum;
using MusicFM.Module.Language;

namespace MusicFM.Module.BusinessObjects.Account
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_USERACCOUNT_BINDING)]
    [NavigationItem(false)]
    [CreatableItem(false)]
    [DefaultProperty("ID")]
    public class UserAccountBinding : BaseObject
    { 
        public UserAccountBinding(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleRequiredField("RequiredRule_UserAccount_Platform", DefaultContexts.Save, Lang.BO_PEOPLE_ID_REQUIRED)]
        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("Caption", Lang.BO_USERACCOUNT_PLATFORM)]
        public AccountPlatform Platform { get; set; }

        [RuleRequiredField("RequiredRule_UserAccount_ID", DefaultContexts.Save, Lang.BO_PEOPLE_NAME_REQUIRED)]
        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("Caption", Lang.BO_USERACCOUNT_ID)]
        public string ID { get; set; }

        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("Caption", Lang.BO_USERACCOUNT_ISAUTHENTICATED)]
        public bool IsAuthenticated { get; set; }

        [Browsable(false)]
        [Association]
        public User User { get; set; }

        internal void OnAuthenticated(string id, bool result)
        {
            ID = id;
            IsAuthenticated = result;
        }
    }
}