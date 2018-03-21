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
using MusicFM.Module.BusinessObjects.Enum;
using MusicFM.Module.BusinessObjects.Media;
using MusicFM.Module.Language;
using MusicFM.Module.BusinessObjects.Info;

namespace MusicFM.Module.BusinessObjects.Account
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_ARTIST)]
    [DefaultProperty("Name")]
    public class Artist : People
    { 
        public Artist(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [ModelDefault("Caption", Lang.BO_SONG)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<Song> Songs
        {
            get { return GetCollection<Song>("Songs"); }
        }

        [Size(256)]
        public string Brief { get; set; }

        [Size(1024)]
        [Browsable(false)]
        public string DetailInfo1 { get; set; }

        [Size(1024)]
        [Browsable(false)]
        public string DetailInfo2 { get; set; }

        [Size(1024)]
        [Browsable(false)]
        public string DetailInfo3 { get; set; }

        [Size(3096)]
        [NonPersistent]
        [ModelDefault("Caption", Lang.BO_ARTIST_DETIALINFO)]
        public string DetailInfo
        {
            get { return DetailInfo1 + DetailInfo2 + DetailInfo3; }
            set
            {
                string p1 = "", p2 = "", p3 = "";
                p1 = value.Substring(0, Math.Min(value.Length, 1024));
                if (value.Length > 1024)
                {
                    p2 = value.Substring(1024, Math.Min(value.Length - 1024, 1024));
                }
                if (value.Length > 2048)
                {
                    p3 = value.Substring(2048, Math.Min(value.Length - 2048, 1024));
                }

                DetailInfo1 = p1;
                DetailInfo2 = p2;
                DetailInfo3 = p3;
            }
        }

        [ModelDefault("Caption", Lang.BO_ARTISTSHOW)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<ArtistShow> Shows
        {
            get { return GetCollection<ArtistShow>("Shows"); }
        }

        public override string GetIDPrefix()
        {
            return "AR";
        }
    }
}