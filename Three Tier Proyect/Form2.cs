using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion;

namespace Three_Tier_Proyect
{
    public partial class frmCliente : Form
    {
        BLLCliente objetoCN = new BLLCliente();
        private int id = 0;
        private bool Editar = false;
        private void ViewAllCliente()
        {

            dgvClientes.DataSource = objetoCN.View();
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Opcional, ajusta el tamaño de las columnas
            dgvClientes.Font = new Font("Segoe UI", 10); // Cambia el nombre y tamaño según prefieras

        }
        private void ClearControls()
        {
            txtNombreClientes.Clear();
            txtApellidoClientes.Clear();
            txtEdadClientes.Clear();
            txtCiudadClientes.Clear();
        }

        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            ViewAllCliente();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    // Validación de controles...

                    objetoCN.Create(txtNombreClientes.Text, txtApellidoClientes.Text, Convert.ToInt32(txtEdadClientes.Text), txtCiudadClientes.Text);
                    MessageBox.Show("Se guardó correctamente");

                    // Agrega la nueva fila al DataTable enlazado al DataGridView
                    DataTable dt = dgvClientes.DataSource as DataTable;
                    if (dt != null)
                    {
                        DataRow newRow = dt.NewRow();
                        // Si tienes columna Id autoincremental, puedes dejarlo vacío o recargar el último Id si lo necesitas
                        newRow["nombres"] = txtNombreClientes.Text;
                        newRow["apellidos"] = txtApellidoClientes.Text;
                        newRow["edad"] = txtEdadClientes.Text;
                        newRow["ciudad"] = txtCiudadClientes.Text;
                        dt.Rows.Add(newRow);
                    }

                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontró el siguiente error : " + ex);
                }
            }

            if (Editar == true)
            {
                try
                {
                    objetoCN.Update(txtNombreClientes.Text, txtApellidoClientes.Text, Convert.ToInt32(txtEdadClientes.Text), txtCiudadClientes.Text, id);
                    MessageBox.Show("Registro actualizado correctamente");

                    // Actualiza solo la fila seleccionada en el DataGridView
                    var row = dgvClientes.CurrentRow;
                    row.Cells["nombres"].Value = txtNombreClientes.Text;
                    row.Cells["apellidos"].Value = txtApellidoClientes.Text;
                    row.Cells["edad"].Value = txtEdadClientes.Text;
                    row.Cells["ciudad"].Value = txtCiudadClientes.Text;

                    ClearControls();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id"].Value);
                objetoCN.Delete(id);
                MessageBox.Show("Registro eliminado correctamente");

                // Elimina la fila seleccionada del DataGridView sin recargar toda la tabla
                dgvClientes.Rows.RemoveAt(dgvClientes.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un resgistro en el DataGridView");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombreClientes.Text = dgvClientes.CurrentRow.Cells["nombres"].Value.ToString();
                txtApellidoClientes.Text = dgvClientes.CurrentRow.Cells["apellidos"].Value.ToString();
                txtEdadClientes.Text = dgvClientes.CurrentRow.Cells["edad"].Value.ToString();
                txtCiudadClientes.Text = dgvClientes.CurrentRow.Cells["ciudad"].Value.ToString();
                id = Convert.ToInt32(dgvClientes.CurrentRow.Cells["Id"].Value);
            }
            else
                MessageBox.Show("Debe seleccionar un resgistro en el DataGridView");
        }
    }
}
