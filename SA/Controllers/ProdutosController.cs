﻿using SA.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA.Controllers
{
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

        public ActionResult GetLista(string produtoDesci)
        {
            return Json(new { lista = prodDAO.ListaProdutosByDesc(produtoDesci) }, JsonRequestBehavior.AllowGet);
        }

    }
}