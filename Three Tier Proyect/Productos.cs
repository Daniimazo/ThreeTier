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
    public partial class frmProductos : Form
    {
        BLLProductos objetoCN = new BLLProductos();
        private int id = 0;
        private bool Editar = false;
        private void ViewAllProducto()
        {

            BLLProductos objeto = new BLLProductos();
            dgvProductos.DataSource = objeto.View();

        }

        private void ClearControls()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            ViewAllProducto();
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.Font = new Font("Segoe UI", 10);
            // Configuración de colores
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.DefaultCellStyle.BackColor = Color.White;
            dgvProductos.DefaultCellStyle.ForeColor = Color.Black;
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvProductos.RowHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvProductos.EnableHeadersVisualStyles = false;
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
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
                        MessageBox.Show("Falta Ingresar el Nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombre.Focus();
                        return;
                    }
                    if (txtPrecio.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el precio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPrecio.Focus();
                        return;
                    }
                    if (txtStock.Text == "")
                    {
                        MessageBox.Show("Falta Ingresar el Nro de Stock", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtStock.Focus();
                        return;
                    }
                    objetoCN.Create(txtNombre.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text));
                    MessageBox.Show("Se guardo correctamente");
                    ViewAllProducto();
                    ClearControls();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }

            if (Editar == true)
            {

                try
                {
                    objetoCN.Update(id, txtNombre.Text, Convert.ToDecimal(txtPrecio.Text), Convert.ToInt32(txtStock.Text));
                    MessageBox.Show("Registro actualizado correctamente");
                    ViewAllProducto();
                    ClearControls();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar los datos, se encontro el siguiente error : " + ex);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
                id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);
            }

            else
                MessageBox.Show("Debe seleccionar un resgistro en el DataGridView");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["Id"].Value);
                objetoCN.Delete(id);
                MessageBox.Show("Registro eliminado correctamente");

                // Elimina la fila seleccionada del DataGridView sin recargar toda la tabla
                dgvProductos.Rows.RemoveAt(dgvProductos.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un resgistro en el DataGridView");
            }
        }
    }
}
