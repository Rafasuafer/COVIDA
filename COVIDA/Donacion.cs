using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
    class Donacion
    {

        public enum TipoDon
        {
            economica = 1,
            producto = 2

        }
        #region Atributos
        private int id;
        private DateTime fecha;
        private TipoDon tipoDon;
		private Producto prod;


		#endregion

		#region Propiedades

		public DateTime Fecha
        {
            get { return fecha; }
        }
		public int Id
		{
			set { id = value; }
			get { return id; }
		}
        
        #endregion


        #region Metodos
        public Donacion(DateTime fecha, TipoDon tipoDon)
        {
            this.fecha = fecha;
            this.tipoDon = tipoDon;
        }

        #endregion
    }
}
