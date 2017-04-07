using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MonitorFichaPallet.Helpers
{
    public class ConnectionFactory
    {
        public static IDbConnection CriaConexao()
        {
            var stringConexao = "Server = SRV-FINI-DBH; Database = P_DEV; User Id = SIGA; Password = SIGA";
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = stringConexao;//stringConexao.ConnectionString;
            conexao.Open();
            return conexao;
        }
    }
}