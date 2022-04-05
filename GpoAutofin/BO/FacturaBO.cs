using GpoAutofin.Data.DAO;
using GpoAutofin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpoAutofin.BO
{
    public class FacturaBO
    {
        private FacturaDAO facturaDAO;
        public FacturaBO()
        {
            facturaDAO = new FacturaDAO();
        }
        public object GetListaFacturas()
        {
            try
            {
                List<ListaFactura> listaFacturas = this.facturaDAO.GetListaFacturas();

                return listaFacturas;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public object InsertFactura(string NumeroFactura, string Cantidad, int IdProducto, int IdCliente, DateTime FechaHora)
        {
            try
            {
                Factura cliente = this.facturaDAO.InsertFactura(NumeroFactura, Cantidad, IdProducto, IdCliente, FechaHora);

                return cliente;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public object EditarFactura(int IdFactura, string Cantidad, int IdProducto)
        {
            try
            {
                Factura cliente = this.facturaDAO.EditarFactura(IdFactura, Cantidad, IdProducto);

                return cliente;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }    
}