using FluentNHibernate.Mapping;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
namespace SA.Mappings
{
    public class UsuarioMapping: ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Table("Z13010");

            Id(u => u.R_E_C_N_O_).Column("R_E_C_N_O_").CustomSqlType("INT");
            Map(u => u.Cpf).Column("Z13_CPF").CustomSqlType("VARCHAR");
            Map(u => u.Filial).Column("Z13_FILIAL").CustomSqlType("VARCHAR");
            Map(u => u.Requerente).Column("Z13_REQUIS").CustomSqlType("VARCHAR");
            Map(u => u.Departamento).Column("Z13_DEPART").CustomSqlType("VARCHAR");
            Map(u => u.DescricaoDepartamento).Column("Z13_DESCDP").CustomSqlType("VARCHAR");
            Map(u => u.Funcao).Column("Z13_FUNCAO").CustomSqlType("VARCHAR");
            Map(u => u.CentroCusto).Column("Z13_CC").CustomSqlType("VARCHAR");
            Map(u => u.DescricaoCentroCusto).Column("Z13_DESCC").CustomSqlType("VARCHAR");
            Map(u => u.Tercerizado).Column("Z13_FUNCEM").CustomSqlType("VARCHAR");
            Map(u => u.EmpresaTercerizada).Column("Z13_EMPTER").CustomSqlType("VARCHAR");
            Map(u => u.CodImpressaora).Column("Z13_CODIMP").CustomSqlType("VARCHAR");
            Map(u => u.PathImpressora).Column("Z13_CAMIMP").CustomSqlType("VARCHAR");
            Map(u => u.NomeImpressora).Column("Z13_DESCIM").CustomSqlType("VARCHAR");                        
            Map(u => u.Admin).Column("Z13_ISADMIN").CustomSqlType("VARCHAR");
            Map(u => u.DELETE).Column("D_E_L_E_T_").CustomSqlType("VARCHAR");
        }
    }
}