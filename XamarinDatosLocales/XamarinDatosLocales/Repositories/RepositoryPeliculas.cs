using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using XamarinDatosLocales.Helpers;
using XamarinDatosLocales.Models;

namespace XamarinDatosLocales.Repositories
{
    public class RepositoryPeliculas
    {
        HelperFiles helper;
        public RepositoryPeliculas()
        {
            this.helper = new HelperFiles();
        }

        public List<Pelicula> GetPeliculas()
        {
            String resource =
                "XamarinDatosLocales.Documents.EscenasPeliculas.xml";
            String data = this.helper.ReadFile(resource);
            XDocument docxml = XDocument.Parse(data);
            var consulta = from datos in docxml.Descendants("pelicula")
                           select new Pelicula
                           {
Titulo = datos.Element("titulo").Value
, TituloOriginal = datos.Element("titulooriginal").Value
, Descripcion = datos.Element("descripcion").Value
, Poster = datos.Element("poster").Value
, Escenas = new List<Escena>(from escena in datos.Descendants("escena")
                             select new Escena
                             {
 TituloEscena = escena.Element("tituloescena").Value
 , DescripcionEscena = escena.Element("descripcion").Value
 , Imagen = escena.Element("imagen").Value
                             })
                           };
            return consulta.ToList();
        }
    }
}
