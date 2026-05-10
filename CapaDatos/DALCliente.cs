using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{

    public class DALCliente
    {
        private DALConexion conexion = new DALConexion();

        SqlDataReader dataReader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void CreateCliente(string nombres, string apellidos, int edad, string ciudad)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_INSERTAR_CLIENTE"; // <-- Asegúrate que este es el nombre correcto
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombres", nombres);
            comando.Parameters.AddWithValue("@apellidos", apellidos);
            comando.Parameters.AddWithValue("@edad", edad);
            comando.Parameters.AddWithValue("@ciudad", ciudad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable ReadAllCliente()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_SELECCIONAR_ALL_CLIENTE";
            comando.CommandType = CommandType.StoredProcedure;
            dataReader = comando.ExecuteReader();
            table.Load(dataReader);
            conexion.CloseConnection();
            return table;
        }

        public void UpdateCliente(string nombres, string apellidos, int edad, string ciudad, int id)
        {

            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ACTUALIZAR_CLIENTE";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombres", nombres);
            comando.Parameters.AddWithValue("@apellidos", apellidos);
            comando.Parameters.AddWithValue("@edad", edad);
            comando.Parameters.AddWithValue("@ciudad", ciudad);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void DeleteCliente(int id)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ELIMINAR_CLIENTE";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
