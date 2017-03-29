using NHibernate;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class FuncaoDAO
    {
        ISession session;

        public FuncaoDAO(ISession session)
        {
            this.session = session;
        }

        //Lista as Funcoes
        public IList<Funcao> Lista()
        {
            string hql = "select f from Funcao f";
            IQuery query = session.CreateQuery(hql);
            return query.List<Funcao>();
        }

        /// <summary>
        /// Grava uma fucao no banco de dados 
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Add(Funcao dep)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(dep);
            tran.Commit();
        }

       
        /// <summary>
        /// Procura um departamenteo pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Funcao GetById(int id)
        {
            string hql = "select d from Funcao d where d.Id= :id";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("id", id);
            return query.UniqueResult<Funcao>();
        }

        /// <summary>
        /// Altera um Funcao no banco de dados 
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Alter (Funcao dep)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(dep);
            tran.Commit();
        }

        /// <summary>
        /// Exclui um Funcao no banco de dados
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Delete(Funcao dep)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(dep);
            tran.Commit();
        }

    }
}