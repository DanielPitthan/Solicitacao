using SA.DAO;
using SA.Models;
using SA.ViewModel;
using SA.Controllers.Validates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SA.Filters;

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
        /// Lista os usuários 
        /// </summary>
        /// <returns>ActionResult.</returns>       
        [AutorizacaoAdminFilter]        
        public ActionResult ListaUsuarios()
        {
            var model = usuarioDAO.Lista();
            return View(model);
        }

        /// <summary>
        ///  Valida se o Login está válido 
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ValidarLogin(Login login)
        {
            Usuario usuario = usuarioDAO.ExisteUsuario(login.CriaUsuario());

            if (usuario !=null)
            {
                //Abre a sessão do usuário 
                Session["usuario"] = usuario;
                Session.Timeout = 10; 

                //Se tudo deu certo, redireciona para a Home do Caboclo
                return RedirectToAction("Index", "Home");
                
            }
            //Se o login não é válido, retorna mensagem, ou algo assim
            return PartialView("Login/_Login", login);

        }

        /// <summary>
        /// Formulário de criação de Login
        /// </summary>
        /// <returns>ActionResult.</returns>
        [AutorizacaoAdminFilter]
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
        [HttpPost]
        public ActionResult Add(Usuario user)
        {
            Usuario usuario = usuarioDAO.ExisteUsuario(user);

            if (usuario==null)
            {
                ModelState.AddModelError("Usuario.jaexiste", "CPF já cadastrado");
            }

            if (!UsuarioValidates.TercerizadoValidate(user))
            {
                ModelState.AddModelError("Usuario.tercerizado", "Você informou que essa pessoa é terceira, mas não preencheo o campo [Empresa Tercerizada]");
            }

            if (!UsuarioValidates.CpfValidate(user.Cpf))
            {
                ModelState.AddModelError("Usuario.CPF", "Número de CPF Inválido");
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
        /// Faz a exclusão de usuário
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Excluir(string cpf)
        {
            usuarioDAO.Delete(usuarioDAO.GetByCpf(cpf));
            return RedirectToAction("ListaUsuarios");
        }

        /// <summary>
        /// Faz a chamada do formulário de alteração
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>ActionResult.</returns>
        [AutorizacaoAdminFilter]
        public ActionResult FormAltera(string cpf)
        {
            ViewBag.Funcao = funcaoDAO.Lista();
            ViewBag.Departamento = departamentoDAO.Lista();
            ViewBag.Tercerizado = usuarioDAO.SimNaoTerceiro();


            var model = usuarioDAO.GetByCpf(cpf);
            return View("FormAltera",model);
        }

        /// <summary>
        /// Processo de alteração do cadastro
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>ActionResult.</returns>
        [HttpPost]
        public ActionResult Alterar(Usuario user)
        {
            
            if (!UsuarioValidates.TercerizadoValidate(user))
            {
                ModelState.AddModelError("Usuario.tercerizado", "Você informou que essa pessoa é terceira, mas não preencheo o campo [Empresa Tercerizada]");
            }

            if (!UsuarioValidates.CpfValidate(user.Cpf))
            {
                ModelState.AddModelError("Usuario.CPF", "Número de CPF Inválido");
            }

            if (ModelState.IsValid)
            {
                usuarioDAO.Alter(user);
                return RedirectToAction("ListaUsuarios");
            }

            ViewBag.Funcao = funcaoDAO.Lista();
            ViewBag.Departamento = departamentoDAO.Lista();
            ViewBag.Tercerizado = usuarioDAO.SimNaoTerceiro();
            return View("FormAltera", user);

        }

        /// <summary>
        /// Encerra a sessão e retona para a tela de login
        /// </summary>
        /// <returns>ActionResult.</returns>
        public ActionResult Logout()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index","Login");
        }

    }
}