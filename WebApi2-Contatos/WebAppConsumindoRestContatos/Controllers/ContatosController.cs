using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppConsumindoRestContatos.Models;

namespace WebAppConsumindoRestContatos.Controllers
{
    public class ContatosController : Controller
    {

        

        // GET: Contatos
        public ActionResult Index()
        {
            string uri = "http://localhost:63673/api/contatos/";
            IEnumerable<Contatos> c = new List<Contatos>();
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var contatos = response.Content.ReadAsAsync<IEnumerable<Contatos>>().Result;
                        
                        c = contatos;
                    }

                }

            }
            return View(c);
        }


        
        // GET: Contatos/Create
        public ActionResult Create()
        {
            string uri = "http://localhost:63673/api/pessoas";
            IEnumerable<Pessoas> p = new List<Pessoas>();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var pessoas = response.Content.ReadAsAsync<IEnumerable<Pessoas>>().Result;
                        p = pessoas;
                    }
                }
            }

            ViewBag.PessoaID = new SelectList(p, "pessoa_id", "nome");
            return View();
        }

        // POST: Contatos/Create
        [HttpPost]
        public ActionResult Create([Bind(Include =
            "pessoa_id,celular,telefoneResidencial,telefoneComercial,email,IM,sitioweb,tipo,nome_contato,endereco_contato_id")] Contatos c)
        {
            try
            {
                // TODO: Add insert logic here
                string uri = "http://localhost:63673/api/contatos/";
                using (var client = new HttpClient())
                {
                    var responseMessage = client.PostAsJsonAsync(uri + "/" + c.contato_id, c).Result;

                }
                    

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int id)
        {
            string uri = "http://localhost:63673/api/contatos/";
            Contatos contato = new Contatos();
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var contatos = response.Content.ReadAsAsync<IEnumerable<Contatos>>().Result;

                        contato = contatos.Where(cont => cont.contato_id == id).First();
                        
                    }

                }

            }
            
            return View(contato);
        }

        // POST: Contatos/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include =
            "contato_id,pessoa_id,celular,telefoneResidencial,telefoneComercial,email,IM,sitioweb,tipo,nome_contato,endereco_contato_id")] Contatos c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        string uri = "http://localhost:63673/api/contatos";
                        var responseMessage = client.PutAsJsonAsync(uri + "/" + c.contato_id, c).Result;

                        if (responseMessage.IsSuccessStatusCode)
                        {
                            Console.WriteLine("Alterado com Sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Falha ao alterar" + responseMessage.StatusCode);
                        }
                    }
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int id)
        {
            string uri = "http://localhost:63673/api/contatos/";
            IEnumerable<Contatos> c = new List<Contatos>();
            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var contatos = response.Content.ReadAsAsync<IEnumerable<Contatos>>().Result;
                        //var contatoJsonString = response.Content.ReadAsStringAsync();
                        // var contatos = JsonConvert.DeserializeObject<Contatos[]>(contatoJsonString).ToList();
                        c = contatos;
                    }

                }

            }
            var contato = c.Where(cont => cont.contato_id == id).ToList().First();

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                string uri = "http://localhost:63673/api/contatos";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    var responseMessage = client.DeleteAsync(String.Format("{0}/{1}", uri, id));
                    if (responseMessage.Result.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Contato excluído com sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Falha ao excluir o contato  : " + responseMessage.Status);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}
