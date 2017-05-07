using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Models
{
    public class CentroDeCusto
    {   
        public virtual string Codigo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual int Recno { get; set; }
    }
}