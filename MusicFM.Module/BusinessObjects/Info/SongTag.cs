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

namespace MusicFM.Module.BusinessObjects.Info
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [CreatableItem(false)]
    [DefaultProperty("TagName")]
    public class SongTag : Tag
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SongTag(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [RuleRequiredField("RequiredRule_SongTag_Song", DefaultContexts.Save, "")]
        [Association]
        public XPCollection<Song> Songs
        {
            get { return GetCollection<Song>("Songs"); }
        }
    }
}