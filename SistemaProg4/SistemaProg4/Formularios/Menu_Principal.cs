using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using SistemaProg4.Formularios;

namespace SistemaProg4
{
	public partial class Menu_Principal : Form
	{
		public Menu_Principal()
		{
			InitializeComponent();
		}

       

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]

		private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Esta Usted Seguro de Querer Cerrar Esta Ventana?", "Alerta¡¡¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				this.Close();

			}
		}

		private void BtnMinimizar_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		int LX, LY, SW, SH;

        private void ITBISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ITBIS MiForm = new frm_ITBIS();
            MiForm.Show();
        }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducto MiFOrm = new frmProducto();
            MiFOrm.Show();
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
		{
			LX = this.Location.X;
			LY = this.Location.Y;
			SW = this.Size.Width;
			SH = this.Size.Height;
			this.Size = Screen.PrimaryScreen.WorkingArea.Size;
			this.Location = Screen.PrimaryScreen.WorkingArea.Location;

			BtnMaximizar.Visible = false;
			btnRest.Visible = true;
		}

		private void btnRest_Click(object sender, EventArgs e)
		{
			this.Size = new Size(SW, SH);
			this.Location = new Point(LX, LY);

			btnRest.Visible = false;
			BtnMaximizar.Visible = true;
		}


	}
}
