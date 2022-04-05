using GpoAutofin.Data.DAO;
using GpoAutofin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpoAutofin.BO
{
    public class ProductosBO
    {
        private ProductosDAO productosDAO;
        public ProductosBO()
        {
            productosDAO = new ProductosDAO();
        }
        public object GetListaProductos()
        {
            try
            {
                List<Productos> listaClientes = this.productosDAO.GetListaProductos();

                return listaClientes;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public object InsertProductos(string Nombre, string Marca, decimal Costo, decimal PrecioVenta)
        {
            try
            {
                Productos cliente = this.productosDAO.InsertProductos(Nombre, Marca, Costo, PrecioVenta);

                return cliente;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public object EditarProducto(int IdProducto, string Nombre, string Marca, decimal Costo, decimal PrecioVenta)
        {
            try
            {
                Productos cliente = this.productosDAO.EditarProducto(IdProducto, Nombre, Marca, Costo, PrecioVenta);

                return cliente;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}