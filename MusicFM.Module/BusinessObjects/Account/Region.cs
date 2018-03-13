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

namespace MusicFM.Module.BusinessObjects.Account
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [ModelDefault("Caption", Lang.BO_REGION)]
    public class Region : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Region(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        //[RuleIsReferenced()]
        [ModelDefault("Caption", Lang.BO_REGION_REGIONNAME)]
        public string RegionName { get; set; }

        [ModelDefault("Caption", Lang.BO_REGION_PARENT)]
        [Association]
        public Region Parent { get; set; }

        [ModelDefault("Caption", Lang.BO_REGION_CHILDREN)]
        [Association]
        public XPCollection<Region> Children
        {
            get { return GetCollection<Region>("Children"); }
        }

        [ModelDefault("Caption", Lang.BO_REGION_FULLNAME)]
        [NonPersistent]
        public string FullName
        {
            get { return Parent != null ? Parent.FullName + this.RegionName : this.RegionName; }
        }
    }
}