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

            //Artist artist = Session.Evaluate<Artist>(CriteriaOperator.Parse("Max(ID)"), null) as Artist;
            //if (artist == null)
            //{
            //    artist.ID = 1.ToString("n6");
            //}
            //else
            //{
            //    int current = Convert.ToInt32(artist.ID);
            //    current += 1;
            //    artist.ID = current.ToString("n6");
            //}
        }

        [ModelDefault("Caption", Lang.BO_SONG)]
        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<Song> Songs
        {
            get { return GetCollection<Song>("Songs"); }
        }

        [ModelDefault("Caption", Lang.BO_ARTIST_BRIEF)]
        public string Brief { get; set; }
    }
}