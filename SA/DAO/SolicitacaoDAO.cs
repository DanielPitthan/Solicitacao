using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using SA.Factorys;
using SA.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace SA.DAO
{
    public class SolicitacaoDAO
    {
        ISession session;
        UsuarioDAO userDAO;

        public SolicitacaoDAO (ISession session, UsuarioDAO usuario )
        {
            this.session = session;
            this.userDAO = usuario;
        }

        /// <summary>
        /// retorna uma Lista de Solicitações da sessão atual do usuário
        /// </summary>
        /// <returns>IList&lt;Solicitacao&gt;.</returns>
        public IList<Solicitacao> Lista(Usuario user)
        {
            IList<Solicitacao> solicitacoes = session.QueryOver<Solicitacao>()
                                                .Where(s => s.Usuario == user.Cpf) 
                                                //.SelectList(lista => lista //Necessita de um DTO
                                                //.SelectGroup( p=> p.Codigo)
                                                //.SelectGroup( p=> p.Data)
                                                //)
                                                .OrderBy(s => s.Data)
                                                .Desc()
                                                .List();
                                                
                                                


            return solicitacoes;
        }
        /// <summary>
        /// Lista um grupo de solicitacao por Codigo
        /// </summary>
        /// <returns></returns>
        public IList<Solicitacao> ListaByCodigo(string cod)
        {
            string hql = "select s from Solicitacao s where Codigo = :cod";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("cod", cod);
            return query.List<Solicitacao>();
        }

        /// <summary>
        /// Retorna uma Solicitacao buscando pelo código dela
        /// </summary>
        /// <returns>GetBySa.</returns>
        public Solicitacao GetBySa(string sa)
        {
            string hql = "select s from Solicitacao s where s.Codigo = :sa ";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("sa", sa);
            return query.UniqueResult<Solicitacao>();
        }

        /// <summary>
        /// Grava uma nova solicitacao no banco de dados
        /// </summary>
        /// <param name="sa">The sa.</param>
        public void Add(IList<Solicitacao> sa)
        {
            string saCod = GetCod();            
                      

            foreach(var s in sa)
            {
                               
                s.Codigo = saCod;
                ITransaction tran = session.BeginTransaction();
                session.Save(s);
                tran.Commit();                

            }
            
        }       


        /// <summary>
        /// Obtem o pr[oximo código libvre de Solicitação
        /// </summary>
        /// <returns></returns>
        public string GetCod()
        {
            int size = 6;// tamanho máximo do código

            var maximo = session.QueryOver<Solicitacao>()
                                        .Select(s => s.Codigo)
                                        .List<string>().Max<string>();


            maximo = Soma1c.soma(maximo,size);
            return maximo;
        }


        /// <summary>
        /// Faz a exclusão de uma solicitacao
        /// </summary>
        /// <param name="sa">The sa.</param>
        public void Delete (string sa)
        {
            //TODO
            //Verificar se a SA já não foi consumida 
            ITransaction tran = session.BeginTransaction();
            session.Delete(GetBySa(sa));
            tran.Commit();
        }

        /// <summary>
        /// Altera uma solicitacao no banco de dados
        /// </summary>
        /// <param name="sa">The sa.</param>
        public void Alter(Solicitacao sa)
        {
            ITransaction tran = session.BeginTransaction();
            session.Merge(sa);
            tran.Commit();
        }


       
    }
}