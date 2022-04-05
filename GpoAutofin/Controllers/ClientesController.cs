using GpoAutofin.BO;
using GpoAutofin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GpoAutofin.Controllers
{
    public class ClientesController : Controller
    {
        private RegistroClientesBO registroClientesBO;
        public ClientesController()
        {
            this.registroClientesBO = new RegistroClientesBO();
        }
        // GET: Clientes
        public ActionResult RegistroClientes()
        {
            ViewBag.Clientes = this.registroClientesBO.GetListaClientes();
            return View();
        }
        [HttpPost]
        public JsonResult RegistroClientes(string Nombre, string Domicilio, string Email)
        {

            var guarda = this.registroClientesBO.InsertClientes(Nombre, Domicilio, Email);
            RedirectToAction("RegistroClientes", "Clientes");
            return Json(guarda, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ActualizarCliente(int? IdCliente)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ActualizarCliente(int IdCliente, string Nombre, string Domicilio, string Email)
        {
            try
            {
                var guarda = this.registroClientesBO.EditarClientes(IdCliente, Nombre, Domicilio, Email);
                return RedirectToAction("RegistroClientes", "Clientes");
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}