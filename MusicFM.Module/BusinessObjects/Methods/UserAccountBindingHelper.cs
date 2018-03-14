using MusicFM.Module.BusinessObjects.Account;
using MusicFM.Module.BusinessObjects.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicFM.Module.BusinessObjects.Methods
{
    public static class UserAccountBindingHelper
    {
        public static void Authenticate(this UserAccountBinding accountBinding)
        {
            if (accountBinding.Platform == AccountPlatform.Wechat)
                AuthenticateWechat(accountBinding);

            if (accountBinding.Platform == AccountPlatform.SinaWeibo)
                AuthenticateSinaWeibo(accountBinding);

            if (accountBinding.Platform == AccountPlatform.QQ)
                AuthenticateQQ(accountBinding);
        }

        private static void AuthenticateWechat(UserAccountBinding accountBinding)
        {
            //todo:
        }

        private static void AuthenticateSinaWeibo(UserAccountBinding accountBinding)
        {
            //todo:
        }

        private static void AuthenticateQQ(UserAccountBinding accountBinding)
        {
            //todo:
        }
    }
}
