using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
	class Menu
	{
		// Atributos
		private bool salir;
		// Propiedades
		public bool Salir{
			get { return salir; }
		}
		// Builder
		public Menu()
		{
			salir = false;
		}

		#region Metodos
		public void inicio()
		{
			Console.WriteLine("##############\n### COVIDA ###\n##############");
			Console.WriteLine("\n");
		}
		public void mostrarOpciones()
		{
			Console.WriteLine("s - CERRAR");
		}

		public void cerrar(){
			this.salir = false;
		}

		#endregion
	}
}
