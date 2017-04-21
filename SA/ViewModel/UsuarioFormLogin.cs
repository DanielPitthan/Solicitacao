using SA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.ViewModel
{
    public class UsuarioFormLogin
    {
        public string Filial { get; set; }
        public string Requerente { get; set; }
        public string Cpf { get; set; }
        public string Departamento { get; set; }
        public string DescricaoDepartamento { get; set; }
        public string Funcao { get; set; }
        public string CentroCusto { get; set; }
        public string DescricaoCentroCusto { get; set; }
        public string Tercerizado { get; set; }
        public string EmpresaTercerizada { get; set; }
        public string CodImpressaora { get; set; }
        public string PathImpressora { get; set; }
        public string NomeImpressora { get; set; }
        public string DELETE { get; set; }
        public int R_E_C_N_O_ { get; set; }
        public bool IsAdmin { get; set; }


        /// <summary>
        /// Cria um usuário com base em um UsuárioFormLogin
        /// </summary>
        /// <returns></returns>
        public Usuario CriaUsuario()
        {
            Usuario usuario = new Usuario();

            usuario.Filial = this.Filial;
            usuario.Requerente = this.Requerente;
            usuario.Cpf = this.Cpf;
            usuario.Departamento = this.Departamento;
            usuario.DescricaoDepartamento = this.DescricaoDepartamento;
            usuario.Funcao = this.Funcao;
            usuario.CentroCusto = this.CentroCusto;
            usuario.DescricaoCentroCusto = this.DescricaoCentroCusto;
            usuario.Tercerizado = this.Tercerizado;
            usuario.EmpresaTercerizada = this.EmpresaTercerizada;
            usuario.CodImpressaora = this.CodImpressaora;
            usuario.PathImpressora = this.PathImpressora;
            usuario.NomeImpressora = this.NomeImpressora;
            usuario.DELETE = this.DELETE;
            usuario.R_E_C_N_O_ = this.R_E_C_N_O_;

            if (this.IsAdmin)
            {
                usuario.Admin = "S";
            }
            else
            {
                usuario.Admin = "N";
            }


            return usuario;
        }

        public void MontaUsuarioFormLogin(Usuario usuario)
        {
            this.Filial = usuario.Filial;
            this.Requerente = usuario.Requerente;
            this.Cpf = usuario.Cpf;
            this.Departamento = usuario.Departamento;
            this.DescricaoDepartamento = usuario.DescricaoDepartamento;
            this.Funcao = usuario.Funcao;
            this.CentroCusto = usuario.CentroCusto;
            this.DescricaoCentroCusto = usuario.DescricaoCentroCusto;
            this.Tercerizado = usuario.Tercerizado;
            this.EmpresaTercerizada = usuario.EmpresaTercerizada;
            this.CodImpressaora = usuario.CodImpressaora;
            this.PathImpressora = usuario.PathImpressora;
            this.NomeImpressora = usuario.NomeImpressora;
            this.DELETE = usuario.DELETE;
            this.R_E_C_N_O_ = usuario.R_E_C_N_O_;

            if (usuario.Admin!=null && usuario.Admin.Equals("S"))
            {
                this.IsAdmin = true;
            }
            else
            {
                this.IsAdmin = false;
            }


                
    }

    }
}