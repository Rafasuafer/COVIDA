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
		private List<DonacionEconomica> stock;

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
        public List<DonacionEconomica> Stock
        {
            get { return stock; }
        }
        #endregion

        #region Metodos
        public Centro(string nombre, string direccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.voluntarios = new List<Voluntario>();
            this.stock = new List<DonacionEconomica>();

        }

		public void sumarVoluntario(Voluntario nVol){
			voluntarios.Add(nVol);
		}

   		public override string ToString()
		{
			return "Id: " + this.id + "Centro: " + this.nombre + " | Direccion:"+ this.direccion;
		}

        #endregion
    }
}
