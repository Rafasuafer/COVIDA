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
		private static int ultimoId = 0;
        private string nombre;
		private List<Voluntario> voluntarios;
        private string direccion;
		private List<DonacionProducto> stock;

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

        public List<DonacionProducto> Stock
        {
            get { return stock; }
        }
        #endregion

        #region Metodos
        public Centro(string nombre, string direccion)
        {
			this.id = ultimoId++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.voluntarios = new List<Voluntario>();
            this.stock = new List<DonacionProducto>();
        }

		public bool sumarVoluntario(Voluntario nVol){
			bool added = false;
			if (!registrado(nVol))
			{
				voluntarios.Add(nVol);
				added = true;
			}

			return added;
		}

		public bool registrado(Voluntario vol){
			bool encontrado = false;
			int i = 0;
			while (!encontrado & i < voluntarios.Count)
			{
				if (voluntarios[i].Ci == vol.Ci)
				{
					encontrado = true;
				}
				i++;
			}
			return encontrado;
		}
		public bool registrado(int ci)
		{
			bool encontrado = false;
			int i = 0;
			while (!encontrado & i < voluntarios.Count)
			{
				if (voluntarios[i].Ci == ci)
				{
					encontrado = true;
				}
				i++;
			}
			return encontrado;
		}

		public override string ToString()
		{
			return "Id: " + this.id + "Centro: " + this.nombre + " | Direccion:"+ this.direccion;
		}

        #endregion
    }
}
