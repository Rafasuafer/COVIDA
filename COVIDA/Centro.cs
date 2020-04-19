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
        private string nombre;
		private List<Voluntario> voluntarios;
        private string direccion;
		private List<Producto> stock;

		#endregion

		#region Propiedades
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		public string Nombre
        {
            get { return nombre; }
		}
		public int cantidadVol
		{
			get { return voluntarios.Count; }
		}
		public List<Voluntario> Voluntarios
		{
			get { return voluntarios; }
			set { voluntarios = value; }
		}
		public string Direccion
        {
            get { return direccion; }
        }
        public List<Producto> Stock
        {
            get { return stock; }
        }
        #endregion


        #region Metodos
        public Centro(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
        }


		public void sumarVoluntario(Voluntario nVol){
			voluntarios.Add(nVol);
		}

        public string elCentro(string idCentro, Sistema sistemas){
            string mensaje="";
            int elCentro = int.Parse(idCentro);
            for(int i = 0; i<sistemas.Centros.Count; i++){
                bool existe = false;
                if (elCentro == sistemas.Centros[i].Id){
                existe = true;
                mensaje = "Centro seleccionado";
                }else{
                mensaje = "El codigo del centro no es valido";
                }                                                           
            }
            return mensaje;
        }


        #endregion
    }
}
