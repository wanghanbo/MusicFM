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
using MusicFM.Module.Methods;

namespace MusicFM.Module.BusinessObjects.Base
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [CreatableItem(false)]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public abstract class UniqueIdObject : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public UniqueIdObject(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            GenerateID();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleUniqueValue("UniqueRule_ID", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRequiredField("RequiredRule_ID", DefaultContexts.Save, Lang.BO_PEOPLE_ID_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_ID)]
        public string ID { get; protected set; }

        public abstract string GetIDPrefix();

        protected void GenerateID()
        {
            int currentIdx = Convert.ToInt32(DBKeyValueHelper.GetValue(Session, "ID_" + GetIDPrefix()));

            DateTime now = DateTime.Now;
            ID = GetIDPrefix() + (currentIdx + 1).ToString().PadLeft(7, '0');

            DBKeyValueHelper.SetValue(Session, "ID_" + GetIDPrefix(), (currentIdx + 1).ToString());
        }
    }
}