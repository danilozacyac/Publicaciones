using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publicaciones.Dao 
{
    public class Obras : INotifyPropertyChanged
    {
        private int idObra;
        private int orden;
        private string titulo;
        private string tituloStr;
        private string sintesis;
        private string sintesisStr;
        private string numeroMaterial;
        private int anioPublicacion;
        private string edicion;
        private string isbn;
        private int pais;
        private int idioma;
        private int paginas;
        private string clasificacion;
        private int tipoPublicacion;
        private int medioPublicacion;
        private int materia;
        private string descripcion;
        private string descripcionStr;
        private int consec;
        private string precio;
        private string imagen;
        private int conMay;
        private int nivel;
        private int padre;
        private ObservableCollection<Autores> lAutores;
        private int idTipoAutor;
        private string tipoPublicacionStr;

        public int IdObra
        {
            get
            {
                return this.idObra;
            }
            set
            {
                this.idObra = value;
            }
        }

        public int Orden
        {
            get
            {
                return this.orden;
            }
            set
            {
                this.orden = value;
            }
        }

        public string Titulo
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
            }
        }

        public string TituloStr
        {
            get
            {
                return this.tituloStr;
            }
            set
            {
                this.tituloStr = value;
            }
        }

        public string Sintesis
        {
            get
            {
                return this.sintesis;
            }
            set
            {
                this.sintesis = value;
            }
        }

        public string SintesisStr
        {
            get
            {
                return this.sintesisStr;
            }
            set
            {
                this.sintesisStr = value;
            }
        }

        public string NumeroMaterial
        {
            get
            {
                return this.numeroMaterial;
            }
            set
            {
                this.numeroMaterial = value;
            }
        }

        public int AnioPublicacion
        {
            get
            {
                return this.anioPublicacion;
            }
            set
            {
                this.anioPublicacion = value;
            }
        }

        public string Edicion
        {
            get
            {
                return this.edicion;
            }
            set
            {
                this.edicion = value;
            }
        }

        public string Isbn
        {
            get
            {
                return this.isbn;
            }
            set
            {
                this.isbn = value;
            }
        }

        public int Pais
        {
            get
            {
                return this.pais;
            }
            set
            {
                this.pais = value;
            }
        }

        public int Idioma
        {
            get
            {
                return this.idioma;
            }
            set
            {
                this.idioma = value;
            }
        }

        public int Paginas
        {
            get
            {
                return this.paginas;
            }
            set
            {
                this.paginas = value;
            }
        }

        public string Clasificacion
        {
            get
            {
                return this.clasificacion;
            }
            set
            {
                this.clasificacion = value;
            }
        }

        public int TipoPublicacion
        {
            get
            {
                return this.tipoPublicacion;
            }
            set
            {
                this.tipoPublicacion = value;
            }
        }

        public int MedioPublicacion
        {
            get
            {
                return this.medioPublicacion;
            }
            set
            {
                this.medioPublicacion = value;
            }
        }

        public int Materia
        {
            get
            {
                return this.materia;
            }
            set
            {
                this.materia = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        public string DescripcionStr
        {
            get
            {
                return this.descripcionStr;
            }
            set
            {
                this.descripcionStr = value;
            }
        }

        public int Consec
        {
            get
            {
                return this.consec;
            }
            set
            {
                this.consec = value;
            }
        }

        public string Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        public string Imagen
        {
            get
            {
                return this.imagen;
            }
            set
            {
                this.imagen = value;
            }
        }

        public int ConMay
        {
            get
            {
                return this.conMay;
            }
            set
            {
                this.conMay = value;
            }
        }

        public int Nivel
        {
            get
            {
                return this.nivel;
            }
            set
            {
                this.nivel = value;
            }
        }

        public int Padre
        {
            get
            {
                return this.padre;
            }
            set
            {
                this.padre = value;
            }
        }

        public ObservableCollection<Autores> LAutores
        {
            get
            {
                return this.lAutores;
            }
            set
            {
                this.lAutores = value;
                this.OnPropertyChanged("LAutores");
            }
        }

        public int IdTipoAutor
        {
            get
            {
                return this.idTipoAutor;
            }
            set
            {
                this.idTipoAutor = value;
            }
        }

        public string TipoPublicacionStr
        {
            get
            {
                return this.tipoPublicacionStr;
            }
            set
            {
                this.tipoPublicacionStr = value;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

           
        }

        #endregion // INotifyPropertyChanged Members

    }
}
