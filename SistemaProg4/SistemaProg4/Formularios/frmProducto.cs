using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaProg4.DataAccessObject;
using SistemaProg4.DataTransferObjects;

namespace SistemaProg4.Formularios
{
    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
        }

        private ProductoDAO objProductoDao = new ProductoDAO();
        private ProductoDTO objProductoDto = new ProductoDTO();



        private void FrmProducto_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            MostrarImpuesto();
        }

        private void MostrarImpuesto()
        {
            ITBIS_DAO objITBISDAo = new ITBIS_DAO();
            //cmbImpuesto.DataSource = objProductoDao.ListarImpuesto();

            cmbImpuesto.DataSource = objITBISDAo.ListITBIS();
            cmbImpuesto.DisplayMember = "Descripcion";
            cmbImpuesto.ValueMember = "ID";
        }

        private void MostrarProductos()
        {
            try
            {
                dgvProducto.DataSource = objProductoDao.ListProducto();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DgvProducto_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count > 0 || dgvProducto.SelectedCells.Count > 0)
            {
                txt_Id.Text = dgvProducto.CurrentRow.Cells["ID"].Value.ToString();
                txt_Marca.Text = dgvProducto.CurrentRow.Cells["Marca"].Value.ToString();
                txt_Modelo.Text = dgvProducto.CurrentRow.Cells["Modelo"].Value.ToString();
                txt_Descripcion.Text = dgvProducto.CurrentRow.Cells["Descripción"].Value.ToString();
                txt_Nota.Text = dgvProducto.CurrentRow.Cells["Notas"].Value.ToString();

                if (cmbImpuesto.SelectedIndex >= 0)
                {
                    cmbImpuesto.SelectedIndex = -1;
                    cmbImpuesto.SelectedText = dgvProducto.CurrentRow.Cells["ITBIS"].Value.ToString();

                }



            }
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text != string.Empty)
            {
                try
                {
                    objProductoDto.pId = int.Parse(txt_Id.Text);
                    objProductoDto.pMarca = txt_Marca.Text;
                    objProductoDto.pModelo = txt_Modelo.Text;
                    objProductoDto.pDescripcion = txt_Descripcion.Text;
                    objProductoDto.pNotas = txt_Nota.Text;
                    //objProductoDto.pImagen = pictureBox1;
                    objProductoDto.pId_ITBIS = Convert.ToInt32(cmbImpuesto.SelectedValue);
                    objProductoDao.EditarProducto(objProductoDto);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    objProductoDto.pMarca = txt_Marca.Text;
                    objProductoDto.pModelo = txt_Modelo.Text;
                    objProductoDto.pDescripcion = txt_Descripcion.Text;
                    objProductoDto.pNotas = txt_Nota.Text;
                    //objProductoDto.pImagen = pictureBox1;
                    objProductoDto.pId_ITBIS = Convert.ToInt32(cmbImpuesto.SelectedValue);
                    objProductoDao.InsertarProducto(objProductoDto);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }
            MostrarProductos();
        }
    }
}
