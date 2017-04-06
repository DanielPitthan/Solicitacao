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
            Table('Z11010');

            Id(s => s.Codigo).Column("Z11_COD");
        }
    }
}