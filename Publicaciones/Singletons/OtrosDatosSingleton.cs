using System;
using System.Collections.ObjectModel;
using System.Linq;
using Publicaciones.Dao;
using Publicaciones.Models;

namespace Publicaciones.Singletons
{
    public class OtrosDatosSingleton
    {
        private static ObservableCollection<OtrosDatos> tipoAutor;
        private static ObservableCollection<OtrosDatos> titulos;

        private OtrosDatosSingleton()
        {
        }

        public static ObservableCollection<OtrosDatos> TipoAutor
        {
            get
            {
                if (tipoAutor == null)
                    tipoAutor = new OtrosDatosModel().GetTipoAutor();

                return tipoAutor;
            }
        }

        public static ObservableCollection<OtrosDatos> Titulos
        {
            get
            {
                if (titulos == null)
                    titulos = new OtrosDatosModel().GetTitulos();

                return titulos;
            }
        }
    }
}
