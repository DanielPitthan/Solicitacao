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

        [Required(ErrorMessage ="Código do produto não informado")]
        [MaxLength(15,ErrorMessage ="O codigo do produto excede 15 caracteres")]
        public virtual string Produto { get; set; } //Código do produto 

        [Required(ErrorMessage ="Quantidade não informada")]
        public virtual double Quantidade { get; set; } //Quantidade


        public virtual string Observacao { get; set; }

        public virtual string Usuario { get; set; }//CPF do usuário
        public virtual string Data { get; set; }
        public virtual string Hora { get; set; }

        [Required(ErrorMessage ="Centro de Custo não Informado")]
        public virtual string CentroCusto { get; set; }

        [Required(ErrorMessage ="Departamento não pode ficar em branco")]
        public virtual Departamento Departamento { get; set; }

        public virtual string StatusAtual { get; set; }

        [Required(ErrorMessage ="Tipo da Requisição não pode ficar em branco")]
        public virtual string TipoRequisicao { get; set; }

        [RegularExpression(@"\d{10}",ErrorMessage ="Formato inválido")]
        public virtual string NUMTPR { get; set; }

        public virtual string Sacrementada { get; set; }

        public virtual string DELETE { get; set;}
        public virtual int R_E_C_N_O_ { get; set; }
    }
}