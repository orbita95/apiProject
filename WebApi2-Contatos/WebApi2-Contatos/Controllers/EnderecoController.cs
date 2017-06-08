using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2_Contatos.Models;

namespace WebApi2_Contatos.Controllers
{
    public class EnderecoController : ApiController
    {

        EntitadesTeste db = new EntitadesTeste();

        public IEnumerable<Endereco> GetEnderecos()
        {
            var enderecos = db.Endereco.ToList();
            return enderecos;
        }

        public void PutEndereco(int id, Endereco endereco)
        {
            Endereco e = endereco;
            db.Entry(e).State = EntityState.Modified;
            db.SaveChanges();
        }

        public HttpResponseMessage PostProduto(Endereco e)
        {
            db.Endereco.Add(e);
            db.SaveChanges();
            var response = Request.CreateResponse<Endereco>(HttpStatusCode.Created, e);

            string uri = Url.Link("DefaultAPI", new { id = e.endereco_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

    }
}
