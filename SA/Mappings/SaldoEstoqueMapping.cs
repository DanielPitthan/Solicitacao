using FluentNHibernate.Mapping;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Mappings
{
    public class SaldoEstoqueMapping : ClassMap<SaldoEstoque>
    {
        public SaldoEstoqueMapping()
        {
            Table("SB2010");
            Id(s => s.Codigo).Column("B2_COD").CustomSqlType("VARCHAR");
            Map(s => s.Saldo).Column("B2_QATU").CustomSqlType("FLOAT");
            Map(s => s.Local).Column("B2_LOCAL").CustomSqlType("VARCHAR");
            Map(s => s.Delete).Column("D_E_L_E_T_").CustomSqlType("VARCHAR");
        }
    }
}