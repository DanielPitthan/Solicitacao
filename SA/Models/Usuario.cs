using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Models
{
    public class Usuario
    {
        
        public virtual string Filial {get; set;}
        public virtual string Requerente { get; set; }
        public virtual string Cpf { get; set; }
        public virtual string Departamento { get; set; }
        public virtual string DescricaoDepartamento { get; set; }
        public virtual string Funcao { get; set; }
        public virtual string CentroCusto { get; set; }
        public virtual string DescricaoCentroCusto { get; set; }
        public virtual string Tercerizado { get; set; }
        public virtual string EmpresaTercerizada { get; set; }
        public virtual string CodImpressaora { get; set; }
        public virtual string PathImpressora { get; set; }
        public virtual string NomeImpressora { get; set; }
        public virtual int DELETE { get; set; }
        public virtual int R_E_C_N_O_ { get; set; }
        
    }
}