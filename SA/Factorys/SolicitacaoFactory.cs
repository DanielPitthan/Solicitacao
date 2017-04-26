using SA.Models;
using SA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Factorys
{
    public static class SolicitacaoFactory
    {
        /// <summary>
        /// Cria uma lista de solicitação 
        /// </summary>
        /// <param name="saJason">The sa jason.</param>
        /// <returns>Lista de Solicitação</returns>
        public static IList<Solicitacao> CriaListaSolicitacao(IList<SolicitacaoJSon> saJason,Usuario u)
        {
            List<Solicitacao> sa = new List<Solicitacao>();

            foreach (var s in saJason)
            {
                sa.Add(s.CriaSingleItemSa(u));
            }
            return sa;

        }
        
    }
}