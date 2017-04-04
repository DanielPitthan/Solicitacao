using SA.Models;
using SA.ViewModel;
using SA.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace SA.Controllers.Validates
{
    public  class UsuarioValidates
    {

        /// <summary>
        /// Validação dos Tercerizados
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool TercerizadoValidate(Usuario user)
        {
            if (user.Tercerizado.Substring(0,1) == "S" & !String.IsNullOrEmpty(user.EmpresaTercerizada))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validação do CPF
        /// </summary>
        /// <param name="cpf">The CPF.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public static bool CpfValidate(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                return false;
            }

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}