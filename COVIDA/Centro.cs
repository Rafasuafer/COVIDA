using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
    class Centro
    {

        #region Atributos
        private int id;
        private static int ultimoId = 1;
        private string nombre;
        private int cantidadVol;
        private string direccion;
        private int stock;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get { return nombre; }
        }
        public int CantidadVol
        {
            get { return cantidadVol; }
        }
        public string Direccion
        {
            get { return direccion; }
        }
        public int Stock
        {
            get { return stock; }
        }
        #endregion


        #region Metodos
        public Centro(string nombre, int cantidadVol, string direccion, int stock)
        {
            id = ultimoId++;
            this.nombre = nombre;
            this.cantidadVol = cantidadVol;
            this.direccion = direccion;
            this.stock = stock;
        }

        #endregion
    }
}
