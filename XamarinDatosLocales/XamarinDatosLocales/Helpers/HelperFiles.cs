using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace XamarinDatosLocales.Helpers
{
    public class HelperFiles
    {
        public String ReadFile(String resourceName)
        {
            var assembly =
                IntrospectionExtensions.GetTypeInfo(typeof(HelperFiles))
                .Assembly;
            Stream stream = 
                assembly.GetManifestResourceStream(resourceName);
            using (StreamReader reader = new StreamReader(stream))
            {
                String data = reader.ReadToEnd();
                return data;
            }
        }
    }
}
