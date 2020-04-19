using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
	class Sistema
	{
		private List<Producto> productos;
		private List<Donacion> donaciones;
		private List<Centro> centros;
		private List<Voluntario> voluntarios;

		public List<Producto> Productos
		{
			set { productos = value; }
			get { return productos; }
		}
		public List<Donacion> Donaciones
		{
			set { donaciones = value; }
			get { return donaciones; }
		}
		public List<Centro> Centros
		{
			set { centros = value; }
			get { return centros; }
		}

		public Sistema(){

			productos = new List<Producto>();
			centros = new List<Centro>();
			donaciones = new List<Donacion>();
			precarga();
		}

		public void precarga(){
			#region PRODUCTOS
			nuevoProducto(new Producto("Papa", 1, 35, Producto.TipoProd.alimentoFresco));
			nuevoProducto(new Producto("Cebolla", 1, 45, Producto.TipoProd.alimentoFresco));
			nuevoProducto(new Producto("Kiwi", 1, 235, Producto.TipoProd.alimentoFresco));
			nuevoProducto(new Producto("Hipoclorito", 1, 90, Producto.TipoProd.productoLimpieza));
			nuevoProducto(new Producto("Desinfectante", 1, 130, Producto.TipoProd.productoLimpieza));
			nuevoProducto(new Producto("Alcohol en gel", 1, 250, Producto.TipoProd.productoHigiene));
			nuevoProducto(new Producto("Jabon", 1, 60, Producto.TipoProd.productoHigiene));
			nuevoProducto(new Producto("Leche", 1, 29, Producto.TipoProd.bebida));
			nuevoProducto(new Producto("Leche en polvo", 1, 110, Producto.TipoProd.alimentoNoPerecedero));
			nuevoProducto(new Producto("Lata choclo", 1, 30, Producto.TipoProd.alimentoNoPerecedero));
			nuevoProducto(new Producto("Lata arvejas", 1, 30, Producto.TipoProd.alimentoNoPerecedero));
			nuevoProducto(new Producto("Coquita en botella de vidrio :)", 1, 110, Producto.TipoProd.bebida));
			#endregion

			#region CENTROS
			nuevoCentro(new Centro("Shopping", "Calle 13"));
			nuevoCentro(new Centro("Hope", "18 de Julio y Bv.Artigas"));
			nuevoCentro(new Centro("Blandengues", "Av.Italia y L.A. Herrera"));
			nuevoCentro(new Centro("Prado", "Aigua y Valdense"));
			nuevoCentro(new Centro("Maroñas", "Veracierto y Chayos"));
			#endregion

			#region VOLUNTARIOS
			Voluntario v1 = new Voluntario("Gerardo", 12312312, 091234567, new DateTime(1978, 12, 20));
			Voluntario v2 = new Voluntario("Alberto", 98798798, 099876543, new DateTime(1990, 1, 2));
			Voluntario v3 = new Voluntario("Rafael", 50003983, 091665267, new DateTime(1999, 6, 28));
			Voluntario v4 = new Voluntario("Ignacio", 69123321, 46758181, new DateTime(1914, 6, 28));
			Voluntario v5 = new Voluntario("Pedro", 45645645, 11112222, new DateTime(1982, 9, 30));
			Voluntario v6 = new Voluntario("Alison", 78978978, 33334444, new DateTime(1995, 12, 20));
			Voluntario v7 = new Voluntario("Valeria", 32132132, 55556666, new DateTime(1991, 3, 2));
			Voluntario v8 = new Voluntario("Denna", 65465465, 77778888, new DateTime(1988, 9, 21));
			Voluntario v9 = new Voluntario("Gabriela", 75375375, 99991111, new DateTime(1984, 5, 28));
			Voluntario v10 = new Voluntario("Karen", 95195195, 15915915, new DateTime(1976, 12, 28));
			

			centros[0].sumarVoluntario(v1);
			centros[0].sumarVoluntario(v6);
			centros[0].sumarVoluntario(v7);
			centros[1].sumarVoluntario(v2);
			centros[1].sumarVoluntario(v7);
			centros[2].sumarVoluntario(v3);
			centros[2].sumarVoluntario(v8);
			centros[3].sumarVoluntario(v4);
			centros[3].sumarVoluntario(v9);
			centros[4].sumarVoluntario(v5);
			centros[4].sumarVoluntario(v10);
			#endregion

		}


		public void nuevoProducto(Producto nProd){
			nProd.Id = productos.Count;
			productos.Add(nProd);
		}

		public void nuevoCentro(Centro nCen)
		{
			nCen.Id = centros.Count;
			centros.Add(nCen);
		}

		public void nuevoVoluntario(Voluntario nVol)
		{
			bool existe = false;
			int ite = 0;
			while (ite < voluntarios.Count && !existe){
				if (nVol.Ci == voluntarios[ite].Ci){
					existe = true;
				}

				ite++;
			}

			if(!existe){ 
				voluntarios.Add(nVol);
			}
			else{
				Console.WriteLine("# ERROR: Voluntario ya existente.");
			}
		}


		public List<Producto> getProdsByType(Producto.TipoProd tipo)
		{
			List<Producto> productos = new List<Producto>();

			foreach (var item in productos)
			{
				if (item.Tipo == tipo){
					productos.Add(item);
				}
			}

			return productos;
		}

		public Centro getCentroById(int id){

			bool encontrado = false;
			Centro centro = null;
			int i = 0;
			while (!encontrado && i < centros.Count)
			{
				if (centros[i].Id == id)
				{
					centro = centros[i];
					encontrado = false;
				}
				i++;
			}
			return centro;
		}

		public void newDonacionEcon(Centro centro, int monto){

			DateTime hoy = new DateTime();
			Donacion donacion = new Donacion(hoy, Donacion.TipoDon.economica /*, centro*/);
			donacion.Valor = monto;
		

		}
	}
}
