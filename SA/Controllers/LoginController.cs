using SA.DAO;
using SA.Models;
using SA.ViewModel;
using SA.Controllers.Validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SA.Controllers
{
    public class LoginController : Controller
    {
        
        private DepartamentoDAO departamentoDAO;
        private FuncaoDAO funcaoDAO;
        private UsuarioDAO usuarioDAO;

        public bool LoginControllerValidade { get; private set; }

        //Ninject usado aqui!
        public LoginController( DepartamentoDAO dep,FuncaoDAO fun,UsuarioDAO user)
        {
            
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

            if (!usuarioDAO.ExisteUsuario(login.CriaUsuario()))
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

        /// <summary>
        /// Grava um novo usuário no banco de dados
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>ActionResult.</returns>
        public ActionResult Add(Usuario user)
        {

            if (usuarioDAO.ExisteUsuario(user))
            {
                ModelState.AddModelError("Usuario.jaexiste", "CPF já cadastrado");
            }

            if (!UsuarioValidates.Validador(user))
            {
                ModelState.AddModelError("Usuario.tercerizado", "Você informou que essa pessoa é terceira, mas não preencheo o campo [Empresa Tercerizada]");
            }

            if (ModelState.IsValid)
            {
                usuarioDAO.Add(user);
                return RedirectToAction("ListaUsuarios", "Login");
            }
           
            ViewBag.Funcao = funcaoDAO.Lista();
            ViewBag.Departamento = departamentoDAO.Lista();
            ViewBag.Tercerizado = usuarioDAO.SimNaoTerceiro();
            return View("NovoLogin",user);            
        }
       
        /// <summary>
        /// Lista os usuários 
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult ListaUsuarios()
        {
            var model = usuarioDAO.Lista();
            return View(model);
        }

        public ActionResult Excluir()
        {
            return View("ListaUsuarios");
        }


    }
}