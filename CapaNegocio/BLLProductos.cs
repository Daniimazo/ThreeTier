using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
     public class BLLProductos
    {

        private DALProductos objetoCD = new DALProductos();

        // Mostrar todos los productos
        public DataTable View()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ReadAllProductos();
            return tabla;
        }

        // Crear producto
        public void Create(string nombre, decimal precio, int stock)
        {
            objetoCD.CreateProducto(nombre, Convert.ToDecimal(precio), Convert.ToInt32(stock));
        }

        // Actualizar producto
        public void Update(int id, string nombre, decimal precio, int stock)
        {
            objetoCD.UpdateProducto(Convert.ToInt32(id), nombre, Convert.ToDecimal(precio), Convert.ToInt32(stock));
        }

        // Eliminar producto
        public void Delete(int id)
        {
            objetoCD.DeleteProducto(id);
        }
    }
}
