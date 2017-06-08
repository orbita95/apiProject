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
    public class ContatosController : ApiController
    {
        EntitadesTeste db = new EntitadesTeste();

        public IEnumerable<Contato> GetContatos()
        {
            var contatos = db.Contato.ToList();
            return contatos;
        }

        public List<Contato> GetContatosDePessoas(string nome)
        {
            var lpessoa = db.Pessoa.Where(p => p.nome == nome).ToList();
            var pessoa = lpessoa[0];
            var contatos = db.Contato.Where(c => c.pessoa_id == pessoa.pessoa_id).ToList();

            return contatos;
        }

        public List<Contato> GetContatosDePessoas(int pessoaId)
        {
            var contatos = db.Contato.Where(c => c.pessoa_id == pessoaId).ToList();

            return contatos;
        }

        public void PutContato(int id, Contato contato)
        {
            Contato c = contato;
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
        }

        public HttpResponseMessage PostProduto(Contato c)
        {
            db.Contato.Add(c);
            db.SaveChanges();
            var response = Request.CreateResponse<Contato>(HttpStatusCode.Created, c);

            string uri = Url.Link("DefaultAPI", new { id = c.contato_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void DeleteContato(int id)
        {
            var contato = db.Contato.Find(id);
            db.Contato.Remove(contato);
            db.SaveChanges();
        }
    }
}
