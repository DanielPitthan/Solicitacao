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
        Usuario user;
        DepartamentoDAO depDAO;

        public HomeController (SolicitacaoDAO saDAO, DepartamentoDAO dep)
        {
            this.saDAO = saDAO;
            this.depDAO = dep;
        }

        // GET: Home
        public ActionResult Index()
        {
            //Recupera o usuário da sessão
            Usuario user = (Usuario)Session["usuario"];
            ViewBag.Usuario = user;
            var model = saDAO.Lista();
            return View(model);
        }

        
        /// <summary>
        /// Formulário de inclusão das SA
        /// </summary>
        /// <returns></returns>
        public ActionResult FormIncluir()
        {
            ViewBag.Solicitacao = saDAO.ListaByCodigo("000100");
            ViewBag.TiposRequisicoes = saDAO.TiposRequisicoes();
            ViewBag.Departamento = depDAO.Lista();
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

            saDAO.Add(sa);
            ViewBag.Solicitacao = saDAO.ListaByCodigo("000100");
            return View("FormIncluir");

            if (ModelState.IsValid)
            {
                saDAO.Add(sa);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.TiposRequisicoes = saDAO.TiposRequisicoes();
                ViewBag.Departamento = depDAO.Lista();
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