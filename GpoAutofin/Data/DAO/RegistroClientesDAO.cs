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
    public class RegistroClientesDAO
    {
        private IDBConnection DB;
        public RegistroClientesDAO()
        {
            DB = new Examen_Marcos_LopezDB();
        }
        public List<RegistroClientes> GetListaClientes()
        {
            SqlConnection dbConn = null;
            try
            {
                dbConn = DB.GetConnection();
                var clientes = dbConn.Query<RegistroClientes>("sp_GetListaClientes", commandType: CommandType.StoredProcedure).ToList();

                return clientes;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in GetListaClientes --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }

        public RegistroClientes InsertClientes(string Nombre, string Domicilio, string Email)
        {
            SqlConnection dbConn = null;

            RegistroClientes cliente = new RegistroClientes();
            try
            {
                dbConn = DB.GetConnection();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@Nombre", Nombre);
                queryParameters.Add("@Domicilio", Domicilio);
                queryParameters.Add("@Email", Email);
                cliente = dbConn.Query<RegistroClientes>("sp_InsertCliente", queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in InsertClientes --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }
        public RegistroClientes EditarClientes(int IdCliente, string Nombre, string Domicilio, string Email)
        {
            SqlConnection dbConn = null;

            RegistroClientes cliente = new RegistroClientes();
            try
            {
                dbConn = DB.GetConnection();
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@IdCliente", IdCliente);
                queryParameters.Add("@Nombre", Nombre);
                queryParameters.Add("@Domicilio", Domicilio);
                queryParameters.Add("@Email", Email);
                cliente = dbConn.Query<RegistroClientes>("sp_UpdateCliente", queryParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception($"DBException in EditarClientes --> {ex.Message}");
            }
            finally
            {
                if (dbConn != null)
                    dbConn.Close();
            }
        }
    }
}