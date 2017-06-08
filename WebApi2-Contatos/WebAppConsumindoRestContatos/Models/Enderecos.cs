using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppConsumindoRestContatos.Models
{
    public class Enderecos
    {
        public int endereco_id { get; set; }
        public int pessoa_id { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public int tipo { get; set; }
        public string estado { get; set; }
        public string cidade { get; set; }
        public string bairro { get; set; }
        public string numero { get; set; }
    }
}