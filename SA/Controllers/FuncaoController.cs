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
    [AutorizacaoAdminFilter]
    public class FuncaoController : Controller
    {
        private FuncaoDAO FuncaoDAO; 

        public FuncaoController(FuncaoDAO fun)
        {
            this.FuncaoDAO = fun;
        }

       
        public ActionResult Index()
        {
            IList<Funcao> deps = FuncaoDAO.Lista();
            return View(deps);
        }

        /// <summary>
        /// Formulário de inclusão desse Controller
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FormInclui()
        {           
            return View();
        }

        /// <summary>
        /// Formulário de Alteração desse Controller 
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FormAltera( int id)
        {
            var model = FuncaoDAO.GetById(id);
            return View(model);
        }


        /// <summary>
        /// Adciona uma novo Funcao
        /// </summary>
        /// <param name="dep">The dep.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Adiciona(Funcao dep)
        {
            if (ModelState.IsValid)
            {
                FuncaoDAO.Add(dep);
                return RedirectToAction("Index", "Funcao");
            }else
            {
                return View("Form",dep);
            }
        }

        /// <summary>
        /// Alteração de um Funcao
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Alterar (Funcao dep)
        {
            FuncaoDAO.Alter(dep);
            return RedirectToAction("Index", "Funcao");
        }


        /// <summary>
        /// Exclui uma função 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Excluir (int id)
        {
            FuncaoDAO.Delete(FuncaoDAO.GetById(id));
            return RedirectToAction("Index");
        }

    }
}