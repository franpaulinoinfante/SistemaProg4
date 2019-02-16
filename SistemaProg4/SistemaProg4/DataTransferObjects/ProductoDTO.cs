using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaProg4.DataAccessObject;

namespace SistemaProg4.DataTransferObjects
{
    public class ProductoDTO: ProductoDAO
    {
        private int id;
        private string marca;
        private string modelo;
        private string descripcion;
        private string notas;
        private byte imagen;
        private int id_ITBIS;

        public int pId { get => id; set => id = value; }
        public string pMarca { get => marca; set => marca = value; }
        public string pModelo { get => modelo; set => modelo = value; }
        public string pDescripcion { get => descripcion; set => descripcion = value; }
        public string pNotas { get => notas; set => notas = value; }
        public byte pImagen { get => imagen; set => imagen = value; }
        public int pId_ITBIS { get => id_ITBIS; set => id_ITBIS = value; }
    }
}
