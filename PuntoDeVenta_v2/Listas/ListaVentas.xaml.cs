using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ListaVentas : Page
    {
        ObservableCollection<Venta> todasVentas = new ObservableCollection<Venta>();
        public ListaVentas()
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
        }

        private void btnNueva_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Listas.MainPage));
        }

        private void lstVentas_Loaded(object sender, RoutedEventArgs e)
        {
            AuxiliarBD AuxBD=new AuxiliarBD();
            
            todasVentas=AuxBD.LeerVentas();

            lstVentas.ItemsSource = todasVentas.OrderByDescending(i => i.Folio).ToList();
        }

        private void lstVentas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstVentas.SelectedIndex != -1)
            {
                Venta unaVenta = lstVentas.SelectedItem as Venta;
                Frame.Navigate(typeof(DetalleVenta), unaVenta.Folio);
            }            
        }
    }
}
