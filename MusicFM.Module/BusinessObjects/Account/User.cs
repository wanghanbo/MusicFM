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
using MusicFM.Module.Language;
using MusicFM.Module.BusinessObjects.Enum;
using MusicFM.Module.BusinessObjects.Account;
using MusicFM.Module.BusinessObjects.Record;
using MusicFM.Module.BusinessObjects.Info;

namespace MusicFM.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_USER)]
    [DefaultProperty("Name")]
    public class User : People
    {
        public User(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            DateTime now = DateTime.Now;
            CreateOn = now;
            LastLoginOn = now;
            LastModifyOn = now;
        }

        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("Caption", Lang.BO_USER_CREATEON)]
        public DateTime CreateOn { get; private set; }

        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("Caption", Lang.BO_USER_LASTLOGINON)]
        public DateTime LastLoginOn { get; set; }
        [ModelDefault("AllowEdit", "false")]
        [ModelDefault("Caption", Lang.BO_USER_LASTMODIFYON)]
        public DateTime LastModifyOn { get; set; }

        [ModelDefault("Caption", Lang.BO_USER_SIGN)]
        public string Sign { get; set; }

        [ModelDefault("Caption", Lang.BO_USER_FOLLOWS)]
        [Association]
        public XPCollection<User> Follows
        {
            get { return GetCollection<User>("Follows"); }
        }

        [ModelDefault("Caption", Lang.BO_USER_FANS)]
        [Association]
        public XPCollection<User> Fans
        {
            get { return GetCollection<User>("Fans");  }
        }

        [ModelDefault("Caption", Lang.BO_USER_USERACCOUNTBINDINGS)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<UserAccountBinding> AccountBindings
        {
            get { return GetCollection<UserAccountBinding>("AccountBindings"); }
        }

        [ModelDefault("Caption", Lang.BO_USER_SONGPLAYRECORD)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<SongPlayRecord> SongPlayRecords
        {
            get { return GetCollection<SongPlayRecord>("SongPlayRecords"); }
        }

        [ModelDefault("Caption", Lang.BO_USER_COMMENTS)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<Comment> Comments
        {
            get { return GetCollection<Comment>("Comments"); }
        }
    }
}