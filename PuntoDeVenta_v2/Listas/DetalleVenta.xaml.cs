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
using PuntoDeVenta.Clases;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkID=390556

namespace PuntoDeVenta
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class DetalleVenta : Page
    {
        int folio = 0;
        AuxiliarBD dbAux = new AuxiliarBD();
        Venta ventaSel = new Venta();
        List<VentaDetalle> productos = new List<VentaDetalle>();
        
        public DetalleVenta()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            folio = (int)e.Parameter;
            ventaSel = dbAux.LeerUnaVenta(folio);
            lblFolio.Text= ventaSel.Folio.ToString();
            lblFecha.Text = ventaSel.Fecha;
            lblSubtotal.Text = ventaSel.SubTotal.ToString();
            lblIva.Text = ventaSel.IVA.ToString();
            lblTotal.Text = ventaSel.Total.ToString();
            lblPagado.Text = ventaSel.Efectivo.ToString();
            lblCambio.Text = ventaSel.Cambio.ToString();
            lblLetras.Text = ventaSel.Letras;

            AuxiliarBD AuxBD=new AuxiliarBD();
            productos = AuxBD.LeerProductosVendidos(folio);

            lista.ItemsSource = productos;

            /*
             Selected_ContactId = (int)e.Parameter;  
            currentContact = Db_Helper.ReadContact(Selected_ContactId);
            lbl_nombre.Text = currentContact.Name;
            lbl_telefono.Text = currentContact.PhoneNumber;
             */
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListaVentas));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            EnviarEmail();
            
          }  

        
    private async void EnviarEmail()
    {
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();
            emailMessage.Body = "Folio:  " + ventaSel.Folio.ToString() + "\n" +
           "Fecha:      " + ventaSel.Fecha +  "\n" +
           "SubTotal:  " + ventaSel.SubTotal.ToString() + "\n" +
           "IVA:          " + ventaSel.IVA.ToString() + "\n" +
           "Total:        " +  ventaSel.Total.ToString() + "\n" +
            ventaSel.Letras.ToString() + "\n" +
           "Efectivo:    " + ventaSel.Efectivo.ToString() + " \n" +
           "Cambio:    " + ventaSel.Cambio.ToString()+ " \n" +
           "----------------------------------------   \n";
           
        foreach (VentaDetalle elem in productos )
            {
                emailMessage.Body += elem.Cantidad.ToString() + " \t \t" + elem.Producto + "\t \t" + elem.Precio.ToString() + "\t \t" + elem.Importe.ToString() + " \n";


            }


        
            emailMessage.Subject = "Detalle de Venta:  " + ventaSel.Folio.ToString(); ;
            var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient("jcdm2207@hotmail.com");
            emailMessage.To.Add(emailRecipient);
           await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }


    }





}
