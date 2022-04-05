using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpoAutofin.Data.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public int IdCliente { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }

    }
}