using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Infrastructure;

namespace Ks.Manager
{
    public class GlobalInfo
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public static string UserId
        {
            get
            {
                return SessionHelper.GetSession("Ks_UserId");
            }
            set
            {
                SessionHelper.AddSession("Ks_UserId", value);
            }
        }
    }
}