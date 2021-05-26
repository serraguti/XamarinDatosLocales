using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinDatosLocales.Base;
using XamarinDatosLocales.Models;
using XamarinDatosLocales.Repositories;

namespace XamarinDatosLocales.ViewModels
{
    public class AlumnosViewModel: ViewModelBase
    {
        RepositoryAlumnos repo;

        public AlumnosViewModel()
        {
            this.repo = new RepositoryAlumnos();
        }

        private List<Alumno> _Alumnos;
        public List<Alumno> Alumnos
        {
            get { return this._Alumnos; }
            set
            {
                this._Alumnos = value;
                OnPropertyChanged("Alumnos");
            }
        }

        public Command LoadAlumnos
        {
            get
            {
                return new Command(() => {
                    this.Alumnos = this.repo.GetAlumnos();
                });
            }
        }
    }
}
