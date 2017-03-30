using SA.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class RECNO
    {
        public static int GetNextRecno(string tabela)
        {
            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand())
            {
                string query = "select max(R_E_C_N_O_)+1 as RECNO from @tabela ";

                comando.CommandText = query;

                IDbDataParameter paramTitulo = comando.CreateParameter();
                paramTitulo.ParameterName = "tabela";
                paramTitulo.Value = tabela;
                comando.Parameters.Add(paramTitulo);

                IDataReader leitor = comando.ExecuteReader();
                while (leitor.Read())
                {
                    if (!Convert.IsDBNull(leitor["RECNO"]))
                    {
                        return Convert.ToInt32(leitor["RECNO"]);
                    }
                    else
                    {
                        return 1;
                    }
                }
                return 1;

            }

        }
    }
}