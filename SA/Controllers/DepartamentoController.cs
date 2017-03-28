using SA.DAO;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA.Controllers
{
    public class DepartamentoController : Controller
    {
        private DepartamentoDAO departamentoDAO; 

        public DepartamentoController(DepartamentoDAO dep)
        {
            this.departamentoDAO = dep;
        }

       
        public ActionResult Index()
        {
            IList<Departamento> deps = departamentoDAO.Lista();
            return View(deps);
        }

        /// <summary>
        /// Formulário desse Controller
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FormInclui()
        {           
            return View();
        }

        /// <summary>
        /// Formulário de Alteração 
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FormAltera( int id)
        {
            var model = departamentoDAO.GetById(id);
            return View(model);
        }


        /// <summary>
        /// Adciona uma novo Departamento
        /// </summary>
        /// <param name="dep">The dep.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Adiciona(Departamento dep)
        {
            if (ModelState.IsValid)
            {
                departamentoDAO.Add(dep);
                return RedirectToAction("Index", "Departamento");
            }else
            {
                return View("Form",dep);
            }
        }

        public ActionResult Alterar (Departamento dep)
        {
            departamentoDAO.Alter(dep);
            return RedirectToAction("Index", "Departamento");
        }

    }
}