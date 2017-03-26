using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SA.Models
{
    public class Solicitacao
    {
        public virtual string Filial { get; set; }
        public virtual string Codigo { get; set; } //Sequencial
        public virtual string Produto { get; set; } //Código do produto 
        public virtual double Quantidade { get; set; } //Quantidade
        public virtual string Observacao { get; set; }
        public virtual string Usuario { get; set; }//CPF do usuário
        public virtual string Data { get; set; }
        public virtual string Hora { get; set; }
        public virtual string CentroCusto { get; set; }
        public virtual string StatusAtual { get; set; }
        public virtual string TipoRequisicao { get; set; }
        public virtual string NUMTPR { get; set; }
        public virtual int DELETE { get; set;}
        public virtual int R_E_C_N_O_ { get; set; }
    }
}