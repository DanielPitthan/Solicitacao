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
    public class DepartamentoController : Controller
    {
        private DepartamentoDAO departamentoDAO;
        private CentroCustoDAO centroDeCustoDao;

        public DepartamentoController(DepartamentoDAO dep, CentroCustoDAO ccdao)
        {
            this.departamentoDAO = dep;
            this.centroDeCustoDao = ccdao;
        }

       
        public ActionResult Index()
        {
            IList<Departamento> deps = departamentoDAO.Lista();
            return View(deps);
        }

        /// <summary>
        /// Formulário de inclusão desse Controller
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FormInclui()
        {
            
            ViewBag.ModeloValido = ModelState.IsValid;
            return PartialView("Departamento/_FormInclui");
        }

        /// <summary>
        /// Formulário de Alteração desse Controller 
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult FormAltera( int id)
        {
            ViewBag.ModeloValido = ModelState.IsValid;
            var model = departamentoDAO.GetById(id);
            return View(model);
        }


        /// <summary>
        /// Adciona uma novo Departamento
        /// </summary>
        /// <param name="dep">The dep.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Adiciona(Departamento dep)
        {
            if (ModelState.IsValid)
            {
                departamentoDAO.Add(dep);
                return RedirectToAction("Index", "Departamento");
            }else
            {
                ViewBag.ModeloValido = ModelState.IsValid;
                return PartialView("Departamento/_FormInclui");
            }
        }

        /// <summary>
        /// Alteração de um Departamento
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Alterar (Departamento dep)
        {
            departamentoDAO.Alter(dep);
            return RedirectToAction("Index", "Departamento");
        }


        /// <summary>
        /// Faz a exclusão de um departamento 
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ActionResult.</returns>
        //[HttpPost]
        public ActionResult Excluir (int id)
        {
            departamentoDAO.Delete(departamentoDAO.GetById(id));
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetListaCentroDeCusto (string centroDeCusto)
        {
            return Json(new { sucess = true,lista = centroDeCustoDao.GetCodByName(centroDeCusto.ToUpper()) });
        }


    }
}