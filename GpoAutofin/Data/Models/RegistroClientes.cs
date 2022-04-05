using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpoAutofin.Data.Models
{
    public class RegistroClientes
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Email { get; set; }
    }
}