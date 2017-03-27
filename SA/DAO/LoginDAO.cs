using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SA.ViewModel;
using SA.Helpers;
using NHibernate;
using SA.Models;

namespace SA.DAO
{
    public class LoginDAO
    {

        ISession session;

        //Ninject vai alimentar o ISession 
        public LoginDAO(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Retorna uma lista de usuários
        /// </summary>
        /// <returns>IList&lt;Usuario&gt;.</returns>
        public IList<Usuario> Lista() {


            string hql = "select u from Usuario u ";
            IQuery query = this.session.CreateQuery(hql);
            return query.List<Usuario>();
        }
            
        
        public bool ValidaLogin(Login login)
        {
            //using(ISession session = NHibernateHelper.OpenSession())
            //{
                string hql = "select u from Usuario u where u.Cpf = :cpf ";
                IQuery query = this.session.CreateQuery(hql);
                query.SetParameter("cpf", login.Cpf);

                Login usuario= query.UniqueResult<Login>();
                if(usuario==null)
                {
                    return false;
                }
                
            //}
            return true;
        }
    }
}