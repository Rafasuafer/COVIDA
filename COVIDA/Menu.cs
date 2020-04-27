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
            Console.WriteLine("\n# ALTA PRODUCTO #");

            string mensaje = "";
            mostrarTipoProducto();
            string tipo = "Ingrese el codigo del tipo de producto: ";
            int elTipo;
            int.TryParse(pedirInput(tipo), out elTipo);
            while (!validarTipo(elTipo))
            {
                Console.WriteLine("#ERROR: Ingrese un tipo valido!");
                mostrarTipoProducto();
                elTipo = int.Parse(pedirInput(tipo));
            }
            string nombre = "Ingrese el nombre del proudcto: ";
            string elNombre = pedirInput(nombre);
            if (validarNombre(elNombre))
            {
                Console.WriteLine("#ERROR: El nombre ya existe");
                elNombre = pedirInput(nombre);
            }
            string peso = "Ingrese el peso en Kg de una unidad del producto: ";
            int elPeso;
            Int32.TryParse(pedirInput(peso), out elPeso);
            if (!validarPeso(elPeso))
            {
                Console.WriteLine("#ERROR: Ingrese un valor mayor a 0");
                elPeso = int.Parse(pedirInput(peso));
            }
            string precio = "Ingrese el precio promedio unitario del producto: ";
            int elPrecio;
            Int32.TryParse(pedirInput(precio), out elPrecio);
            if (!validarPrecio(elPrecio))
            {
                Console.WriteLine("#ERROR: Ingrese un precio mayor a 0");
                elPrecio = int.Parse(pedirInput(precio));
            }
            Producto.TipoProd tipProd;
            switch (elTipo)
            {
                case 1:
                    tipProd = Producto.TipoProd.bebida;
                    break;
                case 2:
                    tipProd = Producto.TipoProd.alimentoNoPerecedero;
                    break;
                case 3:
                    tipProd = Producto.TipoProd.alimentoFresco;
                    break;
                case 4:
                    tipProd = Producto.TipoProd.productoLimpieza;
                    break;
                case 5:
                    tipProd = Producto.TipoProd.productoHigiene;
                    break;
                default:
                    tipProd = Producto.TipoProd.noExiste;
                    break;
            }
            if (validarTipo(elTipo) && validarPeso(elPeso) && validarPrecio(elPrecio) && !validarNombre(elNombre))
            {
                Producto producto = new Producto(elNombre, elPeso, elPrecio, tipProd);
                sistema.nuevoProducto(producto);
                mensaje = "Producto dado de alta correctamente";
            }
          
            Console.WriteLine(mensaje);
        }

        public bool validarTipo(int tipo)
        {
            bool existeTipo = false;
            if (tipo > 0 && tipo < 6)
            {
                existeTipo = true;
            }return existeTipo;
        }
        public bool validarPeso(int peso)
        {
        bool existePeso = false;
            if(peso > 0)
            {
                existePeso = true;
            }
            return existePeso;
        }
        public bool validarPrecio(int precio)
        {
            bool existePrecio = false;
            if (precio > 0)
            {
                existePrecio = true;
            }
            return existePrecio;
        }

        public bool validarNombre(string nombre)
        {
        bool existeNombre = false;
            int ite = 0;
            while (ite > sistema.Productos.Count)
            {
                if(nombre == sistema.Productos[ite].Nombre)
                {
                    existeNombre = true;
                }
            }return existeNombre;
        }
           /* if(existeTipo && existePrecio && existePeso && !existeNombre)
            {
                productoValido = true;
            }
            return productoValido;
        }*/

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
        {/*
			int.TryParse(pedirInput("Ingrese dia"), out int dia);
			int.TryParse(pedirInput("Ingrese mes"), out int mes);
			int.TryParse(pedirInput("Ingrese año"), out int año);*/
            DateTime fechaBuscada = new DateTime();

            while (!DateTime.TryParse(pedirInput("Ingrese fecha en formato: dd-mm-AAAA"), out fechaBuscada))
            {
                Console.WriteLine("Formato de fecha incorrecto.");
            }
            

			string laDonacion = sistema.getStrDonacionByFecha(fechaBuscada);
            Console.WriteLine(laDonacion);
        }

        public string mostrarListaProductos()
        {
            string productos = "#ERROR: No hay productos";
			if (sistema.Productos.Count > 0)
			{ 
				foreach (var listaProductos in sistema.Productos)
				{
					productos += listaProductos.ToString() + "\n";
				}
			}
			return productos;
        }


        #endregion


    }
	}
