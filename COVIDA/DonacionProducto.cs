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
			this.productos = productos;
			base.Fecha = fecha;
		}
		public DonacionProducto(List<Producto> productos) : base()
        {
			this.productos = productos;
        }
        
        public override double calcularVale()
		{
			double vale = 0;

			// TODO

			return vale;

        }
        #endregion
    }
}
