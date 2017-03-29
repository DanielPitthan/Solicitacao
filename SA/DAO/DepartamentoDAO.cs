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

        public void GetByName(string nome)
        {
            string hql = "select d from Departamento d where d.Departamentos ";
            
        }

        /// <summary>
        /// Procura um departamenteo pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Departamento GetById(int id)
        {
            string hql = "select d from Departamento d where d.Id= :id";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("id", id);
            return query.UniqueResult<Departamento>();
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