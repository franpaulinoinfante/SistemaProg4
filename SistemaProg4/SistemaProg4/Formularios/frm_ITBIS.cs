using System;
using System.Windows.Forms;



namespace SistemaProg4.Formularios
{
    public partial class frm_ITBIS : Form
    {
        private ITBIS_DTO objITBIS_DTO = new ITBIS_DTO();

        public frm_ITBIS()
        {
            InitializeComponent();
        }

        private void ITBIS_Load(object sender, EventArgs e)
        {
            //MostrarITBIS();
        }

        private void MostrarITBIS()
        {
            //dataGridView1.DataSource = objITBIS_DAO.MostrarITBIS();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((txt_ID.Text) == string.Empty)
            {
                try
                {
                    objITBIS_DTO.pDescripcion = txt_Drescripcion.Text.Trim();
                    objITBIS_DTO.pTarifa = float.Parse(txt_Tarifa.Text.Trim());
                    objITBIS_DTO.InsertarITBIS();
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
                    objITBIS_DTO.pId = int.Parse(txt_ID.Text);
                    objITBIS_DTO.pDescripcion = txt_Drescripcion.Text.Trim();
                    objITBIS_DTO.pTarifa = float.Parse(txt_Tarifa.Text.Trim());
                    objITBIS_DTO.EditarITBIS();
                    MessageBox.Show("Datos registrado");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            //MostrarITBIS();
        }

        private void txt_Drescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 || dataGridView1.SelectedCells.Count > 0)
            {
                txt_ID.Text = dataGridView1.CurrentRow.Cells["Id_ITBIS"].Value.ToString();
                txt_Drescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txt_Tarifa.Text = dataGridView1.CurrentRow.Cells["Valor"].Value.ToString();
            }
        }
    }
}

