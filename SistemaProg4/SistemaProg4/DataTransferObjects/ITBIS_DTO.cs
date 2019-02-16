using System.Data;


namespace SistemaProg4
{
    public class ITBIS_DTO : ITBIS_DAO
    {
        // Propiedades
        private int id;
        private string ddescripcion;
        private float valor;

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
            get { return valor; }
            set { valor = value; }
        }

        //private ITBIS_DAO objcad = new ITBIS_DAO();
        // Metodos CRUD
        /// <summary>
        /// Mostrar registro
        /// </summary>
        /// <returns>todos los registro</returns>
        //public DataTable MostrarRegistros()
        //{
        //    DataTable tabla = new DataTable();
        //    tabla = MostrarRegistro();
        //    return tabla;
        //}

        //public void InsertarITBIS()
        //{
        //    Insertar(pDescripcion, pTarifa);
        //}
        //public void EditarITBIS()
        //{
        //    Editar(pId, pDescripcion, pTarifa);
        //}

        
    }
}
