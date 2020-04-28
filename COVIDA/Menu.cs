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
			
			// Builder
			public Menu()
			{
				salir = false;
				sistema = new Sistema();

			}
            
			#region Metodos

			// Cabecera
			public void bienvenida()
			{
				Console.WriteLine("\n##############\n### COVIDA ###\n##############");
				Console.WriteLine("|--------------------------|");
				Console.WriteLine("| Elianna Fiorina - 181332 |");
				Console.WriteLine("| Rafael  Suarez  - 250827 |");
				Console.WriteLine("|--------------------------|");
				
			}

			// Función contenedora del menu inicial
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
							altaProducto();
							break;
						case "2":
						    voluntarioPorCentros();

							break;
						case "3":
							mostrarListaProductos();
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

			// Opciones del menu inicial
			public void mostrarOpciones()
				{
					Console.WriteLine("1 - Alta Producto");
					Console.WriteLine("2 - Ver Voluntarios");
					Console.WriteLine("3 - Ver Producto a donar");
					Console.WriteLine("4 - Ver Donaciones por fecha");
					Console.WriteLine("s - SALIR");
				}

			// Menu de Alta de Producto
			public void altaProducto()
			{
				Console.WriteLine("\n# ALTA PRODUCTO #");

				string mensaje = "#ERROR: Alta invalida.";
				mostrarTipoProducto(); // Muestra los tipos de producto
				string tipo = "Ingrese el codigo del tipo de producto: ";
				int elTipo;
				int.TryParse(pedirInput(tipo), out elTipo); // Pide el tipo de producto, lo parsea y lo valida.
				while (!validarTipo(elTipo))
				{
					Console.WriteLine("#ERROR: Ingrese un tipo valido!");
					mostrarTipoProducto();
					elTipo = int.Parse(pedirInput(tipo));
				}
				string nombre = "Ingrese el nombre del proudcto: ";
				string elNombre = pedirInput(nombre); // Pide el nombre para el nuevo producto.
				// Si sistema devuelve un objeto, este ya existe y no debe darse de alta.
				if (sistema.getProductoByNombre(elNombre) != null) 
				{
					Console.WriteLine("#ERROR: El nombre ya existe");
					elNombre = pedirInput(nombre);
				}
				string peso = "Ingrese el peso en Kg de una unidad del producto: ";
				int elPeso;
				Int32.TryParse(pedirInput(peso), out elPeso);// Pide el peso del producto, lo parsea y lo valida.
				if (!validarPeso(elPeso))
				{
					Console.WriteLine("#ERROR: Ingrese un valor mayor a 0");
					elPeso = int.Parse(pedirInput(peso));
				}
				string precio = "Ingrese el precio promedio unitario del producto: ";
				int elPrecio;
				Int32.TryParse(pedirInput(precio), out elPrecio); // Pide el precio del producto, lo parsea y lo valida.
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
				// Si el producto es valido, lo pasa a Sistema para darlo de alta.
				if (validarTipo(elTipo) && validarPeso(elPeso) && validarPrecio(elPrecio) && (sistema.getProductoByNombre(elNombre) == null) )
				{
					Producto producto = new Producto(elNombre, elPeso, elPrecio, tipProd);
					if (sistema.nuevoProducto(producto))
					{
						mensaje = "#EXITO: Producto dado de alta correctamente";
					}
					
				}
          
				Console.WriteLine(mensaje);
			}

			#region Validaciones de Producto
			// Validan que las distintas inputs estén entre los parámetros aceptados.
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
			#endregion

			// Muestra todos los tipos de Producto
			public void mostrarTipoProducto()
				{
					Console.WriteLine("1 - Bebida");
					Console.WriteLine("2 - Alimento no peresedero");
					Console.WriteLine("3 - Alimento fresco");
					Console.WriteLine("4 - Productos de limpieza");
					Console.WriteLine("5 - Productos de higiene");
				}

			// Función genérica que recibe un string el cual será mostrado.
			// Captura la input del usuario y la retorna como string.
			public string pedirInput(string msg)
				{
					Console.WriteLine(msg);
					string input = Console.ReadLine();

					return input;
				}
			
			// Marca salir como true y muestra un mensaje.
			public void cerrar()
				{
					Console.WriteLine("Adios!");
					this.salir = true;
				}
			
			// Muestra todos los centros registrados en Sistema
			public string mostrarCentro()
			{
				string centro = null;
				foreach (var listaCentro in sistema.Centros)
				{
					centro += listaCentro.ToString() + "\n";               
				}
				return centro;
        
			}

			// El usuario elije un centro y solicita a Sistema un string con los voluntarios de dicho centro.
			public void voluntarioPorCentros()
			{
				Console.WriteLine("# CENTROS #");
				Console.WriteLine(mostrarCentro());
				string idCentro = "Seleccione el id del centro";
				string elId = pedirInput(idCentro);
				Console.WriteLine("# VOLUNTARIOS #");
				string elCentro = sistema.getStrVoluntariosCentro(elId);
				Console.WriteLine(elCentro);
				inicio();

				Console.ReadKey();

			}

			// Solicita una fecha y obtiene desde Sistema el string con donaciones realizadas en esa fecha.
			public void donacionesPorFecha()
			{
				DateTime fechaBuscada = new DateTime();

				while (!DateTime.TryParse(pedirInput("Ingrese fecha en formato: mm-dd-AAAA"), out fechaBuscada))
				{
					Console.WriteLine("Formato de fecha incorrecto.");
				}
            

				string laDonacion = sistema.getStrDonacionByFecha(fechaBuscada);
				Console.WriteLine(laDonacion);
			}

			// Retorna un string en base a la lista de Productos de sistema
			public void mostrarListaProductos()
			{
				string listaProd = "#ERROR: No hay productos";
				if (sistema.Productos.Count > 0)
				{
					listaProd = "# PRODUCTOS #";
					foreach (var listaProductos in sistema.Productos)
					{
						listaProd += listaProductos.ToString() + "\n";
					}
				}
				Console.WriteLine(listaProd);
			}


        #endregion


    }
	}
