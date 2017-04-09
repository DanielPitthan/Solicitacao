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

            Id(s => s.Codigo).Column("Z11_COD").CustomSqlType("VARCHAR");
            Map(s => s.Filial).Column("Z11_FILIAL").CustomSqlType("VARCHAR");
            Map(s => s.Produto).Column("Z11_PRODUT").CustomSqlType("VARCHAR");
            Map(s => s.Observacao).Column("Z11_OBS");
            Map(s => s.Quantidade).Column("Z11_QTDE");
            Map(s => s.Usuario).Column("Z11_USER").CustomSqlType("VARCHAR");
            Map(s => s.Data).Column("Z11_DATA").CustomSqlType("VARCHAR");
            Map(s => s.Hora).Column("Z11_HORA").CustomSqlType("VARCHAR");
            Map(s => s.CentroCusto).Column("Z11_CC").CustomSqlType("VARCHAR");
            Map(s => s.StatusAtual).Column("Z11_FLAGDH").CustomSqlType("VARCHAR");
            Map(s => s.TipoRequisicao).Column("Z11_TPREQW").CustomSqlType("VARCHAR");
            Map(s => s.NUMTPR).Column("Z11_NUMTPR").CustomSqlType("VARCHAR");
            Map( s=> s.DELETE).Column("D_E_L_E_T_").CustomSqlType("VARCHAR");
            Map(s => s.R_E_C_N_O_);

        }
    }
}