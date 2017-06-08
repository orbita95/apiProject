using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebAppConsumindoRestContatos.Models;

namespace WebAppConsumindoRestContatos.Controllers
{
    public class EnderecosController : Controller
    {

        public IEnumerable<Enderecos> getEnderecosById(int id)
        {
            string uri = "http://localhost:63673/api/endereco";
            IEnumerable<Enderecos> e = new List<Enderecos>();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var enderecos = response.Content.ReadAsAsync<IEnumerable<Enderecos>>().Result;
                        e = enderecos;
                    }
                }
            }
            return e.Where(end => end.endereco_id == id).ToList();
        }

        // GET: Enderecos
        public ActionResult Index()
        {
            string uri = "http://localhost:63673/api/endereco";
            IEnumerable<Enderecos> e = new List<Enderecos>();

            using (var client = new HttpClient())
            {
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var enderecos = response.Content.ReadAsAsync<IEnumerable<Enderecos>>().Result;
                        e = enderecos;
                    }
                }
            }

                return View(e);
        }
        
        // GET: Enderecos/Create
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

        // POST: Enderecos/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = 
            "pessoa_id,logradouro,complemento,tipo,estado,cidade,bairro,numero")] Enderecos e)
        {
            try
            {
                // TODO: Add insert logic here
                string uri = "http://localhost:63673/api/endereco/";
                using (var client = new HttpClient())
                {
                    var responseMessage = client.PostAsJsonAsync(uri + "/" + e.endereco_id, e).Result;
                    
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var e = getEnderecosById(id).First();
            
            if (e == null)
            {
                return HttpNotFound();
            }
                        
            return View(e);
        }

        


        // POST: Medicos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pessoa_id,logradouro,complemento,tipo,estado,cidade,bairro,numero")] Enderecos e)
        {
            
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    string uri = "http://localhost:63673/api/endereco";
                    var responseMessage = client.PutAsJsonAsync(uri + "/" + e.endereco_id, e).Result;

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Alterado com Sucesso");
                    }
                    else
                    {
                        Console.WriteLine("Falha ao alterar" + responseMessage.StatusCode);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(e);
        }
        
        // GET: Enderecos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Enderecos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
