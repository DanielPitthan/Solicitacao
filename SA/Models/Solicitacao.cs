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

        
        public virtual string Codigo { get; set; } //Código da Solicitacao

        [Required]
        public virtual string Produto { get; set; } //Código do produto 

        [Required]
        public virtual double Quantidade { get; set; } //Quantidade


        public virtual string Observacao { get; set; }

        public virtual string Usuario { get; set; }//CPF do usuário
        public virtual string Data { get; set; }
        public virtual string Hora { get; set; }

        [Required]
        public virtual string CentroCusto { get; set; }

        [Required]
        public virtual Departamento Departamento { get; set; }

        public virtual string StatusAtual { get; set; }

        [Required]
        public virtual string TipoRequisicao { get; set; }
        public virtual string NUMTPR { get; set; }

        public virtual bool Sacrementada { get; set; }

        public virtual string DELETE { get; set;}
        public virtual int R_E_C_N_O_ { get; set; }
    }
}