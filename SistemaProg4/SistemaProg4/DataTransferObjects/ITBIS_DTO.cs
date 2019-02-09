using System.Data;


namespace SistemaProg4
{
    class ITBIS_DTO : ITBIS_DAO
    {
        // Propiedades
        private int id;
        private string ddescripcion;
        private float tarifa;

        public int pId
        {
            get { return id; }
            set { id = value; }
        }

        public string pDescripcion
        {
            get { return ddescripcion; }
            set { ddescripcion = value; }
        }

        public float pTarifa
        {
            get { return tarifa; }
            set { tarifa = value; }
        }

        //private ITBIS_DAO objcad = new ITBIS_DAO();
        // Metodos CRUD
        /// <summary>
        /// Mostrar registro
        /// </summary>
        /// <returns>todos los registro</returns>
        public DataTable MostrarITBIS()
        {
            DataTable tabla = new DataTable();
            tabla = MostrarDatos();
            return tabla;
        }

        public void InsertarITBIS()
        {
            Insertar(pDescripcion, pTarifa);
        }
        public void EditarITBIS()
        {
            Editar(pId, pDescripcion, pTarifa);
        }
    }
}
