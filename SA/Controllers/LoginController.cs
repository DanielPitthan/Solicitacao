using SA.DAO;
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
        public ActionResult ValidarLogin(string numCPF)
        {
            Login login = new Login();
            login.Cpf = numCPF;
            login.Valido =  loginDAO.ValidaLogin(login);         


            if (!login.Valido)
            {
                //Se o login não é válido, retorna mensagem, ou algo assim
                return View("Index", login);
            }

            //Se tudo deu certo, redireciona para a Home do Caboclo
            return RedirectToAction("Index", "Home");
        }
    }
}