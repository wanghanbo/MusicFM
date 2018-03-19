using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using MusicFM.Module.BusinessObjects.Media;
using MusicFM.Module.Language;

namespace MusicFM.Module.BusinessObjects.Record
{
    [DefaultClassOptions]
    [ModelDefault("Caption", Lang.BO_USERPLAYERSONGRECORD)]
    [NavigationItem(false)]
    [CreatableItem(false)]
    [DefaultProperty("PlayDate")]
    public class SongPlayRecord : BaseObject
    {
        public SongPlayRecord(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        [Browsable(false)]
        [ModelDefault("Capiton", Lang.BO_USER)]
        [Association]
        public User User { get; set; }

        [ModelDefault("Capiton", Lang.BO_SONG)]
        public Song Song { get; set; }
        
        [ModelDefault("Caption", Lang.BO_USERPLAYERSONGRECORD_PLAYDATE)]
        public DateTime PlayDate { get; set; }
    }
}
