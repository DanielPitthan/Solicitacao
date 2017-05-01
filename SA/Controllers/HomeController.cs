using SA.Controllers.Validates.Solicitacao;
using SA.DAO;
using SA.Factorys;
using SA.Filters;
using SA.Models;
using SA.ViewModel;
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
        Usuario user;
        SolicitacaoDAO saDAO;        
        DepartamentoDAO depDAO;
        ProdutosDAO prodDAO;
        bool jsonIsvalid =true;
        List<string> errors = new List<string>();

        public HomeController (SolicitacaoDAO saDAO, DepartamentoDAO dep, ProdutosDAO prd)
        {
            this.saDAO = saDAO;
            this.depDAO = dep;
            this.prodDAO = prd;
         

        }

        // GET: Home
        public ActionResult Index()
        {
            //Recupera o usuário da sessão            
            user = (Usuario)Session["usuario"];

            ViewBag.Usuario = user;
            var model = saDAO.Lista(user);
            return View(model);
        }

        
        /// <summary>
        /// Formulário de inclusão das SA
        /// </summary>
        /// <returns></returns>
        public ActionResult FormIncluir()
        {
            ViewBag.jsonIsvalid = this.jsonIsvalid;
            ViewBag.TiposRequisicoes = ChoiceFactory.ListaTiposRequisicoes();
            ViewBag.Departamento = depDAO.Lista();
            ViewBag.json = null;
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
        public ActionResult Adicionar(IList<SolicitacaoJSon> itenSa)
        {
            user = (Usuario)Session["usuario"];

            if (!SolicitacaoValidates.ProdutoValidate(itenSa,prodDAO))
            {
                ModelState.AddModelError("ProdutoInvalido","Há um código de produto Inválido. Corrija antes de continuar.");
                errors.Add( "Há um código de produto Inválido. Corrija antes de continuar.");
                ViewBag.Error = errors;
                this.jsonIsvalid = false;
            }

            if (!SolicitacaoValidates.QuantidadeValidate(itenSa, prodDAO))
            {
                ModelState.AddModelError("QuantidadeInvalida", "Há um produto com a quantidade inválida. Corrija antes de continuar.");
                this.jsonIsvalid = false;
            }
            

            if (this.jsonIsvalid)
            {
                saDAO.Add(SolicitacaoFactory.CriaListaSolicitacao(itenSa,user));
                return new EmptyResult();
            }
            else
            {

                ViewBag.jsonIsvalid = this.jsonIsvalid;
                ViewBag.TiposRequisicoes = ChoiceFactory.ListaTiposRequisicoes();
                ViewBag.Departamento = depDAO.Lista();
                ViewBag.json = itenSa;

                //Converte o itenSA em Solicitacao e devolve para a view
                return View("FormIncluir");
                
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