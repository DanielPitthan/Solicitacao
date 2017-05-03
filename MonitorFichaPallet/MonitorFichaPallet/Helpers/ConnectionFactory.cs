using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// The Helpers namespace.
/// </summary>
namespace MonitorFichaPallet.Helpers
{
    /// <summary>
    /// Factory resposável por montar a conexão com o banco de dados
    /// </summary>
    public class ConnectionFactory
    {
        public static IDbConnection CriaConexao()
        {
            var stringConexao = "Server = SERVIDOR7; Database =P1180_PRODUCAO; User Id = SIGA; Password = SIGA";
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = stringConexao;//stringConexao.ConnectionString;
            conexao.Open();
            return conexao;
        }
    }
}