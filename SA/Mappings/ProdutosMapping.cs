using FluentNHibernate.Mapping;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Mappings
{
    public class ProdutosMapping:ClassMap<Produtos>
    {
        public ProdutosMapping()
        {
            Table("SB1010");
            Id(p => p.Codigo).CustomSqlType("VARCHAR").Column("B1_COD");
            Map(p => p.Descricao).CustomSqlType("VARCHAR").Column("B1_DESC");
        }
    }
}