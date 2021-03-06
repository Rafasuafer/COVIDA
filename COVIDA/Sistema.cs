﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
	class Sistema
	{
		private List<Producto> productos;
		private List<DonacionEconomica> donaciones;
		private List<Centro> centros;
		private List<Voluntario> voluntarios;

		public List<Producto> Productos
		{
			set { productos = value; }
			get { return productos; }
		}
		public List<DonacionEconomica> Donaciones
		{
			set { donaciones = value; }
			get { return donaciones; }
		}
		public List<Centro> Centros
		{
			set { centros = value; }
			get { return centros; }
		}
		public List<Voluntario> Voluntarios
		{
			set { voluntarios = value; }
			get { return voluntarios; }
		}

		public Sistema(){

			productos = new List<Producto>();
			centros = new List<Centro>();
			donaciones = new List<DonacionEconomica>();
			voluntarios = new List<Voluntario>();
			precarga();
		}

		// Precarga de datos. Se llama al instanciar Sistema.
		public void precarga(){
			Console.WriteLine("### INICIO PRECARGA ### \n");
			cargaProductos();
			cargaCentros();
			cargaVoluntarios();
			cargaDonaciones();
			Console.WriteLine("\n### FIN PRECARGA ###");

		}

		// Recibe un producto, lo valida y si es valido, lo añade a la Lista.
		public bool nuevoProducto(Producto nProd){
			bool agregado = false;
			bool peso = nProd.Peso > 0;
			bool precio = nProd.Precio > 0;
			bool encontrado = false;
			int i = 0;
			while (!encontrado && i < productos.Count)
			{
				if (productos[i].Nombre == nProd.Nombre)
				{
					encontrado = true;
				}
				i++;
			}
			if (precio && peso && !encontrado)
			{
				productos.Add(nProd);
				agregado = true;
			}
			else{
				if (encontrado)
				{
					Console.WriteLine("# ERROR:" + nProd.Nombre + " Producto ya existente.");
				}
				if (!precio)
				{
					Console.WriteLine("# ERROR:" + nProd.Nombre + " Precio debe ser mayor a 0");
				}
				if (!peso)
				{
					Console.WriteLine("# ERROR:" + nProd.Nombre + " Peso debe ser mayor a 0");
				}
			}
			return agregado;
		}
		
		// Recibe un centro, lo valida y si es valido, lo añade a la Lista.
		public bool nuevoCentro(Centro nCen)
		{
			bool existe = false;
			int ite = 0;
			while (ite < centros.Count && !existe)
			{
				if (nCen.Id == centros[ite].Id || nCen.Nombre == centros[ite].Nombre)
				{
					existe = true;
				}

				ite++;
			}

			if (!existe)
			{
				centros.Add(nCen);
			}
			else
			{
				Console.WriteLine("# ERROR:" + nCen.Nombre + " Centro ya existente.");
			}
			return !existe;
		}

		// Recibe un voluntario, lo valida y si es valido, lo añade a la Lista.
		public bool nuevoVoluntario(Voluntario nVol)
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
				Console.WriteLine("# ERROR: "+ nVol.Ci + " - Voluntario ya existente.");
			}

			return !existe;
		}

		// Recibe una donacion, la valida y si es valido, lo añade a la Lista.
		public void nuevaDonacion(DonacionEconomica nDonacion, Centro centro){
			bool existe = false;
			int ite = 0;
			while (ite < donaciones.Count && !existe)
			{
				if (nDonacion.Id == donaciones[ite].Id)
				{
					existe = true;
				}

				ite++;
			}

			if (!existe)
			{
				donaciones.Add(nDonacion);
				centro.recibirDonacion(nDonacion);
			}
			else
			{
				Console.WriteLine("# ERROR: Donacion ya existente.");
			}
		}

		// Recibe un tipo de porudcto y retorna una lista con los productos de dicho tipo.
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

		// Recibe un id por string, lo parsea y retorna el Centro que tenga ese Id, si no lo encuentra retorna null.
		public Centro getCentroById(string id){
            int elId = int.Parse(id);
			bool encontrado = false;
			Centro centro = null;
			int i = 0;
			while (!encontrado && i < centros.Count)
			{
				if (centros[i].Id == elId)
				{
					centro = centros[i];
					encontrado = true;
				}
				i++;
			}
			return centro;
		}

		// Recibe un id por string, lo parsea y retorna el Producto que tenga ese Id, si no lo encuentra retorna null.
		public Producto getProductoById(string id)
		{
			int elId = Int32.Parse(id);
			bool encontrado = false;
			Producto producto = null;
			int i = 0;
			while (!encontrado && i < productos.Count)
			{
				if (productos[i].Id == elId)
				{
					producto = productos[i];
					encontrado = true;
				}
				i++;
			}
			return producto;
		}

		// Recibe un nombre y retorna el Producto que tenga ese Id, si no lo encuentra retorna null.
		public Producto getProductoByNombre(string nombre)
		{
			bool encontrado = false;
			Producto producto = null;
			int i = 0;
			while (!encontrado && i < productos.Count)
			{
				if (productos[i].Nombre == nombre)
				{
					producto = productos[i];
					encontrado = true;
				}
				i++;
			}
			return producto;
		}

		// Recibe el id de un centro y retorna un string con la lista de voluntarios en ese centro.
		public string getStrVoluntariosCentro(string cId){
			
			Centro centro = getCentroById(cId);
			string strVoluntarios = "### CENTRO INEXISTENTE ###";

			if (centro != null)
			{
				strVoluntarios = centro.getStrVoluntarios();
			}

			return strVoluntarios;
		}

		private void cargaProductos(){ 
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
			nuevoProducto(new Producto("Lata arvejas", 1, 30, Producto.TipoProd.alimentoNoPerecedero));
			nuevoProducto(new Producto("Coquita en botella de vidrio :)", 0, 110, Producto.TipoProd.bebida));
			nuevoProducto(new Producto("PRODUCTO ERROR #1", 11, 0, Producto.TipoProd.productoHigiene));
			nuevoProducto(new Producto("PRODUCTO ERROR #2", 0, 11, Producto.TipoProd.productoHigiene));

		}
		private void cargaCentros(){
			nuevoCentro(new Centro("Shopping", "Calle 13"));
			nuevoCentro(new Centro("Hope", "18 de Julio y Bv.Artigas"));
			nuevoCentro(new Centro("Blandengues", "Av.Italia y L.A. Herrera"));
			nuevoCentro(new Centro("Prado", "Aigua y Valdense"));
			nuevoCentro(new Centro("Maroñas", "Veracierto y Chayos"));
			nuevoCentro(new Centro("CENTRO VACIO", "Mas abajo que YPF"));
			nuevoCentro(new Centro("CENTRO VACIO", "Mas abajo que YPF"));
		}
		private void cargaVoluntarios(){
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
			Voluntario v11 = new Voluntario("VOLUNTARIO ERROR", 95195195, 15915915, new DateTime(1976, 12, 28));

			if (nuevoVoluntario(v1))
			{
				centros[0].sumarVoluntario(v1);
			}
			if (nuevoVoluntario(v2))
			{
				centros[1].sumarVoluntario(v2);
			}
			if (nuevoVoluntario(v3))
			{
				centros[2].sumarVoluntario(v3);
			}
			if (nuevoVoluntario(v4))
			{
				centros[3].sumarVoluntario(v4);
			}
			if (nuevoVoluntario(v5))
			{
				centros[4].sumarVoluntario(v5);
			}
			if (nuevoVoluntario(v6))
			{
				centros[0].sumarVoluntario(v6);
			}
			if (nuevoVoluntario(v7))
			{
				centros[0].sumarVoluntario(v7);
				centros[1].sumarVoluntario(v7);
			}			
			if (nuevoVoluntario(v8))
			{
				centros[2].sumarVoluntario(v8);
			}		
			if (nuevoVoluntario(v9))
			{
				centros[3].sumarVoluntario(v9);
			}			
			if (nuevoVoluntario(v10))
			{
				centros[4].sumarVoluntario(v10);
			}
			if (nuevoVoluntario(v11))
			{
				centros[4].sumarVoluntario(v11);

			}
		}
		private void cargaDonaciones()
		{
			List<Producto> lProd1 = new List<Producto>();
			lProd1.Add(productos[0]);
			lProd1.Add(productos[0]);
			lProd1.Add(productos[0]);
			lProd1.Add(productos[3]);
			lProd1.Add(productos[3]);
			DonacionProducto donProd1 = new DonacionProducto(lProd1);

			List<Producto> lProd2 = new List<Producto>();
			lProd2.Add(productos[2]);
			lProd2.Add(productos[2]);
			lProd2.Add(productos[6]);
			DateTime fecha2 = new DateTime(2020, 1, 1);
			DonacionProducto donProd2 = new DonacionProducto(lProd2, fecha2);

			List<Producto> lProd3 = new List<Producto>();
			lProd3.Add(productos[1]);
			lProd3.Add(productos[1]);
			lProd3.Add(productos[1]);
			DateTime fecha3 = new DateTime(2019, 6, 28);
			DonacionProducto donProd3 = new DonacionProducto(lProd3, fecha3);


			List<Producto> lProd4 = new List<Producto>();
			lProd3.Add(productos[1]);
			lProd3.Add(productos[1]);
			lProd3.Add(productos[1]);
			DateTime fecha4 = new DateTime(2020, 2, 13);
			DonacionProducto donProd4 = new DonacionProducto(lProd4, fecha4);

			DonacionEconomica donEco1 = new DonacionEconomica(15000);
			DonacionEconomica donEco2 = new DonacionEconomica(1000, fecha2);

			nuevaDonacion(donEco1, centros[0]);
			nuevaDonacion(donProd1, centros[0]);
			nuevaDonacion(donEco2, centros[1]);
			nuevaDonacion(donProd2, centros[1]);
			nuevaDonacion(donProd3, centros[2]);
			nuevaDonacion(donProd4, centros[3]);


		}

		// Recibe una fecha y retorna un string con la cantidad de donaciones recibidas por un centro en esa fecha.
		// Si el centro no ha recibido donaciones da un mensaje acorde.
		public string getStrDonacionByFecha(DateTime fecha)
		{
			string strDonaciones = "## DONACIONES POR FECHA ## \n";

			foreach (Centro centro in centros)
			{
				strDonaciones += "CENTRO: " + centro.Nombre + " " + centro.getStrDonacionesFecha(fecha);
				
			}

			return strDonaciones;
		}


	}
    
}
