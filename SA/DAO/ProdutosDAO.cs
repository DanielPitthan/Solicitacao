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
            string sql = " SELECT B1_COD,B1_DESC FROM SB1010" +
            " WHERE B1_TIPO IN ('MM')" +
            " AND B1_DESC LIKE '" + text.ToUpper() + "%' ";
            
            IQuery query = session.CreateSQLQuery(sql);
           // query.SetParameter("nome", text.ToUpper() + "%");

            return query.List<Produtos>();

        }
    }
}