using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using MusicFM.Module.BusinessObjects.Enum;
using MusicFM.Module.Language;
using System;
using System.ComponentModel;

namespace MusicFM.Module.BusinessObjects.Account
{
    [DefaultClassOptions]
    [Browsable(false)]
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