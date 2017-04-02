using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.ViewModel
{
    public class Login
    {
        public string Cpf { get; set; }
        public bool Valido { get; set; }
        //public string Login {get;set;}
        //public string Password {get;set;}
    
        public Usuario CriaUsuario()
        {
            Usuario user = new Usuario();
            {
                user.Cpf = this.Cpf;
            }
                         
            return user;
        }
                   
    }

}