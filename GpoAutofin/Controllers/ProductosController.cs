using GpoAutofin.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GpoAutofin.Controllers
{
    public class ProductosController : Controller
    {
        private ProductosBO productosBO;
        public ProductosController()
        {
            this.productosBO = new ProductosBO();
        }
        // GET: Productos
        public ActionResult RegistroProductos()
        {
            ViewBag.Productos = this.productosBO.GetListaProductos();
            return View();
        }
        [HttpPost]
        public JsonResult RegistroProductos(string Nombre, string Marca, decimal Costo, decimal PrecioVenta)
        {

            var guarda = this.productosBO.InsertProductos(Nombre, Marca, Costo, PrecioVenta);
            RedirectToAction("RegistroProductos", "Productos");
            return Json(guarda, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditarProducto(int IdProducto)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditarProducto(int IdProducto, string Nombre, string Marca, decimal Costo, decimal PrecioVenta)
        {
            try
            {
                var guarda = this.productosBO.EditarProducto(IdProducto, Nombre, Marca, Costo, PrecioVenta);
                return RedirectToAction("RegistroProductos", "Productos");
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}