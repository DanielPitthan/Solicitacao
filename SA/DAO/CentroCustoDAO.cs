using NHibernate;
using SA.Helpers;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class CentroCustoDAO
    {
        ISession session;

        public CentroCustoDAO (ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Retorna o nome do Centro de Custo
        /// </summary>
        /// <param name="codigo">The codigo.</param>
        /// <returns></returns>
        public string GetNomeCentroDeCusto(string codigo)
        {

            IList<CentroDeCusto> CentroDeCusto  = session.QueryOver<CentroDeCusto>()
                                .Where(c => c.Codigo == codigo)
                                .List();
            return CentroDeCusto[0].Descricao;
            
        }


        /// <summary>
        /// Retorna uma lista de Centro de Custos buscando pelo Nome 
        /// </summary>
        /// <param name="nome">The nome.</param>
        /// <returns></returns>
        public IList<CentroDeCusto> GetCodByName(string nome)
        {
            IList<CentroDeCusto> CentroDeCusto = session.QueryOver<CentroDeCusto>()
                                .WhereRestrictionOn(c=> c.Descricao).IsLike("%"+nome+"%")
                                .List();
            return CentroDeCusto;
        }

    }
}