using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.ViewModels
{
    public class SolicitacaoWeb
    {
        public string Codigo { get; set; } //Chave ÚNICA
        public string Produto { get; set; }
        public double Quantidade { get; set; }
        public string Observacao { get; set; }
        public string TipoReq { get; set; }
        public string NumOS { get; set; }
    }
}