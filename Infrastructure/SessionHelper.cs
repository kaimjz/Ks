using System;
using System.Web;

namespace Infrastructure
{
    public class SessionHelper
    {
        /// <summary>
        /// 添加session
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void AddSession(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                return;
            }
            HttpContext rq = HttpContext.Current;
            rq.Session.Timeout = 720;
            rq.Session[key] = value;
        }

        /// <summary>
        /// 清除某个session
        /// </summary>
        /// <param name="key"></param>
        public static void ClearSession(string key)
        {
            try
            {
                HttpContext rq = HttpContext.Current;
                rq.Session[key] = null;
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 获取某个session
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSession(string key)
        {
            try
            {
                HttpContext rq = HttpContext.Current;
                var session = rq.Session[key] as string;
                return session ?? "";
            }
            catch (Exception)
            {
            }
            return "";
        }
    }
}