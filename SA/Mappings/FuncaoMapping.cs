using FluentNHibernate.Mapping;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Mappings
{
    public class FuncaoMapping: ClassMap<Funcao>
    {
        public FuncaoMapping()
        {
            Id(d => d.Id).GeneratedBy.Identity();
            Map(d => d.Funcoes);
        }
    }
}