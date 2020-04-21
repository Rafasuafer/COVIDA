using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
    class DonacionEconomica
    {
       		#region Atributos
		private int id;
		private static int ultimoId = 1;
		private double valor;
		private DateTime fecha;
		#endregion

		#region Propiedades

		public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}
		public int Id
		{
			get { return id; }
		}
		public double Valor
		{
			set { valor = value; }
			get { return valor; }
		}

		#endregion


		#region Metodos
		public DonacionEconomica()
		{
			id = ultimoId++;
			this.fecha = new DateTime();
		}
		public DonacionEconomica(double monto)
		{
			id = ultimoId++;
			this.fecha = new DateTime();
			this.valor = monto;
		}
		public DonacionEconomica(double monto, DateTime fecha)
		{
			id = ultimoId++;
			this.fecha = fecha;
			this.valor = monto;

		}

		public virtual double calcularVale()
        {
            double vale = 0;
            if (valor <= 1000)
            {
                vale = valor * 0.05;
            }
			else if(valor > 1000 && valor <= 2000){
				vale = valor * 0.08;
			}
			else{
				vale = valor * 0.1;
			}

            return vale;
		}

		public override string ToString()
		{
			return "ID: "+ id.ToString() + "Fecha: " + this.fecha.ToShortDateString() + "Monto: " + valor.ToString();
		}

		#endregion
	}
}
