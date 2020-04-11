using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
    public class Producto
    {

        #region Atributos
        private int id;
        private string nombre;
        private decimal peso;
        private decimal precioUnitario;
        private int tipo;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public decimal Peso
        {
            get { return peso; }
            set { peso = value; }
        }
        public decimal PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }
        public int Tipo
        {
            get { return tipo; }
        }
        #endregion

        #region Metodos

        public Producto(int id, string nombre, decimal peso, decimal precioUnitario, int tipo)
        {
            this.id = id;
            this.nombre = nombre;
            this.peso = peso;
            this.precioUnitario = precioUnitario;
            this.tipo = tipo;
        }
        #endregion
    }
}
