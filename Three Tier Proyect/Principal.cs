using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Three_Tier_Proyect;

namespace CapaPresentacion
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void AddFormAsTab(Form form, string title)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            TabPage tab = new TabPage(title);
            tab.Controls.Add(form);
            tab.Tag = form;
            tabControlMain.TabPages.Add(tab);
            form.Show();
        }

        private void CloseTabAt(int index)
        {
            if (index >= 0 && index < tabControlMain.TabPages.Count)
            {
                var tab = tabControlMain.TabPages[index];
                if (tab.Tag is Form f)
                {
                    f.Close();
                    f.Dispose();
                }
                tabControlMain.TabPages.RemoveAt(index);
                tab.Dispose();
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            AddFormAsTab(frm, "Usuarios");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void tabControlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabPage = tabControlMain.TabPages[e.Index];
            var tabRect = tabControlMain.GetTabRect(e.Index);

            // Draw background
            e.Graphics.FillRectangle(SystemBrushes.Control, tabRect);

            // Draw title
            TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font, tabRect, Color.Black);

            // Draw close "x"
            var closeImageRect = new Rectangle(tabRect.Right - 18, tabRect.Top + 4, 12, 12);
            TextRenderer.DrawText(e.Graphics, "x", this.Font, closeImageRect, Color.Red);
        }

        private void tabControlMain_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControlMain.TabPages.Count; i++)
            {
                var r = tabControlMain.GetTabRect(i);
                var closeRect = new Rectangle(r.Right - 18, r.Top + 4, 12, 12);
                if (closeRect.Contains(e.Location))
                {
                    CloseTabAt(i);
                    break;
                }
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frmCliente = new frmCliente();
            AddFormAsTab(frmCliente, "Clientes");
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos F = new frmProductos();
            AddFormAsTab(F, "Productos");
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedores P = new frmProveedores();
            AddFormAsTab(P, "Proveedores");
        }
    }
}
