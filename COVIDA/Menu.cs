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


			// Builder
			public Menu()
			{
				salir = false;
			}

			#region Metodos

			public void bienvenida()
			{
				Console.WriteLine("\n##############\n### COVIDA ###\n##############");
				Console.WriteLine("|--------------------------|");
				Console.WriteLine("| Elianna Fiorina - 181332 |");
				Console.WriteLine("| Rafael  Suarez  - 250827 |");
				Console.WriteLine("|--------------------------|");
			}

			public void inicio()
			{

				while (!salir)
				{
					Console.WriteLine("\n### INICIO ###");
					mostrarOpciones();
					string input = pedirInput("Elija una Opcion:");
					switch (input)
					{
						case "1":
							donaciones();
							break;
						case "2":
							centros();
							break;
						case "3":
							buscarDonaciones();
							break;
						case "s":
							cerrar();
							break;
						default:
							break;
					}

				}
			}


			public void donaciones()
			{
				Console.WriteLine("\n### DONAR ###");
			}

			public void centros()
			{
				Console.WriteLine("\n### CENTROS ###");

			}

			public void buscarDonaciones()
			{
				Console.WriteLine("\n### BUSCAR DONACION ###");
			}

			public void mostrarOpciones()
			{
				Console.WriteLine("1 - Donar");
				Console.WriteLine("2 - Ver Centros");
				Console.WriteLine("3 - Ver Donaciones");
				Console.WriteLine("s - SALIR");
			}

			public string pedirInput(string msg)
			{
				Console.WriteLine(msg);
				string input = Console.ReadLine();

				return input;
			}

			public void cerrar()
			{
				Console.WriteLine("Adios!");
				this.salir = true;
			}

			#endregion



		}
	}
