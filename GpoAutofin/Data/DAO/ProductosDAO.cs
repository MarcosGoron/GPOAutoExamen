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
    public class ProductosDAO
    {
        private IDBConnection DB;
        public ProductosDAO()
        {
            DB = new Examen_Marcos_LopezDB();
        }

        public List<Productos> GetListaProductos()
        {
            SqlConnection dbConn = null;
            try
            {
                dbConn = DB.GetConnection();
                var prod = dbConn.Query<Productos>("sp_GetListaProductos", commandType: CommandType.StoredProcedure).ToList();

                return prod;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in GetListaProductos --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }

        public Productos InsertProductos(string Nombre, string Marca, decimal Costo, decimal PrecioVenta)
        {
            SqlConnection dbConn = null;

            try
            {
                dbConn = DB.GetConnection();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@Nombre", Nombre);
                queryParameters.Add("@Marca", Marca);
                queryParameters.Add("@Costo", Costo);
                queryParameters.Add("@PrecioVenta", PrecioVenta);
                var prod = dbConn.Query<Productos>("sp_InsertProducto", queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return prod;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in InsertProductos --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }
        public Productos EditarProducto(int IdProducto, string Nombre, string Marca, decimal Costo, decimal PrecioVenta)
        {
            SqlConnection dbConn = null;

            try
            {
                dbConn = DB.GetConnection();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@IdProducto", IdProducto);
                queryParameters.Add("@Nombre", Nombre);
                queryParameters.Add("@Marca", Marca);
                queryParameters.Add("@Costo", Costo);
                queryParameters.Add("@PrecioVenta", PrecioVenta);
                var prod = dbConn.Query<Productos>("sp_UpdateProducto", queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return prod;
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