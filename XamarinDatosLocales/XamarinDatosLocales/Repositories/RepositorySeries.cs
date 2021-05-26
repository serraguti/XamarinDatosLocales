using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinDatosLocales.Helpers;
using XamarinDatosLocales.Models;

namespace XamarinDatosLocales.Repositories
{
    public class RepositorySeries
    {
        HelperFiles helper;
        public RepositorySeries()
        {
            this.helper = new HelperFiles();
        }

        public List<Serie> GetSeries()
        {
            String resource = 
                "XamarinDatosLocales.Documents.series.json";
            String data = this.helper.ReadFile(resource);
            List<Serie> series =
                JsonConvert.DeserializeObject<List<Serie>>(data);
            return series;
        }
    }
}
