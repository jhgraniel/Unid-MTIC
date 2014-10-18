using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Clases
{
    class Producto
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioUnitario { get; set; }

         public Producto(int id,string nom,decimal costo) {
            idProducto = id;
            Nombre = nom;
            PrecioUnitario = costo;
        }
        public Producto() { }

    }
}
