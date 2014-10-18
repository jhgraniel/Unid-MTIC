using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Listas.Clases;
using System.Collections.ObjectModel;
using PuntoDeVenta.Clases;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=391641

namespace Listas
{
   
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
       
        //Dictionary<string,decimal> productos= new Dictionary<string, decimal>();
        ObservableCollection<ProdAgregado>  agregados= new ObservableCollection<ProdAgregado>();
        List <Producto> productos=new List<Producto>();
        List<VentaDetalle> detalle = new List<VentaDetalle>();
        decimal subtotal = 0, total = 0, iva = 0, cambio = 0, pagado = 0;
        string letras="";
        int folioVenta=0;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {


            subtotal = 0; total = 0; iva = 0; cambio = 0; pagado = 0;
            letras = "";
            agregados.Clear();
            productos.Clear();
            lblPrecio.Text = "$ 0.0";
            txtCantidad.Text = "";
            lblSubtotal.Text = "$ 0.0";
            lblIva.Text = "$ 0.0";
            lblTotal.Text = "$ 0.0";
            txtPagado.Text = "";
            lblCambio.Text = "";

                productos.Add(new Producto(1, "Azúcar", 30));
                productos.Add(new Producto(2, "Galletas", 15));
                productos.Add(new Producto(3, "Gomitas", 8));
                productos.Add(new Producto(4, "Refrescos", 9.5m));
                productos.Add(new Producto(5, "Pan Dulce", 4));
                productos.Add(new Producto(6, "Naranjas", 0.5m));
                cmbProductos.ItemsSource = productos;
                lista.ItemsSource = agregados;
           
           

            // TODO: Preparar la página que se va a mostrar aquí.

            // TODO: Si la aplicación contiene varias páginas, asegúrese de
            // controlar el botón para retroceder del hardware registrándose en el
            // evento Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si usa NavigationHelper, que se proporciona en algunas plantillas,
            // el evento se controla automáticamente.
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCantidad.Text == "") {

                txtCantidad.Text = "1";
            
            }



            if (cmbProductos.SelectedIndex>=0) {       
                Producto productoAct=new Producto();                
                productoAct=cmbProductos.SelectedItem as Producto;

                int cant=0;
                int.TryParse(txtCantidad.Text, out cant);

                decimal precio = 0;
                precio=productoAct.PrecioUnitario;

                ProdAgregado nuevo = new ProdAgregado(productoAct.idProducto, productoAct.Nombre, productoAct.PrecioUnitario,cant);
                agregados.Add(nuevo);

                subtotal += nuevo.Total;
                lblSubtotal.Text = "$ "+subtotal.ToString("F");

                iva = subtotal * 0.16m;
                lblIva.Text = "$ " + iva.ToString("F");

                total = subtotal + iva;
                lblTotal.Text = "$ " + total.ToString("F");

                txtCantidad.Text = "";

                letras = "SON: "+enletras(total.ToString());
                lblLetras.Text =letras;
                
            }
        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }
        private async void VerMensaje(String msj)
        {
            Windows.UI.Popups.MessageDialog mensaje = new Windows.UI.Popups.MessageDialog(msj);
            await mensaje.ShowAsync();
        }

       

        private void txtPagado_LostFocus(object sender, RoutedEventArgs e)
        {
            decimal.TryParse(txtPagado.Text, out pagado);

            if (pagado<total)
            {
                VerMensaje("El importe de la venta es mayor");
                
            }
            else
            {
               
                cambio = pagado - total;
                lblCambio.Text = "$ " + cambio.ToString("F");
            }
        }

        private void cmbProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Producto productoAct = new Producto();
            productoAct = cmbProductos.SelectedItem as Producto;
            
            lblPrecio.Text = "$ "+productoAct.PrecioUnitario.ToString();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PuntoDeVenta.ListaVentas));
        }

        private void btnVender_Click(object sender, RoutedEventArgs e)
        {
            if (txtPagado.Text == "")
            {

                VerMensaje("Se debe realizar el pago de la compra");
                
            }
            else if (pagado < total) {
                VerMensaje("El importe de la venta es mayor");
            }
            else
            {
                AuxiliarBD BDAux = new AuxiliarBD();

                folioVenta = BDAux.Insert(new Venta(subtotal, iva, total, pagado, cambio,letras));
                if (folioVenta > 0)
                {
                    foreach (ProdAgregado prod in agregados)
                    {
                        VentaDetalle vendido = new VentaDetalle();
                        vendido.Folio = folioVenta;
                        vendido.Precio = prod.PrecioUnitario;
                        vendido.Producto = prod.Nombre;
                        vendido.Importe = prod.Total;
                        vendido.Cantidad = prod.Cantidad;
                        detalle.Add(vendido);
                    }
                    BDAux.InsertarProductosVendidos(detalle);
                }




                Frame.Navigate(typeof(PuntoDeVenta.ListaVentas));
            }
                 
            
            
            }

      
       
    }
}
