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
using MusicFM.Module.BusinessObjects.Enum;
using MusicFM.Module.BusinessObjects.Info;

namespace MusicFM.Module.BusinessObjects.Media
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_SONG)]
    [DefaultProperty("DisplayName")]
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

        [RuleRequiredField("RequiredRule_Song_Title", DefaultContexts.Save, Lang.BO_SONG_TITLE_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_SONG_TITLE)]
        [ModelDefault("Index", "1")]
        public string Title { get; set; }

        [ModelDefault("Caption", Lang.BO_ARTIST)]
        [Association]
        [ModelDefault("Index", "2")]
        public Artist Artist { get; set; } 

        [ModelDefault("Caption", Lang.BO_SONG_STYLE)]
        public MusicStyle Style { get; set; }

        [ModelDefault("Caption", Lang.BO_TAG)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<SongTag> Tags
        {
            get { return GetCollection<SongTag>("Tags"); }
        }

        [ModelDefault("Caption", Lang.BO_ALBUM)]
        [Association]
        public XPCollection<Album> Albums
        {
            get { return GetCollection<Album>("Albums"); }
        }

        [ModelDefault("Caption", Lang.BO_COMMENT)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<SongComment> Comments
        {
            get { return GetCollection<SongComment>("Comments"); }
        }

        [ModelDefault("Caption", Lang.BO_SONG_URL)]
        public string URL { get; set; }

        [Browsable(false)]
        [NonPersistent]
        public string DisplayName
        {
            get
            {
                if (Title == null || Artist == null)
                {
                    return "";
                }
                else
                {
                    return Title + " - " + Artist.Name;
                }
            }
        }
    }
}