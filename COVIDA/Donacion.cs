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
        private Sistema sistema;
        public enum TipoDon
        {
            economica = 1,
            producto = 2

        }
		#region Atributos
		private int id;
		private static int ultimoId;
		private double valor;
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
		public double Valor
		{
			set { valor = value; }
			get { return valor; }
		}

		#endregion


		#region Metodos
		public Donacion(DateTime fecha, TipoDon tipoDon)
        {
            this.fecha = fecha;
            this.tipoDon = tipoDon;
        }
        
        public string calcularValeEco(string montostr)
        {

            int monto = int.Parse(montostr);
            double vale = 0;
            string mensaje = "";
            if (monto <= 1000)
            {
                vale = monto * 0.05;
                mensaje = "Recibie un vale de: $" + vale + " para su proxima compra";
            }
            else
            {
                if(monto > 1000 && monto <= 2000)
                {
                    vale = monto * 0.08;
                    mensaje = "Recibie un vale de: $" + vale + " para su proxima compra";
                }
                else
                {
                    vale = monto * 0.1;
                    mensaje = "Recibie un vale de: $" + vale + " para su proxima compra";
                }
            }
            if(vale == 0)
            {
                mensaje = "Ingrese un valor mayor a 0";
            }

            return mensaje;

        }

       

        

        public string calcularValeProd(Producto objProducto, int cantUnidades)
        {
            double valor;
            double vale;
            string mensaje = "";
            valor = objProducto.Precio * cantUnidades;
            if(valor >1000 && valor <= 2000)
            {
                vale = valor * 0.1;
                mensaje = "Recibie un vale de: $" + vale + " para su proxima compra";
            }
            if (valor > 2000)
            {
                vale = valor * 0.12;
                mensaje = "Recibie un vale de: $" + vale + " para su proxima compra";
            }
            if(valor == 0)
            {
                mensaje = "Ingrese una donacion valida";
            }
            return mensaje;
        }

        #endregion
    }
}
