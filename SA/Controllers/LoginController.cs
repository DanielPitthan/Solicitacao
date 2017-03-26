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
        
        //Ninject usado aqui!
        public LoginController(LoginDAO login)
        {
            this.loginDAO = login;
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

            //ViewBag.Usuarios = this.usuarioDAO.Lista();
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