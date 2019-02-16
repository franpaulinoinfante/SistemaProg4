using System;
using System.Windows.Forms;

namespace SistemaProg4.Formularios
{
    public partial class frm_ITBIS : Form
    {
        private ITBIS_DTO objITBIS_DTO = new ITBIS_DTO();
        private ITBIS_DAO objITBIS_DAO = new ITBIS_DAO();

        public frm_ITBIS()
        {
            InitializeComponent();
        }

        private void ITBIS_Load(object sender, EventArgs e)
        {
            MostrarITBIS();
        }

        private void MostrarITBIS()
        {
            try
            {
                dataGridView1.DataSource = objITBIS_DAO.ListITBIS();
            }
            catch (Exception ex)
            {   
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txt_ID.Text != string.Empty)
            {
                try
                {
                    objITBIS_DTO.pId = Convert.ToInt32(txt_ID.Text);
                    objITBIS_DTO.pDescripcion = txt_Drescripcion.Text.Trim();
                    objITBIS_DTO.pTarifa = float.Parse(txt_Tarifa.Text.Trim());
                    objITBIS_DTO.Editar(objITBIS_DTO);
                    MessageBox.Show("Datos registrado");
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
                    objITBIS_DTO.pDescripcion = txt_Drescripcion.Text.Trim();
                    objITBIS_DTO.pTarifa = float.Parse(txt_Tarifa.Text.Trim());
                    objITBIS_DAO.Insertar(objITBIS_DTO);

                    MessageBox.Show("Datos registrado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            MostrarITBIS();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 || dataGridView1.SelectedCells.Count > 0)
            {
                txt_ID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                txt_Drescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txt_Tarifa.Text = dataGridView1.CurrentRow.Cells["Valor"].Value.ToString();
            }
        }

        private void BtnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarCampos(this);
        }

        private void LimpiarCampos(Control control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
            }
        }
    }
}

