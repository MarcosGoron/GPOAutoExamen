using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpoAutofin.Data.Models
{
    public class ListaFactura
    {
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public string Cliente { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }

    }
}