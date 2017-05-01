using SA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    /// <summary>
    /// Classe responável por controlar transações por fora do Fluent Nhibernate 
    /// </summary>
    public static class ExecuteQuery
    {
        /// <summary>
        /// Executa um query no banco de dados 
        /// </summary>
        /// <param name="query">The query.</param>
        public static void Execute (string query)
        {
            using (IDbConnection conecxao = ConnectionFactory.CriaConexao())
            using (IDbCommand com = conecxao.CreateCommand())
            {
                com.CommandText = query;
                IDbTransaction transaction = conecxao.BeginTransaction();
                com.ExecuteNonQuery();
                transaction.Commit();
            }
        }
    }
}