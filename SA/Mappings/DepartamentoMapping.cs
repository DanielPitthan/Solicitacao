using FluentNHibernate.Mapping;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Mappings
{
    public class DepartamentoMapping: ClassMap<Departamento>
    {
        public DepartamentoMapping()
        {
            Id(d => d.Id).GeneratedBy.Identity();
            Map(d => d.Departamentos);
        }
    }
}