using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SA.Models
{
    public class Departamento
    {
        public virtual int Id { get; set; }

        [Required]
        [MinLength(5)]
        public virtual string Departamentos { get; set; }

        [Required]
        [MaxLength(9)]
        [MinLength(3)]
        public virtual string CentroCusto { get; set; }
    }
}