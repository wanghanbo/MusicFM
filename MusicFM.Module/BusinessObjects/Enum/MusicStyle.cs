using DevExpress.ExpressApp.Model;
using MusicFM.Module.Language;

namespace MusicFM.Module.BusinessObjects.Enum
{
    public enum MusicStyle
    {
        [ModelDefault("Caption", Lang.ENUM_MUSTYLE_RB)]
        RB,
        [ModelDefault("Caption", Lang.ENUM_MUSTYLE_JAZZ)]
        Jazz,
        [ModelDefault("Caption", Lang.ENUM_MUSTYLE_ROCK)]
        Rock,
        [ModelDefault("Caption", Lang.ENUM_MUSTYLE_BLUE)]
        Blue,
        [ModelDefault("Caption", Lang.ENUM_MUSTYLE_ELECTRONIC)]
        Electronic,
    }
}