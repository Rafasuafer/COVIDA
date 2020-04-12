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
        private static int ultimoId = 1;
        private DateTime fecha;
        private TipoDon tipoDon;


        #endregion

        #region Propiedades

        public DateTime Fecha
        {
            get { return fecha; }
        }
        
        #endregion


        #region Metodos
        public Donacion(DateTime fecha, TipoDon tipoDon)
        {
            id = ultimoId++;
            this.fecha = fecha;
            this.tipoDon = tipoDon;
        }

        #endregion
    }
}
}
