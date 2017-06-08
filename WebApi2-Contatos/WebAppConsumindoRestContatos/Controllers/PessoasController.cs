using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebAppConsumindoRestContatos.Models;

namespace WebAppConsumindoRestContatos.Controllers
{
    public class PessoasController : Controller
    {
        // GET: Pessoas
        public ActionResult Index()
        {
            string uri = "http://localhost:63673/api/pessoas";
            IEnumerable<Pessoas> p = new List<Pessoas>();

            using(var client = new HttpClient()){
                using (var response = client.GetAsync(uri).Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var pessoas = response.Content.ReadAsAsync<IEnumerable<Pessoas>>().Result;
                        p = pessoas;
                    }
                }
            }

            return View(p);
        }

        public ActionResult Details(int? id, string nome)
        {
            
            string uri = "http://localhost:63673/api/contatos/?pessoaId=" + id.ToString();
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
            
            ViewBag.nomePessoa = nome;

            return View(c);
            
        }
        

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
       
    }
}
