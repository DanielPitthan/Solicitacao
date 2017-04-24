using SA.DAO;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.ViewModel
{
    /// <summary>
    /// Classe resposável por representar o Json de uma Solicitação ao Almoxarifiado
    /// </summary>
    public class SolicitacaoJSon
    {
        
        
        public string TipoRequisicao { get; set; }
        public int TipoRequisicaoValor { get; set; }
        public string NumeroReq { get; set; }
        public string CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public double QuantidadeEstoque { get; set; }
        public double QuantidadeSolicitada { get; set; }
        public string Departamento { get; set; }
        public int DepartamentoValor { get; set; }
        public string CentroCusto { get; set; }
        public string Observacao { get; set; }




        /// <summary>
        /// Método resposável por criar e devolver uma Solicitação com base no SolicitacaoJson
        /// </summary>
        /// <returns></returns>
        public Solicitacao CriaSA()
        {
            Solicitacao sa = new Solicitacao();
            
            
            
            string data = DateTime.Now.ToString("yyyyMMdd");
            string hora = DateTime.Now.ToString("HH:mm:ss");
            sa.Data = data;
            sa.Hora = hora;            
            sa.CentroCusto = this.CentroCusto;
            sa.NUMTPR = this.NumeroReq;
            sa.Observacao = this.Observacao;
            sa.Produto = this.CodigoProduto;
            sa.Quantidade = this.QuantidadeSolicitada;
            sa.TipoRequisicao = this.TipoRequisicao;
            sa.StatusAtual = "Aguardando Processamento " + DateTime.Now.ToString();
            return sa;
    }

    }

}