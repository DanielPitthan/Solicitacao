using SA.Models;
using SA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.DAO.ViewDAO
{
    public  class SolicitacaoJsonDAO
    {

        /// <summary>
        /// Costroi uma lista de Solicitacoes com base em um lista de ItensSa
        /// </summary>
        /// <param name="itens">The itens.</param>
        /// <returns>Lista de Solicitacoes</returns>
        public static IList<Solicitacao> CriaListaSa(IList<SolicitacaoJSon> itens,Usuario user)
        {
            List<Solicitacao> ListaSa = new List<Solicitacao>();

            foreach (var i in itens)
            {
                ListaSa.Add(i.CriaSingleItemSa(user));
            }
            return ListaSa;

        }
    }
}