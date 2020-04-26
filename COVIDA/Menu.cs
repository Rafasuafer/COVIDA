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
			private Sistema sistema;

			// Propiedades


			// Builder
			public Menu()
			{
				salir = false;
				Sistema sistema = new Sistema();

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
				sistema = new Sistema();
				

				while (!salir)
				{
					Console.WriteLine("\n### INICIO ###");
					mostrarOpciones();
					string input = pedirInput("Elija una Opcion:");
					switch (input)
					{
						case "1":
							altaProducto();
							break;
						case "2":
						    VoluntarioPorCentros();

							break;
						case "3":
							buscarProductos();
							break;
                        case "4":
                            donacionesPorFecha();
                            break;
                        case "s":
							cerrar();
							break;
						default:
							break;
					}

				}
			}


			public void mostrarOpciones()
			{
				Console.WriteLine("1 - Alta Producto");
				Console.WriteLine("2 - Ver Voluntarios");
				Console.WriteLine("3 - Ver Producto a donar");
                Console.WriteLine("4 - Ver Donaciones por fecha");
                Console.WriteLine("s - SALIR");
			}
        public void buscarProductos()
        {
            Console.WriteLine("Los productos para donar son: ");

            Console.WriteLine(mostrarListaProductos());
            Console.ReadKey();
        }
        public void altaProducto()
        {
            mostrarTipoProducto();
            string tipo = "Ingrese el codigo del tipo de producto: ";
            pedirInput(tipo);
            string nombre = "Ingrese el nombre del proudcto: ";
            pedirInput(nombre);
            string peso = "Ingrese el peso en Kg de una unidad del producto: ";
            pedirInput(peso);
            string precio = "Ingrese el precio promedio unitario del producto: ";
            pedirInput(precio);
            //agregarDonacion(tipo, nombre, peso, precio);
        }
        public void mostrarTipoProducto()
        {
            Console.WriteLine("1 - Bebida");
            Console.WriteLine("2 - Alimento no peresedero");
            Console.WriteLine("3 - Alimento fresco");
            Console.WriteLine("4 - Productos de limpieza");
            Console.WriteLine("5 - Productos de higiene");
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
        public string mostrarCentro()
        {
            string centro = null;
            foreach (var listaCentro in sistema.Centros)
            {
                centro += listaCentro.ToString();

               
            }
            return centro;
        
        }
        public void VoluntarioPorCentros()
        {
            Console.WriteLine(mostrarCentro());
            string idCentro = "Seleccione el id del centro";
            string elId = pedirInput(idCentro);
            string elCentro = sistema.getStrVoluntariosCentro(elId);
            Console.WriteLine(elCentro);
            inicio();

            Console.ReadKey();

        }

        public void donacionesPorFecha()
        {
			int.TryParse(pedirInput("Ingrese dia"), out int dia);
			int.TryParse(pedirInput("Ingrese mes"), out int mes);
			int.TryParse(pedirInput("Ingrese año"), out int año);

			string laDonacion = sistema.getStrDonacionByFecha(new DateTime(año, mes, dia));
            Console.WriteLine(laDonacion);
        }

        public string mostrarListaProductos()
        {
            string productos = null;
            foreach (var listaProductos in sistema.Productos)
            {
                productos += listaProductos.ToString() + "\n";
            }
            return productos;
        }


        #endregion


    }
	}
