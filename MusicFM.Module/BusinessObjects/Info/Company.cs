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
using MusicFM.Module.BusinessObjects.Media;
using MusicFM.Module.Language;

namespace MusicFM.Module.BusinessObjects.Info
{
    [DefaultClassOptions]
    [DefaultProperty("CompanyName")]
    [ModelDefault("Caption", Lang.BO_COMPANY)]
    public class Company : BaseObject
    { 
        public Company(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [Size(32)]
        [RuleUniqueValue("UniqueRule_Company_Name", DefaultContexts.Save, CriteriaEvaluationBehavior = CriteriaEvaluationBehavior.BeforeTransaction)]
        [RuleRequiredField("RequiredRule_Company_Name", DefaultContexts.Save, Lang.BO_COMPANY_NAME_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_COMPANY_NAME)]
        public string CompanyName { get; set; }

        [ModelDefault("Caption", Lang.BO_COMPANY_ALBUMS)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<Album> Albums
        {
            get { return GetCollection<Album>("Albums"); }
        }
    }
}