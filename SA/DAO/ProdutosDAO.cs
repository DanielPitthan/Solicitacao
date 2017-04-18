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
            string hql = " select p from Produtos p" +
            " where p.Tipo in ('MM')" +
            " and p.Descricao LIKE :descri " +
            " order by p.Descricao";
                       
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("descri", text.ToUpper() + "%");
            return query.List<Produtos>();

        }

        /// <summary>
        /// Retorna uma lista vazia
        /// </summary>
        /// <returns>List&lt;Produtos&gt;.</returns>
        public List<Produtos> ListaVazia()
        {
            return new List<Produtos>();
        }

    }
}