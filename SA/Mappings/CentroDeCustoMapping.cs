using FluentNHibernate.Mapping;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Mappings
{
    public class CentroDeCustoMapping:ClassMap<CentroDeCusto>
    {
        public CentroDeCustoMapping()
        {
            Table("CTT010");
            Id(c => c.Recno).Column("R_E_C_N_O_");
            Map(c => c.Codigo).Column("CTT_CUSTO").CustomSqlType("varchar");
            Map(c => c.Descricao).Column("CTT_DESC01").CustomSqlType("varchar");
        }
    }
}