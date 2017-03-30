using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SA.Helpers
{
    public class ConnectionFactory
    {
        public static IDbConnection CriaConexao()
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["local"];
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = stringConexao.ConnectionString;
            conexao.Open();
            return conexao;
        }
    }
}