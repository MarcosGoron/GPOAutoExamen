using GpoAutofin.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GpoAutofin.Controllers
{
    public class FacturasController : Controller
    {
        private RegistroClientesBO registroClientesBO;
        private ProductosBO productosBO;
        private FacturaBO facturaBO;
        public FacturasController()
        {
            this.registroClientesBO = new RegistroClientesBO();
            this.productosBO = new ProductosBO();
            this.facturaBO = new FacturaBO();
        }
        public ActionResult GetFacturas()
        {
            ViewBag.Listafacturas = this.facturaBO.GetListaFacturas();
            return View();
        }
        // GET: Facturas
        public ActionResult GenerarFactura()
        {
            ViewData["fechaActual"] = DateTime.Now.ToString();
            ViewBag.Clientes = this.registroClientesBO.GetListaClientes();
            ViewBag.Productos = this.productosBO.GetListaProductos();
            return View();
        }
        [HttpPost]
        public JsonResult GenerarFactura(string NumeroFactura, string Cantidad, int IdProducto, int IdCliente, DateTime FechaHora)
        {
            var guarda = this.facturaBO.InsertFactura(NumeroFactura, Cantidad, IdProducto, IdCliente, FechaHora);
            return Json(guarda, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditarFactura(int IdFactura)
        {
            ViewData["fechaActual"] = DateTime.Now.ToString();
            ViewBag.Clientes = this.registroClientesBO.GetListaClientes();
            ViewBag.Productos = this.productosBO.GetListaProductos();
            return View();
        }
        [HttpPost]
        public ActionResult EditarFactura(int IdFactura, string Cantidad, int IdProducto)
        {
            try
            {
                var guarda = this.facturaBO.EditarFactura(IdFactura, Cantidad, IdProducto);
                return RedirectToAction("GetFacturas", "Facturas");
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}