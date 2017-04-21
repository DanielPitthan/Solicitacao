using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Models
{
    public class SaldoEstoque
    {
        public virtual string Codigo { get; set; }
        public virtual double Saldo { get; set; }
        public virtual string Local { get; set; }
        public virtual string Delete { get; set; }
    }
}