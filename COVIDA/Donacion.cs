using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
    class Donacion
    {
        private Producto producto;
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
        public void recibirDonEco(string monto)
        {
            DateTime fecha = new DateTime();
            Donacion donacion = new Donacion(fecha, TipoDon.economica);
            donacion.calcularValeEco(monto);
            Console.WriteLine(donacion.calcularValeEco(monto));
            int elMonto = int.Parse(monto);
            ingresarDonEco(elMonto, fecha);
        }

        public string calcularValeEco(string montostr)
        {

            int monto = int.Parse(montostr);
            double vale = 0;
            if (monto <= 1000)
            {
                vale = monto * 0.05;
            }
            else
            {
                if(monto > 1000 && monto <= 2000)
                {
                    vale = monto * 0.08;
                }
                else
                {
                    vale = monto * 0.1;
                }
            }
            string mensaje = "Recibie un vale de: $" + vale + " para su proxima compra";


            return mensaje;

        }

       /* public string ingresarDonEco(double monto, DateTime fecha)
        {
            string mensaje="";
            if( monto != 0){
            Donacion donacion = new Donacion(fecha, TipoDon.economica);
                //Sistema agregar = new Sistema();
                agregar.Donaciones.Add(donacion);
            }else{
                mensaje = "Ingrese un monto mayor a 0";
            }
            return mensaje;
        }*/

        public void recibirDonProd(string tipo , string unidades)
        {
            int cantUnidades = int.Parse(unidades);
            DateTime fecha = new DateTime();
            Donacion donacion = new Donacion(fecha, TipoDon.producto);
            donacion.calcularValeProd(tipo, cantUnidades);
            Console.WriteLine(calcularValeProd(tipo, cantUnidades));
        }

        public string calcularValeProd(string tipo, int cantUnidades)
        {
            string mensaje = "";
            return mensaje;
        }

        #endregion
    }
}
