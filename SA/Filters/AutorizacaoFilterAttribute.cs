using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SA.Filters
{

    /// <summary>
    /// Filtra os usuários comuns do site
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionFilterAttribute" />
    public class AutorizacaoFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuario"];
            if (usuario == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Login",
                            action = "Index"
                        }));
            }
        }
    }
}