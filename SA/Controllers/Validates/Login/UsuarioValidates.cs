using SA.Models;
using SA.ViewModel;
using SA.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace SA.Controllers.Validates
{
    public  class UsuarioValidates
    {
        

        public static bool Validador(Usuario user)
        {
            if (user.Tercerizado.Substring(0,1) == "S" & !String.IsNullOrEmpty(user.EmpresaTercerizada))
            {
                return false;
            }

            return true;
        }
    }
}