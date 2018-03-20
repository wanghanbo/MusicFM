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
using DevExpress.Persistent.Base.General;

namespace MusicFM.Module.BusinessObjects.Account
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_REGION)]
    //[NavigationItem(false)]
    [DefaultProperty("RegionName")]
    public class Region : BaseObject, ITreeNode
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Region(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [RuleUniqueValue("UniqueRule_Region_RegionName", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRequiredField("RequiredRule_Region_RegionName", DefaultContexts.Save, Lang.BO_REGION_REGIONNAME_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_REGION_REGIONNAME)]
        public string RegionName { get; set; }

        [ModelDefault("AllowEdit", "false")]
        //[Browsable(false)]
        [ModelDefault("Caption", Lang.BO_REGION_PARENT)]
        [Association]
        public Region Parent { get; set; }

        //[Browsable(false)]
        [ModelDefault("Caption", Lang.BO_REGION_CHILDREN)]
        [Association, DevExpress.Xpo.Aggregated]
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

        string ITreeNode.Name => RegionName;

        ITreeNode ITreeNode.Parent => this.Parent;

        IBindingList ITreeNode.Children => this.Children;
    }
}