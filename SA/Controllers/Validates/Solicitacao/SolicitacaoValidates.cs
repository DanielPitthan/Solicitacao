using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SA.Models;
using SA.ViewModel;
using SA.DAO;

namespace SA.Controllers.Validates.Solicitacao
{
    public static class SolicitacaoValidates
    {

        /// <summary>
        /// Valida a quantidade solicitada se ela pode ser atendida
        /// </summary>
        /// <param name="sa">The sa.</param>
        /// <returns>retorna falso para o primeiro item inválido</returns>
        public static bool QuantidadeValidate(IList<SolicitacaoJSon> sa, ProdutosDAO dao )
        {
            foreach (var q in sa)
            {
                if(q.QuantidadeEstoque<=0 || q.QuantidadeEstoque < q.QuantidadeSolicitada || dao.GetEstoque(q.CodigoProduto)<=0)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Valida se o código de produto exite
        /// </summary>
        /// <param name="sa">The sa.</param>
        /// <param name="dao">The DAO.</param>
        /// <returns>Retorna false se o código do produto não existir</returns>
        public static bool ProdutoValidate(IList<SolicitacaoJSon> sa, ProdutosDAO dao)
        {
            if (sa == null)
            {
                return false;
            }
                
            

            foreach (var q in sa)
            {
                if (dao.GetProdutoByCod(q.CodigoProduto)==null)
                {
                    return false;
                }
            }
            return true;
        }

    }
}