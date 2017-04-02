using NHibernate;
using SA.Helpers;
using SA.Models;
using SA.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class UsuarioDAO
    {
        ISession session;
        DepartamentoDAO departamentoDAO;

        public UsuarioDAO(ISession session, DepartamentoDAO dep)
        {
            this.session = session;
            this.departamentoDAO = dep;
        }

        //Lista os Usuarios 
        public IList<Usuario> Lista()
        {
            string hql = "select d from Usuario d";
            IQuery query = session.CreateQuery(hql);
            return query.List<Usuario>();
        }

        /// <summary>
        /// Grava um Usuario no banco de dados 
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Add(Usuario user)
        {
            //Preeche os campos faltantes

            user.Filial = "01";

            Departamento dep = departamentoDAO.GetById(Convert.ToInt32(user.Departamento));
            user.DescricaoDepartamento = dep.Departamentos;

            user.DescricaoCentroCusto = CentroCustoDAO.GetCustoName(user.CentroCusto);

            user.Tercerizado = user.Tercerizado.Substring(0, 1);
            if (String.IsNullOrEmpty(user.EmpresaTercerizada))
            {
                user.EmpresaTercerizada = "";
            }
            
            user.CodImpressaora = ""; //Compatibilidade
            user.PathImpressora = ""; //Compatibilidade
            user.NomeImpressora = ""; //Compatibilidade
            user.DELETE = 0;
            user.R_E_C_N_O_ = RECNO.GetNextRecno("Z13010");

            //Salva o usuário
            ITransaction tran = session.BeginTransaction();
            session.Save(user);
            tran.Commit();

        }

        /// <summary>
        /// Procura um usuario pelo CPF
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario GetById(string cpf)
        {
            string hql = "select d from Usuario d where d.Cpf= :cpf";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("id", cpf);
            return query.UniqueResult<Usuario>();
        }

        /// <summary>
        /// Altera um Usuario no banco de dados 
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Alter(Usuario user)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(user);
            tran.Commit();
        }

        /// <summary>
        /// Exclui um Usuario no banco de dados
        /// </summary>
        /// <param name="dep">The dep.</param>
        public void Delete(Usuario user)
        {
            ITransaction tran = session.BeginTransaction();
            session.Delete(user);
            tran.Commit();
        }

        /// <summary>
        /// função Auxiliar para montar um combox
        /// </summary>
        /// <returns>IList&lt;System.String&gt;.</returns>
        public IList<string> SimNaoTerceiro()
        {
            IList<string> sn = new List<string>();
            sn.Add("Não");
            sn.Add("Sim");

            return sn;
        }
       

        /// <summary>
        /// Verifica se já existe o usuário na Base
        /// </summary>
        /// <param name="usuario">The login.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool ExisteUsuario(Usuario user)
        {
            
            string hql = "select u from Usuario u where u.Cpf = :cpf ";
            IQuery query = this.session.CreateQuery(hql);
            query.SetParameter("cpf", user.Cpf);

            Usuario usuario = query.UniqueResult<Usuario>();
            if (usuario == null)
            {
                return false;
            }
        
            return true;
        }
    }
}