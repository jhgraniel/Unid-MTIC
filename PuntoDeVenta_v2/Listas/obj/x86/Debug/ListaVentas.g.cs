﻿

#pragma checksum "C:\Users\Usuario\Documents\Visual Studio 2013\Projects\PuntoDeVenta_v2\Listas\ListaVentas.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "77C9A9948AC7247B26F765171187927E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PuntoDeVenta
{
    partial class ListaVentas : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 15 "..\..\..\ListaVentas.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.lstVentas_Loaded;
                 #line default
                 #line hidden
                #line 15 "..\..\..\ListaVentas.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.lstVentas_SelectionChanged;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 25 "..\..\..\ListaVentas.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnNueva_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

