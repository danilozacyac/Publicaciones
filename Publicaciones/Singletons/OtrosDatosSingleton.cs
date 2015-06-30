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
        private static ObservableCollection<OtrosDatos> medioPublicacion;

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

        public static ObservableCollection<OtrosDatos> MedioPublicacion
        {
            get
            {
                if (medioPublicacion == null)
                    medioPublicacion = new OtrosDatosModel().GetMedioPub();

                return medioPublicacion;
            }
        }
    }
}
