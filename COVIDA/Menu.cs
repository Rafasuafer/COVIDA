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
            private Centro centro;
            private Producto producto;
        private Donacion donacion;
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
				Console.WriteLine("Selecione el tipo de donacion que desea realizar");
                mostrarTipoDonacion();
                string opcion = Console.ReadLine();
            //string mensaje = "ingrese una opcion correcta";

            switch (opcion)
            {
                case "1":
                    donacionesEconomicas();
                    break;
                case "2":
                    donacionesProductos();
                    break;
                default:
                    break;
            }
            



            Console.ReadKey();
			}

        
        public void mostrarTipoDonacion()
        {
            Console.WriteLine("1 - Economica  ");
            Console.WriteLine("2 - Producto ");
        }
        public void mostrarTipoProducto()
        {
            Console.WriteLine("1 - Bebida");
            Console.WriteLine("2 - Alimentos no peresederos");
            Console.WriteLine("3 - Alimentos frescos");
            Console.WriteLine("4 - Productos de limpieza");
            Console.WriteLine("5 - Productos de higiene");
        }
        public void donacionesEconomicas()
        {
            Console.WriteLine(mostrarCentro());
            string selCentro = "Seleccione el centro a donar";
            pedirInput(selCentro);
            Centro objCentro = sistema.getCentroById(selCentro);
            string msg = "Ingrese monto a donar en UYU";
            string monto = pedirInput(msg);
            centro.recibirDonEco(monto, objCentro);
            inicio();
            Console.ReadKey();

        }
        public void donacionesProductos()
        {
            Console.WriteLine(mostrarCentro());
            string selCentro = "Seleccione el centro a donar";
            pedirInput(selCentro);
            Centro objCentro = sistema.getCentroById(selCentro);
            mostrarTipoProducto();
            string tipoProducto = "Elija la categoria de producto a donar";
            pedirInput(tipoProducto);
            Console.WriteLine(mostrarListaProductos());
            string idProducto = "Ingrese el codigo del producto";
            pedirInput(idProducto);
            string unidades = "Ingrese la cantidad de unidades a donar";
            pedirInput(unidades);
            Producto objProducto = sistema.getProductoById(idProducto);
            centro.recibirDonProd(unidades, objProducto, objCentro);



        }
    

        public void centros()
			{
            
			}

			public void buscarDonaciones()
			{
				Console.WriteLine("\n### BUSCAR DONACION ###");
				Console.ReadKey();
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
        public string mostrarCentro()
        {
            string centro = null;
            foreach (var listaCentro in sistema.Centros)
            {
                centro += listaCentro.ToString();

               
            }
            return centro;
        
        }
        public string mostrarListaProductos()
        {
            string productos = null;
            foreach (var listaProductos in sistema.Productos)
            {
                productos += listaProductos.ToString();
            }
            return productos;
        }


        #endregion


    }
	}
