using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class DALProveedor
    {
        private DALConexion conexion = new DALConexion();
        SqlDataReader dataReader;
        DataTable table = new DataTable();
        SqlCommand comando = new SqlCommand();

        public void CreateProveedor(string nombre, string telefono, string correo)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_INSERTAR_PROVEEDOR";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public DataTable ReadAllProveedor()
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_SELECCIONAR_ALL_PROVEEDOR";
            comando.CommandType = CommandType.StoredProcedure;
            dataReader = comando.ExecuteReader();
            table.Load(dataReader);
            conexion.CloseConnection();
            return table;
        }

        public void UpdateProveedor(string nombre, string telefono, string correo, int idProveedor)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ACTUALIZAR_PROVEEDOR";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", nombre);
            comando.Parameters.AddWithValue("@Telefono", telefono);
            comando.Parameters.AddWithValue("@Correo", correo);
            comando.Parameters.AddWithValue("@IdProveedor", idProveedor);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void DeleteProveedor(int idProveedor)
        {
            comando.Connection = conexion.OpenConnection();
            comando.CommandText = "SP_ELIMINAR_PROVEEDOR";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@IdProveedor", idProveedor);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
    }
}
