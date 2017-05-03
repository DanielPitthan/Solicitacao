using FluentNHibernate.Mapping;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;


namespace SA.Mappings
{
    public class SolicitacaoMapping: ClassMap<Solicitacao>
    {
        public SolicitacaoMapping()
        {
            Table("Z11010");

            //Chave composta
            //CompositeId().KeyProperty(s => s.Filial)
            //             .KeyProperty(s => s.Codigo);


            Id(s => s.R_E_C_N_O_).CustomSqlType("INT");
            Map(s => s.Codigo).Column("Z11_COD").CustomSqlType("VARCHAR(06)");            
            Map(s => s.Filial).Column("Z11_FILIAL").CustomSqlType("VARCHAR(02)");
            Map(s => s.Produto).Column("Z11_PRODUT").CustomSqlType("VARCHAR(15)");
            Map(s => s.Observacao).Column("Z11_OBS").CustomSqlType("VARCHAR(4000)");
            Map(s => s.Quantidade).Column("Z11_QTDE").CustomSqlType("FLOAT");
            Map(s => s.Usuario).Column("Z11_USER").CustomSqlType("VARCHAR(11)");
            Map(s => s.Data).Column("Z11_DATA").CustomSqlType("VARCHAR(8)");
            Map(s => s.Hora).Column("Z11_HORA").CustomSqlType("VARCHAR(8)");
            Map(s => s.CentroCusto).Column("Z11_CC").CustomSqlType("VARCHAR(9)");
            Map(s => s.StatusAtual).Column("Z11_FLAGDH").CustomSqlType("VARCHAR(100)");
            Map(s => s.TipoRequisicao).Column("Z11_TPREQW").CustomSqlType("VARCHAR(2)");
            Map(s => s.NUMTPR).Column("Z11_NUMTPR").CustomSqlType("VARCHAR(10)");            
            Map(s => s.Sacrementada).CustomSqlType("VARCHAR(1)");            
            References(s => s.Departamento);
            Map(s => s.DELETE).Column("D_E_L_E_T_").CustomSqlType("VARCHAR(1)");

        }
    }
}