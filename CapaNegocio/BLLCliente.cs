using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class BLLCliente
    {
        private DALCliente objetoCD = new DALCliente();

        public DataTable View()
        {

            DataTable tabla = new DataTable();
            tabla = objetoCD.ReadAllCliente();
            return tabla;
        }
        public void Create(string nombres, string apellidos, int edad, string ciudad)
        {

            objetoCD.CreateCliente(nombres, apellidos, Convert.ToInt32(edad), ciudad);
        }

        public void Update(string nombres, string apellidos,int edad, string ciudad, int id)
        {
            objetoCD.UpdateCliente(nombres, apellidos, Convert.ToInt32(edad), ciudad, Convert.ToInt32(id));
        }

        public void Delete(int id)
        {

            objetoCD.DeleteCliente(id);
        }
    }
}
