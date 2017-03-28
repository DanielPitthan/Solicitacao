using NHibernate;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class DepartamentoDAO
    {
        ISession session;

        public DepartamentoDAO(ISession session)
        {
            this.session = session;
        }

        //Lista os departamentos 
        public IList<Departamento> Lista()
        {
            string hql = "select d from Departamento d";
            IQuery query = session.CreateQuery(hql);
            return query.List<Departamento>();
        }

        /// <summary>
        /// Grava um departamento no banco de dados 
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Add(Departamento dep)
        {
            ITransaction tran = session.BeginTransaction();
            session.Save(dep);
            tran.Commit();
        }

        /// <summary>
        /// Altera um departamento no banco de dados 
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Alter (Departamento dep)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(dep);
            tran.Commit();
        }

        /// <summary>
        /// Exclui um departamento no banco de dados
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Delete(Departamento dep)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(dep);
            tran.Commit();
        }

    }
}