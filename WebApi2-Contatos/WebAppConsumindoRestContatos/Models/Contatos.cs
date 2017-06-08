using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppConsumindoRestContatos.Models
{
    public class Contatos
    {
        public int contato_id { get; set; }
        public int pessoa_id { get; set; }
        public string celular { get; set; }
        public string telefoneResidencial { get; set; }
        public string telefoneComercial { get; set; }
        public string email { get; set; }
        public string IM { get; set; }
        public string sitioweb { get; set; }
        public int tipo { get; set; }
        public string nome_contato { get; set; }
        public Nullable<int> endereco_contato_id { get; set; }
    }
}