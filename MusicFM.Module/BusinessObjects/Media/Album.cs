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
using MusicFM.Module.BusinessObjects.Info;
using MusicFM.Module.Language;

namespace MusicFM.Module.BusinessObjects.Media
{
    [DefaultClassOptions]
    [DefaultProperty("Title")]
    [ModelDefault("Caption", Lang.BO_ALBUM)]
    public class Album : BaseObject
    {
        public Album(Session session)
            : base(session)
        {

        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [RuleRequiredField("RequiredRule_Album_Title", DefaultContexts.Save, Lang.BO_ALBUM_TITLE_REQUIRED)]
        [ModelDefault("Caption", Lang.BO_ALBUM_TITLE)]
        public string Title { get; set; }

        [ModelDefault("Caption", Lang.BO_ALBUM_PUBLISHDATE)]
        public DateTime PublishDate { get; set; }

        [ModelDefault("Caption", Lang.BO_COMPANY)]
        [Association]
        public Company Company { get; set; }

        [ModelDefault("Caption", Lang.BO_ALBUM_SONGS)]
        [Association]
        public XPCollection<Song> Songs
        {
            get { return GetCollection<Song>("Songs"); }
        }

        [ModelDefault("Caption", Lang.BO_COMMENT)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<AlbumComment> Comments
        {
            get { return GetCollection<AlbumComment>("Comments"); }
        }
    }
}