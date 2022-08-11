using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace crud_ws
{
    /// <summary>
    /// Descripción breve de grud_ws
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class grud_ws : System.Web.Services.WebService
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);

        [WebMethod]
        public bool Insertar(string rut, string nombre, string apellido, int edad)
        {

            string query = "INSERT INTO registro (rut,nombre,apellido,edad) VALUES(@rut,@nombre,@apellido,@edad)";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@rut", rut);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@edad", edad);
            cmd.ExecuteNonQuery();
            return true;

        }

        [WebMethod]
        public DataSet listar()
        {
      
            string query = "SELECT rut,nombre,apellido,edad FROM registro ORDER BY id ASC";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        [WebMethod]
        public DataSet buscar(string rut)
        {
            string query = "SELECT rut,nombre,apellido,edad FROM registro WHERE rut='" + rut + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        [WebMethod]
        public bool Eliminar(string rut)
        {
            string query = "DELETE FROM registro WHERE rut=@rut";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@rut", rut);
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        [WebMethod]
        public bool update(string rut, string nombre, string apellido, string edad)
        {

            string query = "UPDATE registro SET nombre=@nombre,apellido=@apellido,edad=@edad WHERE rut=@rut";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@rut", rut);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@edad", edad);
            cmd.ExecuteNonQuery();
            return true;

        }
    }
}
