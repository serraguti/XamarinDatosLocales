using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using XamarinDatosLocales.Base;
using XamarinDatosLocales.Models;
using XamarinDatosLocales.Repositories;
using XamarinDatosLocales.Views;

namespace XamarinDatosLocales.ViewModels
{
    public class PeliculasViewModel: ViewModelBase
    {
        RepositoryPeliculas repo;
        public PeliculasViewModel()
        {
            this.repo = new RepositoryPeliculas();
            List<Pelicula> pelis = this.repo.GetPeliculas();
            this.Peliculas = new ObservableCollection<Pelicula>(pelis);
        }

        private ObservableCollection<Pelicula> _Peliculas;
        public ObservableCollection<Pelicula> Peliculas
        {
            get { return this._Peliculas; }
            set
            {
                this._Peliculas = value;
                OnPropertyChanged("Peliculas");
            }
        }

        private Pelicula _PeliculaSeleccionada;
        public Pelicula PeliculaSeleccionada
        {
            get { return this._PeliculaSeleccionada; }
            set
            {
                this._PeliculaSeleccionada = value;
                OnPropertyChanged("PeliculaSeleccionada");
            }
        }

        public Command ShowEscenas
        {
            get
            {
                return new Command(() =>
                {
                    //INSTANCIAMOS EL VIEWMODEL
                    PeliculaViewModel viewmodel =
                    new PeliculaViewModel();
                    //ENLAZAMOS LOS DATOS DEL VIEWMODEL
                    //CON LA PELI SELECCIONADA
                    viewmodel.Pelicula = this.PeliculaSeleccionada;
                    //CREAMOS LA VISTA A MOSTRAR
                    EscenasView view = new EscenasView();
                    //ENLAZAMOS LA VISTA CON SU VIEWMODEL
                    view.BindingContext = viewmodel;
                    //MOSTRAMOS LA VISTA COMO MODAL
Application.Current.MainPage.Navigation.PushModalAsync(view);
                });
            }
        }
    }
}
