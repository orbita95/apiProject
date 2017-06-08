using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApi2_Contatos.Models;

namespace WebApi2_Contatos.Controllers
{
    public class PessoasController : ApiController
    {
        private EntitadesTeste db = new EntitadesTeste();

        public virtual IEnumerable<Pessoa> GetWithRawSql(string query, params object[] parameters)
        {
            return db.Pessoa.SqlQuery(query, parameters).ToList();
        }

        public IEnumerable<Pessoa> GetPessoas()
        {
            string sql = "select * from Pessoa";
            
            return db.Pessoa.SqlQuery(sql);//GetWithRawSql(sql, nome); 
        } 
    }
}
