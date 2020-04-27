using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVIDA
{
    class DonacionProducto: DonacionEconomica
    {
        
		#region Atributos
		private List<Producto> productos;
		
		#endregion

		#region Propiedades

		public List<Producto> Productos{
			set { productos = value; }
			get { return productos; }
		}

		#endregion


		#region Metodos
		public DonacionProducto(List<Producto> productos, DateTime fecha) : base()
		{
			base.id = ultimoId++;
			this.productos = productos;
			base.Fecha = fecha;
			foreach (Producto prod in productos)
			{
				Valor += prod.Precio;
			}
		}
		public DonacionProducto(List<Producto> productos) : base()
        {
			base.Fecha = DateTime.Now;
			this.productos = productos;
        }
        
        #endregion
    }
}
