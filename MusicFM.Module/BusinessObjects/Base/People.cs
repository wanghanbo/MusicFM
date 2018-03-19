using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using MusicFM.Module.BusinessObjects.Enum;
using MusicFM.Module.Language;
using System;
using System.ComponentModel;

namespace MusicFM.Module.BusinessObjects.Account
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [DefaultProperty("Name")]
    [CreatableItem(false)]
    public class People : BaseObject
    {
        public People(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [RuleUniqueValue("UniqueRule_People_ID", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRequiredField("RequiredRule_People_ID", DefaultContexts.Save, Lang.BO_PEOPLE_ID_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_ID)]
        //[ModelDefault("AllowEdit", "false")]
        public string ID { get; set; }

        [RuleUniqueValue("", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRequiredField("RequiredRule_People_Name", DefaultContexts.Save, Lang.BO_PEOPLE_NAME_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_PEOPLE_NAME)]
        public string Name { get; set; }

        [ModelDefault("Caption", Lang.BO_PEOPLE_GENDER)]
        public Gender Gender { get; set; }

        [ModelDefault("Caption", Lang.BO_PEOPLE_BIRTHDAY)]
        public DateTime? Birthday { get; set; }

        [ModelDefault("Caption", Lang.BO_REGION)]
        public Region Region { get; set; }
    }
}