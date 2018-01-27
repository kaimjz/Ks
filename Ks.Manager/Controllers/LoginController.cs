using System;
using System.Web.Mvc;
using Infrastructure;
using Ks.Domain;
using Infrastructure.Cache;
using Ks.Models;
using Newtonsoft.Json.Linq;

namespace Ks.Manager.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Login(string loginName, string password)
        {
            var resp = new Response()
            {
                Status = false
            };
            var userM = new AuthoriseService().FindUser(loginName);
            if (userM == null)
            {
                resp.Result = "暂无此用户";
            }
            else if (userM.Status == 0)
            {
                resp.Result = "用户已停用";
            }
            else if (userM.Password != password)
            {
                resp.Result = "密码错误";
            }
            else
            {
                resp.Status = true;
                AuthoriseService.User = userM;
                resp.Result = "/Index";
            }
            return JsonHelper.Instance.Serialize(resp);
        }
    }
}