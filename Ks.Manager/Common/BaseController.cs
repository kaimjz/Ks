using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Infrastructure;
using Ks.Domain;
using Ks.Manager.Common;

namespace Ks.Manager.Controllers
{
    public class BaseController : Controller
    {
        protected Response Result = new Response();

        //protected ModuleView CurrentModule;
        protected string ControllerName;   //当前控制器小写名称

        protected string ActionName;        //当前Action小写名称

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            ControllerName = Request.RequestContext.RouteData.Values["controller"].ToString().ToLower();
            ActionName = filterContext.ActionDescriptor.ActionName.ToLower();
            var function = this.GetType().GetMethods().FirstOrDefault(u => u.Name.ToLower() == ActionName);
            if (function == null)
            {
                //throw new Exception("未能找到Action");
                filterContext.Result = new RedirectResult("/Login");
                return;
            }
            var authorize = function.GetCustomAttribute(typeof(AuthenticateAttribute));
            if (authorize != null && AuthoriseService.User == null)
            {
                filterContext.Result = new RedirectResult("/Login");
                return;
            }
        }
    }
}