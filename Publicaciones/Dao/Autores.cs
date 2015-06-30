using System;
using System.ComponentModel;
using System.Linq;
using Publicaciones.Mantenimiento;
using Publicaciones.Models;

namespace Publicaciones.Dao
{
    public class Autores : INotifyPropertyChanged 
    {
        private int idAutor;
        private int idTitulo;
        private string nombre;
        private string nombreDesc;
        private int idTipoAutor;
        private bool isAutor;
        private bool isCompilador;
        private bool isTraductor;
        private bool isCoordinador;
        private bool isComentarista;
        private bool isCoedicion;
        private bool isEstudio;
        private bool isPrologo;
        
       public int IdAutor
        {
            get
            {
                return this.idAutor;
            }
            set
            {
                this.idAutor = value;
            }
        }

        public int IdTitulo
        {
            get
            {
                return this.idTitulo;
            }
            set
            {
                this.idTitulo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string NombreDesc
        {
            get
            {
                return this.nombreDesc;
            }
            set
            {
                this.nombreDesc = value;
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

        public bool IsAutor
        {
            get
            {
                return this.isAutor;
            }
            set
            {
                this.isAutor = value;
                this.OnPropertyChanged("IsAutor");
            }
        }

        public bool IsCompilador
        {
            get
            {
                return this.isCompilador;
            }
            set
            {
                this.isCompilador = value;
                this.OnPropertyChanged("IsCompilador");
            }
        }

        public bool IsTraductor
        {
            get
            {
                return this.isTraductor;
            }
            set
            {
                this.isTraductor = value;
                this.OnPropertyChanged("IsTraductor");
            }
        }

        public bool IsCoordinador
        {
            get
            {
                return this.isCoordinador;
            }
            set
            {
                this.isCoordinador = value;
                this.OnPropertyChanged("IsCoordinador");
            }
        }

        public bool IsComentarista
        {
            get
            {
                return this.isComentarista;
            }
            set
            {
                this.isComentarista = value;
                this.OnPropertyChanged("IsComentarista");
            }
        }

        public bool IsCoedicion
        {
            get
            {
                return this.isCoedicion;
            }
            set
            {
                this.isCoedicion = value;
                this.OnPropertyChanged("IsCoedicion");
            }
        }

        public bool IsEstudio
        {
            get
            {
                return this.isEstudio;
            }
            set
            {
                this.isEstudio = value;
                this.OnPropertyChanged("IsEstudio");
            }
        }

        public bool IsPrologo
        {
            get
            {
                return this.isPrologo;
            }
            set
            {
                this.isPrologo = value;
                this.OnPropertyChanged("IsPrologo");
            }
        }

        

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            if (RelacionObraAutor.IdObraSelect != -1)
            {
                switch (propertyName)
                {
                    case "IsAutor":
                        if(this.IsAutor)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                    case "IsCompilador":
                        if (this.IsCompilador)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                    case "IsTraductor":
                        if (this.IsTraductor)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                    case "IsCoordinador":
                        if (this.IsCoordinador)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                    case "IsComentarista":
                        if (this.IsComentarista)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                    case "IsCoedicion":
                        if (this.IsCoedicion)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                    case "IsEstudio":
                        if (this.IsEstudio)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                    case "IsPrologo":
                        if (this.IsPrologo)
                            new AutoresModel().SetNewRelation(this, RelacionObraAutor.IdObraSelect);
                        else
                            new AutoresModel().DeleteRelacion(this, RelacionObraAutor.IdObraSelect);
                        break;
                }
            }
        }

        #endregion // INotifyPropertyChanged Members
    }
}
