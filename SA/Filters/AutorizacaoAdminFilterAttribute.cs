using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SA.Filters
{
    /// <summary>
    /// Filtro que controla o acesso admin no site
    /// </summary>
    /// <seealso cref="System.Web.Mvc.ActionFilterAttribute" />
    public class AutorizacaoAdminFilterAttribute: ActionFilterAttribute
    {
        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Usuario usuario = (Usuario)filterContext.HttpContext.Session["usuario"];

            if (!usuario.IsAdmin)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Home",
                            action = "Index"
                        }));
            }
        }
    }
}