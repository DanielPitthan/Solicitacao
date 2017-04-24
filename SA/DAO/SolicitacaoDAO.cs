using NHibernate;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class SolicitacaoDAO
    {
        ISession session;
        UsuarioDAO userDAO;

        public SolicitacaoDAO (ISession session, UsuarioDAO usuario )
        {
            this.session = session;
            this.userDAO = usuario;
        }

        /// <summary>
        /// retorna uma Lista de Solicitações da sessão atual do usuário
        /// </summary>
        /// <returns>IList&lt;Solicitacao&gt;.</returns>
        public IList<Solicitacao> Lista()
        {
            string hql = "select s from Solicitacao s";
            IQuery query = session.CreateQuery(hql);
            return query.List<Solicitacao>();
        }
        /// <summary>
        /// Lista um grupo de solicitacao por Codigo
        /// </summary>
        /// <returns></returns>
        public IList<Solicitacao> ListaByCodigo(string cod)
        {
            string hql = "select s from Solicitacao s where Codigo = :cod";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("cod", cod);
            return query.List<Solicitacao>();
        }

        /// <summary>
        /// Retorna uma Solicitacao buscando pelo código dela
        /// </summary>
        /// <returns>GetBySa.</returns>
        public Solicitacao GetBySa(string sa)
        {
            string hql = "select s from Solicitacao s where s.Codigo = :sa ";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("sa", sa);
            return query.UniqueResult<Solicitacao>();
        }

        /// <summary>
        /// Grava uma nova solicitacao no banco de dados
        /// </summary>
        /// <param name="sa">The sa.</param>
        public void Add(Solicitacao sa)
        {
            //sa.Sacrementada = false;
            //sa.Codigo = "000100";
            //sa.R_E_C_N_O_ = RECNO.GetNextRecno("Z11010");
            //session.Save(sa);
        }

        /// <summary>
        /// Faz a exclusão de uma solicitacao
        /// </summary>
        /// <param name="sa">The sa.</param>
        public void Delete (string sa)
        {
            //TODO
            //Verificar se a SA já não foi consumida 
            session.Delete(GetBySa(sa));
        }

        /// <summary>
        /// Altera uma solicitacao no banco de dados
        /// </summary>
        /// <param name="sa">The sa.</param>
        public void Alter(Solicitacao sa)
        {
            session.Merge(sa);
        }


        /// <summary>
        /// Tipos de Requisições Válidas
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public IList<string> TiposRequisicoes()
        {
            List<string> t = new List<string>();
            t.Add("OU");
            t.Add("OS");
            t.Add("CO");
            return (t);
        }


    }
}