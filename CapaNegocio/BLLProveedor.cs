using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLLProveedor
    {
        private DALProveedor objetoCD = new DALProveedor();

        public DataTable View()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ReadAllProveedor();
            return tabla;
        }

        public void Create(string nombre, string telefono, string correo)
        {
            objetoCD.CreateProveedor(nombre, telefono, correo);
        }

        public void Update(string nombre, string telefono, string correo, int idProveedor)
        {
            objetoCD.UpdateProveedor(nombre, telefono, correo, Convert.ToInt32(idProveedor));
        }

        public void Delete(int idProveedor)
        {
            objetoCD.DeleteProveedor(idProveedor);
        }
    }
}
