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

            Id(u => u.Cpf).Column("Z13_CFP");
            Map(u => u.Filial).Column("Z13_FILIAL");
            Map(u => u.Requerente).Column("Z13_REQUIS");
            Map(u => u.Departamento).Column("Z13_DEPART");
            Map(u => u.DescricaoDepartamento).Column("Z13_DESCDP");
            Map(u => u.Funcao).Column("Z13_FUNCAO");
            Map(u => u.CentroCusto).Column("Z13_CC");
            Map(u => u.DescricaoCentroCusto).Column("Z13_DESCC");
            Map(u => u.Tercerizado).Column("Z13_FUNCEM");
            Map(u => u.EmpresaTercerizada).Column("Z13_EMPTER");
            Map(u => u.CodImpressaora).Column("Z13_CODIMP");
            Map(u => u.PathImpressora).Column("Z13_CAMIMP");
            Map(u => u.NomeImpressora).Column("Z13_DESCIM");
            Map(u => u.DELETE).Column("D_E_L_E_T_");
            Map(u => u.R_E_C_N_O_).Column("R_E_C_N_O_");

        }
    }
}