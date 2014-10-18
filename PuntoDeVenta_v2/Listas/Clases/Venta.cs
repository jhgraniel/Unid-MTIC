using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Clases
{
    class Venta 
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Folio {get; set;}
        public string Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public decimal Efectivo { get; set; }
        public decimal Cambio { get; set; }

        public string Letras { get; set; }

        public Venta(decimal sub, decimal imp, decimal tot, decimal pag, decimal cam, string letras)
        {
            SubTotal = sub;
            IVA = imp;
            Total = tot;
            Efectivo = pag;
            Cambio = cam;
            Fecha = DateTime.Now.ToString();
            Letras = letras;
        }

        public Venta() { }

            
    }
}
