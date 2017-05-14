using SA.DAO;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA.Controllers
{
    public class CentroDeCustosController : Controller
    {
        private CentroCustoDAO centroCustoDAO;


        public CentroDeCustosController(CentroCustoDAO cc)
        {
            this.centroCustoDAO = cc;      
        }

        // GET: CentroDeCustos
        public ActionResult Index()
        {
            return View();
        }

      
    }
}