using Listas.Clases;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntoDeVenta.Clases
{
    class AuxiliarBD
    {
        SQLiteConnection dbConn;

        //Create Tabble
        public async Task<bool> onCreate(string DB_PATH)
        {
            try
            {
                if (!CheckFileExists(DB_PATH).Result)
                {
                    using (dbConn = new SQLiteConnection(DB_PATH))
                    {
                        dbConn.CreateTable<Venta>();
                        dbConn.CreateTable<VentaDetalle>();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Retrieve the specific contact from the database.
        public Venta LeerUnaVenta(int folio)
        {
            using (var dbConn = new SQLiteConnection(Listas.App.DB_PATH))
            {
                var existingconact = dbConn.Query<Venta>("select * from Venta where folio =" + folio).FirstOrDefault();
                return existingconact;
            }
        }
        // Retrieve the all contact list from the database.
        public ObservableCollection<Venta> LeerVentas()
        {
            using (var dbConn = new SQLiteConnection(Listas.App.DB_PATH))
            {
                List<Venta> myCollection = dbConn.Table<Venta>().ToList<Venta>();
                ObservableCollection<Venta> VentasList = new ObservableCollection<Venta>(myCollection);
                return VentasList;
            }
        }
       
        // Insert the new contact in the Ventas table.
        public int Insert(Venta nuevaVenta)
        {
            int idVenta = 0;
            using (var dbConn = new SQLiteConnection(Listas.App.DB_PATH))
            {
                dbConn.RunInTransaction(() =>
                {
                    dbConn.Insert(nuevaVenta);
                    idVenta=nuevaVenta.Folio;
                });
            }
                return idVenta;
        }
//**************************************   VENTA_DETALLE ******************************
         public List<VentaDetalle> LeerProductosVendidos(int folio)
        {
            using (var dbConn = new SQLiteConnection(Listas.App.DB_PATH))
            {
               List<VentaDetalle> productos=new List<VentaDetalle>();
               productos = dbConn.Query<VentaDetalle>("select * from VentaDetalle where folio =" + folio);
               return productos;
            }
        }

         public void InsertarProductosVendidos(List<VentaDetalle> productos) {
             using (var dbConn = new SQLiteConnection(Listas.App.DB_PATH))
             {
                 dbConn.RunInTransaction(() =>
                 {
                     foreach (VentaDetalle prod in productos) {
                         dbConn.Insert(prod);
                     }
                     
                    
                 });
             }
         }

    }
}
