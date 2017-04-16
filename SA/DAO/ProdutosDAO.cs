using NHibernate;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class ProdutosDAO
    {
        ISession session;
        public ProdutosDAO (ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Retorna uma lista de produtos pela descrição aproximada
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns>IList&lt;Produtos&gt;.</returns>
        public IList<Produtos> ListaProdutosByDesc(string text)
        {
            string hql = " SELECT p.Codigo,p.Descricao FROM Produtos p" +
            " WHERE p.Tipo IN ('MM')" +
            " AND B1_DESC LIKE :codpord";            
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("codpord", text.ToUpper() + "%");

            return query.List<Produtos>();

        }
    }
}