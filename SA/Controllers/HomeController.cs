using SA.DAO;
using SA.Filters;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA.Controllers
{
    [AutorizacaoFilter]
    public class HomeController : Controller
    {
        SolicitacaoDAO saDAO;

        public HomeController (SolicitacaoDAO saDAO)
        {
            this.saDAO = saDAO;
        }

        // GET: Home
        public ActionResult Index()
        {
            var model = saDAO.Lista();
            return View(model);
        }

        

        public ActionResult FormIncluir()
        {

            ViewBag.TiposRequisicoes = saDAO.TiposRequisicoes();
            return View();
        }

        public ActionResult FormAlterar()
        {
            return View();
        }

        /// <summary>
        /// Faz a validação da SA e adciona a SA no banco de dados 
        /// </summary>
        /// <param name="sa">The sa.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Adicionar(Solicitacao sa)
        {
            if (ModelState.IsValid)
            {
                saDAO.Add(sa);
                return RedirectToAction("Index");
            }
            else
            {
                return View("FormIncluir", sa);
            }
        }

        public ActionResult Alterar()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Excluir()
        {
            return RedirectToAction("Index");
        }

    }
}