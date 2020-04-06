using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
	class Program
	{
		static void Main(string[] args)
		{
			Menu menu = new Menu();
			string input;

			menu.inicio();
			while (!menu.Salir)
			{
				menu.mostrarOpciones();
				input = Console.ReadLine();
				switch (input)
				{
					case "c":
						menu.cerrar();
						break;
					default:
						break;
				}

			}
			Console.ReadKey();
		}
	}
}
