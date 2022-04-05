using GpoAutofin.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GpoAutofin.Data.DB
{
    public class Examen_Marcos_LopezDB : IDBConnection
    {
        private string server { get; set; }
        private string bd { get; set; }

        private SqlConnection Connection;
        private string ConnectionString = "";
        private AppSettingsReader appSettings;

        public Examen_Marcos_LopezDB()
        {
            Connection = new SqlConnection();
            appSettings = new AppSettingsReader();
            this.SetDBParameters();
            ConnectionString = "Data Source =" + server + ";Initial Catalog =" + bd + ";Integrated Security=True";
        }

        private void SetDBParameters()
        {
            server = appSettings.GetValue("DBServer", typeof(string)).ToString();
            bd = appSettings.GetValue("Examen_Marcos_Lopez_DBName", typeof(string)).ToString();
        }
        public SqlConnection GetConnection()
        {
            this.Connection = null;
            try
            {
                this.Connection = new SqlConnection(this.ConnectionString);
                this.Connection.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return this.Connection;
        }

        public void CloseConnection()
        {
            try
            {
                if (this.Connection.State == System.Data.ConnectionState.Open)
                {
                    this.Connection.Close();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}