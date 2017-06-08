using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApi2_Contatos.Controllers
{
    public class PessoaService
    {
        public async void DeletarContatoPorPessoa(int contatoID)
        {
            string uri = "http://localhost:63673/api/contatos";
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                HttpResponseMessage responseMessage = await client.DeleteAsync(String.Format("{0}/{1}", uri, contatoID));
                if (responseMessage.IsSuccessStatusCode)
                {
                    Console.WriteLine("Produto excluído com sucesso");
                }
                else
                {
                    Console.WriteLine("Falha ao excluir o produto  : " + responseMessage.StatusCode);
                }
            }
            
        }
    }
}