using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SA.Models
{
    public class Funcao
    {
        public virtual int Id { get; set; }

        [Required]
        [MinLength(5)]
        public virtual string Funcoes { get; set; }
    }
}