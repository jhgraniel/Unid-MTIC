using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas.Clases
{
    class ProdAgregado
    {
        public int idProducto { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }

        

        public ProdAgregado(int id,string nom,decimal costo, int cant) {
            idProducto = id;
            Nombre = nom;
            PrecioUnitario = costo;
            Cantidad = cant;
            Total = costo * cant;
        }
        public ProdAgregado() { }

    }
}
