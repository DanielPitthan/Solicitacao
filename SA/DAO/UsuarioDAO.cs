using NHibernate;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class UsuarioDAO
    {
        ISession session;

        public UsuarioDAO(ISession session)
        {
            this.session = session;
        }

        public IList<string> SimNaoTerceiro()
        {
            IList<string> sn = new List<string>();
            sn.Add("Não");
            sn.Add("Sim");

            return sn;
        }
    }
}