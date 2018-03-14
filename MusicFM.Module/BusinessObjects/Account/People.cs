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
    [DefaultProperty("ID")]
    public class People : BaseObject
    {
        public People(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //todo : Create Unique ID
        }

        [RuleUniqueValue("", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [ModelDefault("AllowEdit", "false")]
        public string ID { get; private set; }

        [RuleUniqueValue("", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRequiredField("Rule_People_Name", DefaultContexts.Save, Lang.BO_PEOPLE_NAME_REQIURED)]
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