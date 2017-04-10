using SA.Controllers.Validates;
using SA.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SA.Models
{
    public class Usuario
    {
        
        public virtual string Filial {get; set;}

        [Required(ErrorMessage ="O nome do requerente é obrigatório")]
        public virtual string Requerente { get; set; }

        [Required(ErrorMessage ="Campo CPF é obrigratório")]
        [MaxLength(11,ErrorMessage ="O Tamanho do CPF deve ser de 11 números")]
        [MinLength(11, ErrorMessage = "O Tamanho do CPF deve ser de 11 números")]
        public virtual string Cpf { get; set; }
        
        public virtual string Departamento { get; set; }
        public virtual string DescricaoDepartamento { get; set; }
        public virtual string Funcao { get; set; }

        [Required(ErrorMessage ="O Centro de Custo é obrigatório")]
        public virtual string CentroCusto { get; set; }
        public virtual string DescricaoCentroCusto { get; set; }
        public virtual string Tercerizado { get; set; }
        public virtual string EmpresaTercerizada { get; set; }
        public virtual string CodImpressaora { get; set; }
        public virtual string PathImpressora { get; set; }
        public virtual string NomeImpressora { get; set; }
        public virtual string DELETE { get; set; }
        public virtual int R_E_C_N_O_ { get; set; }
        public virtual bool IsAdmin { get; set; }
    }
}