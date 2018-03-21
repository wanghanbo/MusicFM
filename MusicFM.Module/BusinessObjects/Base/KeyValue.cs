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

namespace MusicFM.Module.BusinessObjects.Base
{
    [DefaultClassOptions]
    [NavigationItem(false)]
    [CreatableItem(false)]
    public class KeyValue : BaseObject
    { 
        public KeyValue(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        public string Key;
        public string Value;
    }
}