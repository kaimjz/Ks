using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace Ks.Manager.Common
{
    public class JobjectModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //需要判断前端是否是FormData
            var obj = new JObject();
            var request = controllerContext.HttpContext.Request;
            foreach (var key in request.Form.AllKeys)
            {
                obj[key] = request.Form[key];
            }
            return obj;
        }
    }
}