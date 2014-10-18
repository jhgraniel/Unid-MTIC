using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Clases
{
    class VentaDetalle
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int idDetalle { get; set; }
        public int Folio { get; set; }
        public int Cantidad { get; set; }

        public string Producto { get; set;  }

        public decimal Precio { get; set; }

        public decimal Importe { get; set; }

        public VentaDetalle() { }
        public VentaDetalle(int idVenta, int cant, string prod, decimal precio, decimal costo) {
            Folio = idVenta;
            Cantidad = cant;
            Producto = prod;
            Precio = precio;
            Importe = costo;
        }

    }
}
