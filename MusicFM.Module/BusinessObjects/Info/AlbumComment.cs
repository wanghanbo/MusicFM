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
using MusicFM.Module.BusinessObjects.Base;

namespace MusicFM.Module.BusinessObjects.Info
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [CreatableItem(false)]
    [DefaultProperty("Content")]
    public class AlbumComment : Comment
    { 
        public AlbumComment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [RuleRequiredField("RequiredRule_AlbumComment_Album", DefaultContexts.Save, "")]
        [Association]
        public Album Album { get; set; }
    }
}