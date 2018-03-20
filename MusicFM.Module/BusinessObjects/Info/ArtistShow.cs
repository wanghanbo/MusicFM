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
using MusicFM.Module.BusinessObjects.Account;
using MusicFM.Module.Language;

namespace MusicFM.Module.BusinessObjects.Info
{
    [DefaultClassOptions]
    [DefaultProperty("Title")]
    [ModelDefault("Caption", Lang.BO_ARTISTSHOW)]
    public class ArtistShow : BaseObject
    { 
        public ArtistShow(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        [RuleRequiredField("RequiredRule_ArtistShow_Artist", DefaultContexts.Save, "")]
        [ModelDefault("Caption", Lang.BO_ARTIST)]
        [Association]
        public Artist Artist { get; set; }

        [RuleRequiredField("RequiredRule_ArtistShow_Title", DefaultContexts.Save, "")]
        [Size(64)]
        [ModelDefault("Caption", Lang.BO_ARTISTSHOW_TITLE)]
        public string Title { get; set; }

        [ModelDefault("Caption", Lang.BO_ARTISTSHOW_SHOWTIME)]
        public DateTime ShowTime { get; set; }

        [ModelDefault("Caption", Lang.BO_REGION)]
        public Region Region { get; set; }

        [Size(128)]
        [ModelDefault("Caption", Lang.BO_ARTISTSHOW_ADDRESS)]
        public string Address { get; set; }
    }
}