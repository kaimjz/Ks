using System.Web.Mvc;
using Infrastructure;

namespace Ks.MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string Login(string loginName, string password)
        {
            var resp = new Response();
            resp.Status = loginName == "1" && password == "3";
            if (resp.Status)
            {
                resp.Result = "/Home/Index";
            }
            else
            {
                resp.Result = "登录失败";
            }
            return JsonHelper.Instance.Serialize(resp);
        }
    }
}