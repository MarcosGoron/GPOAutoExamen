using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpoAutofin.Data.Models
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal Costo { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}