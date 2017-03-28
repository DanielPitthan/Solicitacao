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


        /// <summary>
        /// Valida se o Login do Fulano está válido 
        /// </summary>
        /// <param name="login">The login.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
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

        /// <summary>
        /// Salva um novo Login no Banco de Dados 
        /// </summary>
        /// <param name="log">The log.</param>
        public void Add (Usuario user)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(user);
            tran.Commit();

        }

        /// <summary>
        /// Altera um usuario no banco de dados
        /// </summary>
        /// <param name="user">The user.</param>
        public void Alter (Usuario user)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(user);
            tran.Commit();
        }

        /// <summary>
        /// Taca fogo em um usuário do banco de dados 
        /// </summary>
        /// <param name="user">The user.</param>
        public void Delete(Usuario user)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(user);
            tran.Commit();
        }

    }
}