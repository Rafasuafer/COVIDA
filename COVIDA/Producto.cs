using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA


{

  
    class Producto
    {

        public enum TipoProd
        {
            bebida = 1,
            alimentoNoPerecedero = 2,
            alimentoFresco = 3,
            productoLimpieza = 4,
            productoHigiene = 5

        }
        #region Atributos
        private int id;
        private static int ultimoId = 1;
        private string nombre;
        private decimal peso;
        private decimal precio; 
        private TipoProd tipoProd;


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
		public decimal Precio
		{
			get { return precio; }
		}

		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		#endregion


		#region Metodos
		public Producto(string nombre, decimal peso, decimal precio, TipoProd tipoProd)
        {
            this.nombre = nombre;
            this.peso = peso;
            this.precio = precio;
            this.tipoProd = tipoProd;
        }

        #endregion
    }
}
