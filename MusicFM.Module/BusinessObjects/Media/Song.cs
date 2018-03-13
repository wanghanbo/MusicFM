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
using MusicFM.Module.BusinessObjects.Account;

namespace MusicFM.Module.BusinessObjects.Media
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_SONG)]
    public class Song : BaseObject
    { 
        public Song(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [ModelDefault("Caption", Lang.BO_SONG_TITLE)]
        public string Title { get; set; }

        [ModelDefault("Caption", Lang.BO_ARTIST)]
        [Association]
        public Artist Artist { get; set; } 
    }
}