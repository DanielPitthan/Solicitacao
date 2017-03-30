using NHibernate;
using SA.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class CentroCustoDAO
    {
        ISession session;

        public CentroCustoDAO (ISession session)
        {
            this.session = session;
        }

        public static string GetCustoName(string cod)
        {
            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand())
            {
                string query = "select CTT_DESC FROM CTT010 WHERE CTT_CUSTO = @Custo";

                comando.CommandText = query;

                IDbDataParameter paramTitulo = comando.CreateParameter();
                paramTitulo.ParameterName = "Custo";
                paramTitulo.Value = cod;
                comando.Parameters.Add(paramTitulo);

                IDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    if (!Convert.IsDBNull(leitor["CTT_DESC"]))
                    {
                        return leitor["CTT_DESC"].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                return "";
                
            }
            
        }

    }
}