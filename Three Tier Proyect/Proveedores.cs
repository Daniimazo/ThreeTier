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

namespace Three_Tier_Proyect
{
    public partial class frmProveedores : Form
    {
        private bool Editar = false;
        private int idProveedor = 0;
        private BLLProveedor objetoCN = new BLLProveedor();
        private void ClearControls()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            Editar = false;
        }

        private void ViewAllProveedor()
        {
            BLLProveedor objeto = new BLLProveedor();
            dgvProveedores.DataSource = objeto.View();
        }

        public frmProveedores()
        {
            InitializeComponent();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            ViewAllProveedor();
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedores.Font = new Font("Segoe UI", 10);

            // Configuración de colores - AGREGA ESTAS LÍNEAS
            dgvProveedores.BackgroundColor = Color.White;
            dgvProveedores.DefaultCellStyle.BackColor = Color.White;
            dgvProveedores.DefaultCellStyle.ForeColor = Color.Black;
            dgvProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvProveedores.RowHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvProveedores.EnableHeadersVisualStyles = false;
            dgvProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    //Validación de controles
                    if (txtNombre.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Nombre del Proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombre.Focus();
                        return;
                    }
                    if (txtTelefono.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Teléfono", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTelefono.Focus();
                        return;
                    }
                    if (txtCorreo.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCorreo.Focus();
                        return;
                    }

                    objetoCN.Create(txtNombre.Text, txtTelefono.Text, txtCorreo.Text);
                    MessageBox.Show("Se guardó correctamente");
                    ViewAllProveedor();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontró el siguiente error: " + ex);
                }
            }
            if (Editar == true)
            {
                try
                {
                    objetoCN.Update(txtNombre.Text, txtTelefono.Text, txtCorreo.Text, idProveedor);
                    MessageBox.Show("Registro actualizado correctamente");
                    ViewAllProveedor();
                    ClearControls();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar los datos, se encontró el siguiente error: " + ex);
                }
                ClearControls();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dgvProveedores.CurrentRow.Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvProveedores.CurrentRow.Cells["Telefono"].Value.ToString();
                txtCorreo.Text = dgvProveedores.CurrentRow.Cells["Correo"].Value.ToString();
                idProveedor = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["IdProveedor"].Value);
            }
            else
                MessageBox.Show("Debe seleccionar un registro en el DataGridView");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                idProveedor = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["IdProveedor"].Value);
                objetoCN.Delete(idProveedor);
                MessageBox.Show("Registro eliminado correctamente");
                // Elimina la fila seleccionada del DataGridView sin recargar toda la tabla
                dgvProveedores.Rows.RemoveAt(dgvProveedores.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un registro en el DataGridView");
            }
        }
    }
}
