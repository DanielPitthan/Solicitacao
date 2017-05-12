using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SA.Helpers
{
    public class ConnectionFactory
    {
        public static IDbConnection CriaConexao()
        {

            var configname = ConfigurationManager.GetSection("hibernate-configuration");

            string conecxaoTag = ((NHibernate.Cfg.SessionFactoryConfigurationBase)((NHibernate.Cfg.ConfigurationSchema.HibernateConfiguration)configname)
                                    .SessionFactory)
                                    .Properties["connection.connection_string_name"];


            var stringConexao = ConfigurationManager.ConnectionStrings[conecxaoTag];
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = stringConexao.ConnectionString;
            conexao.Open();
            return conexao;
        }
    }
}