using SA.DAO;
using SA.Models;
using SA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SA.Controllers
{
    public class LoginController : Controller
    {
        private LoginDAO loginDAO;
        private DepartamentoDAO departamentoDAO;
        private FuncaoDAO funcaoDAO;
        private UsuarioDAO usuarioDAO;

        //Ninject usado aqui!
        public LoginController(LoginDAO login, DepartamentoDAO dep,FuncaoDAO fun,UsuarioDAO user)
        {
            this.loginDAO = login;
            this.departamentoDAO = dep;
            this.funcaoDAO = fun;
            this.usuarioDAO = user;
        }

        //Home Page do Login
        public ActionResult Index()
        {
            
            return View(new Login());
        }

        /// <summary>
        ///  Valida se o Login está válido 
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ValidarLogin(Login login)
        { 
           login.Valido =  loginDAO.ValidaLogin(login);         

            if (!login.Valido)
            {
                //Se o login não é válido, retorna mensagem, ou algo assim
                return PartialView("Login/_Login", login);
            }
            //Se tudo deu certo, redireciona para a Home do Caboclo
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Formulário de criação de Login
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult NovoLogin()
        {
            ViewBag.Funcao = funcaoDAO.Lista();
            ViewBag.Departamento = departamentoDAO.Lista();
            ViewBag.Tercerizado = usuarioDAO.SimNaoTerceiro();
            return View();
        }

        public ActionResult Add(Usuario user)
        {
            return RedirectToAction("ListaUsuarios", "Login");
        }

        /// <summary>
        /// Lista os usuários 
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ListaUsuarios()
        {
            return View();
        }


    }
}