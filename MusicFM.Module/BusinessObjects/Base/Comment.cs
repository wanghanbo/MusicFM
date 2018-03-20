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

namespace MusicFM.Module.BusinessObjects.Base
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [CreatableItem(false)]
    [ModelDefault("Caption", Lang.BO_COMMENT)]
    [DefaultProperty("Content")]
    public class Comment : BaseObject
    { 
        public Comment(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        [RuleRequiredField("RequiredRule_Comment_User", DefaultContexts.Save, "")]
        [ModelDefault("Caption", Lang.BO_USER)]
        [Association]
        public User User { get; set; }

        [RuleRequiredField("RequiredRule_Comment_Time", DefaultContexts.Save, "")]
        [ModelDefault("Caption", Lang.BO_COMMENT_TIME)]
        public DateTime Time { get; set; }

        [RuleRequiredField("RequiredRule_Comment_Content", DefaultContexts.Save, "")]
        [ModelDefault("Caption", Lang.BO_COMMENT_CONTENT)]
        public String Content { get; set; }

        [Browsable(false)]
        [Association]
        public Comment ParentComment { get; set; }

        [Association, DevExpress.Xpo.Aggregated]
        public XPCollection<Comment> Replies
        {
            get { return GetCollection<Comment>("Replies"); }
        }

        [ModelDefault("Caption", Lang.BO_COMMENT_NICECOUNT)]
        public int NiceCount { get; set; }
    }
}