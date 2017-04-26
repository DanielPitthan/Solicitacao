using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.Factorys
{
    public static class ChoiceFactory
    {


        /// <summary>
        /// Gera uma Lista de escolha Sim, Não
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public static IList<string> SimNao()
        {
            IList<string> sn = new List<string>();
            sn.Add("Não");
            sn.Add("Sim");

            return sn;
        }

        /// <summary>
        /// Tipos de Requisições Válidas
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public static IList<string> ListaTiposRequisicoes()
        {
            List<string> t = new List<string>();
            t.Add("OU");
            t.Add("OS");
            t.Add("CO");
            return (t);
        }
    }
}