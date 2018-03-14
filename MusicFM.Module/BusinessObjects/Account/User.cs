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

namespace MusicFM.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [ModelDefault("Caption", Lang.BO_USER)]
    public class User : People
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
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

        [ModelDefault("Caption", Lang.BO_USER_USERACCOUNTBINDINGS)]
        [Association]
        public XPCollection<UserAccountBinding> AccountBindings
        {
            get { return GetCollection<UserAccountBinding>("AccountBindings"); }
        }

        [ModelDefault("Caption", Lang.BO_USER_SONGPLAYRECORD)]
        [Association]
        public XPCollection<SongPlayRecord> SongPlayRecords
        {
            get { return GetCollection<SongPlayRecord>("SongPlayRecords"); }
        }
    }
}