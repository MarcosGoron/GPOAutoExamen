using Dapper;
using GpoAutofin.Data.DB;
using GpoAutofin.Data.Interfaces;
using GpoAutofin.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GpoAutofin.Data.DAO
{
    public class FacturaDAO
    {
        private IDBConnection DB;
        public FacturaDAO()
        {
            DB = new Examen_Marcos_LopezDB();
        }
        public List<ListaFactura> GetListaFacturas()
        {
            SqlConnection dbConn = null;
            try
            {
                dbConn = DB.GetConnection();
                var facturas = dbConn.Query<ListaFactura>("sp_GetListaFacturas", commandType: CommandType.StoredProcedure).ToList();

                return facturas;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in GetListaFacturas --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }
        public Factura InsertFactura(string NumeroFactura, string Cantidad, int IdProducto, int IdCliente, DateTime FechaHora)
        {
            SqlConnection dbConn = null;

            try
            {
                dbConn = DB.GetConnection();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@NumeroFactura", NumeroFactura);
                queryParameters.Add("@Cantidad", Cantidad);
                queryParameters.Add("@IdProducto", IdProducto);
                queryParameters.Add("@IdCliente", IdCliente);
                queryParameters.Add("@FechaHora", FechaHora);
                var fact = dbConn.Query<Factura>("sp_InsertFactura", queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return fact;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in InsertFactura --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }
        public Factura EditarFactura(int IdFactura, string Cantidad, int IdProducto)
        {
            SqlConnection dbConn = null;

            try
            {
                dbConn = DB.GetConnection();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@IdFactura", IdFactura);
                queryParameters.Add("@Cantidad", Cantidad);
                queryParameters.Add("@IdProducto", IdProducto);
                var factura = dbConn.Query<Factura>("sp_EditarFactura", queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return factura;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in EditarProducto --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }
    }
}