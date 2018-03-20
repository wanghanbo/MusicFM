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
using MusicFM.Module.BusinessObjects.Media;

namespace MusicFM.Module.BusinessObjects.Info
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_TAG)]
    [DefaultProperty("TagName")]
    [NavigationItem(false)]
    [CreatableItem(false)]
    public class Tag : BaseObject
    { 
        public Tag(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Size(32)]
        [RuleUniqueValue("UniqueRule_Tag_TagName", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRequiredField("RequiredRule_Tag_TagName", DefaultContexts.Save, Lang.BO_TAG_TAGNAME_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_TAG)]
        public string TagName { get; set; }
    }
}