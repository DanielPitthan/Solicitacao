using SA.DAO;
using SA.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA.Controllers
{
    [AutorizacaoFilter]
    public class ProdutosController : Controller
    {
        ProdutosDAO prodDAO;

        public ProdutosController(ProdutosDAO prd)
        {
            this.prodDAO = prd;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetLista(string produtoDesci)
        {
            return Json(new { lista = prodDAO.ListaProdutosByDesc(produtoDesci) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetEstoque( string produtoCod)
        {
            if (String.IsNullOrEmpty(produtoCod))
            {
                return Json(new { estoque = 0 }, JsonRequestBehavior.AllowGet);
            }              
            else
            {
                return Json(new { estoque = prodDAO.GetEstoque(produtoCod) }, JsonRequestBehavior.AllowGet);
            }
            
            
        }

    }
}