using GpoAutofin.Data.DAO;
using GpoAutofin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GpoAutofin.BO
{
    public class RegistroClientesBO
    {
        private RegistroClientesDAO registroClientesDAO;

        public RegistroClientesBO()
        {
            registroClientesDAO = new RegistroClientesDAO();
        }

        public object GetListaClientes()
        {
            try
            {
                List<RegistroClientes> listaClientes = this.registroClientesDAO.GetListaClientes();

                return listaClientes;
            }
            catch (Exception x)
            {
                throw x;
            }
        }

        public object InsertClientes(string Nombre, string Domicilio, string Email)
        {
            try
            {
                RegistroClientes cliente = this.registroClientesDAO.InsertClientes(Nombre, Domicilio, Email);

                return cliente;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
        public object EditarClientes(int IdCliente, string Nombre, string Domicilio, string Email)
        {
            try
            {
                RegistroClientes cliente = this.registroClientesDAO.EditarClientes(IdCliente, Nombre, Domicilio, Email);

                return cliente;
            }
            catch (Exception x)
            {
                throw x;
            }
        }
    }
}