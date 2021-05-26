using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinDatosLocales.Models;
using XamarinDatosLocales.ViewModels;

namespace XamarinDatosLocales.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeliculasView : ContentPage
    {
        public PeliculasView()
        {
            InitializeComponent();
            this.listviewPeliculas.ItemSelected += 
                ListviewPeliculas_ItemSelected;
        }

        private void ListviewPeliculas_ItemSelected(object sender
            , SelectedItemChangedEventArgs e)
        {
            Pelicula peliSeleccionada = e.SelectedItem as Pelicula;
            //CREAMOS NUESTRO VIEWMODEL
            PeliculaViewModel viewmodel = new PeliculaViewModel();
            //CREAMOS LA VISTA DE ESCENAS
            EscenasView view = new EscenasView();
            //INDICAMOS AL VIEWMODEL LA PELICULA A CARGAR
            viewmodel.Pelicula = peliSeleccionada;
            //INDICAMOS A LA VISTA CUAL ES SU ORIGEN DE DATOS
            view.BindingContext = viewmodel;
            //MOSTRAMOS LA VISTA ESCENAS
            Navigation.PushModalAsync(view);
        }
    }
}