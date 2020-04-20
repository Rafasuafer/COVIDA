using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
    class Centro
    {
        private Sistema sistema;
        private Donacion donacion;

        #region Atributos
        private int id;
        private string nombre;
		private List<Voluntario> voluntarios;
        private string direccion;
		private List<Donacion> stock;

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
        public List<Donacion> Stock
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
            this.stock = new List<Donacion>();

        }

		public void sumarVoluntario(Voluntario nVol){
			//voluntarios.Add(nVol);
		}

        public string elCentro(string idCentro){
            string mensaje="";
            bool existe = false;
            int elCentro = int.Parse(idCentro);
            for(int i = 0; i< sistema.Centros.Count; i++){
                if (elCentro == sistema.Centros[i].Id){
                existe = true;
                mensaje = "Centro seleccionado";
                }else{
                mensaje = "El codigo del centro no es valido";
                }                                                           
            }
            return mensaje;
        }


		public override string ToString()
		{
			return "Centro: " + this.nombre + " | Direccion:"+ this.direccion;
		}

        public void recibirDonEco(string monto, Centro objCentro)
        {
            DateTime fecha = new DateTime();
            donacion.calcularValeEco(monto);
            Console.WriteLine(donacion.calcularValeEco(monto));
            int elMonto = int.Parse(monto);
            ingresarDonEco(elMonto, objCentro);
        }
        public string ingresarDonEco(double monto, Centro objCentro)
        {
            string mensaje = "";
            if (monto != 0)
            {
                sistema.newDonacionEcon(objCentro, monto);
            }
            else
            {
                mensaje = "Ingrese un monto mayor a 0";
            }
            return mensaje;
        }

        public void recibirDonProd(string unidades, Producto objProducto, Centro objCentro)
        {
            int cantUnidades = int.Parse(unidades);
            DateTime fecha = new DateTime();
            donacion.calcularValeProd(objProducto, cantUnidades);
            Console.WriteLine(donacion.calcularValeProd(objProducto, cantUnidades));
        }

        #endregion
    }
}
